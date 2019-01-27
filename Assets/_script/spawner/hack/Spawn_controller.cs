using UnityEngine;
using System.Collections.Generic;

namespace spawner
{
	public class Spawn_controller : chibi_base.Chibi_behaviour
	{
		public List<GameObject> spanner;
		public List<float> wave_times;
		public int current_wave = 0;

		public float spawn_time_min = 3f;
		public float spawn_time_max = 5f;

		public bool rest_mode = true;
		public bool set_next_spanner = false;

		protected float current_time = 0f;
		protected float spanner_current_time = 0f;
		protected float spanner_time = 0f;

		public damage.motor.HP_motor hp_casa;

		public float rest_time = 10f;
		public float current_rest_time = 0f;

		public List<GameObject> items;
		public List<GameObject> cards;
		public float wait_time = 0f;
		public float curent_wait_time = 0f;
		public bool read_card = true;

		public int current_item = 0;

		protected void Update()
		{
			if ( rest_mode )
			{
				current_time = 0f;
				spanner_current_time = 0f;
				spanner_time = 0f;
				hp_casa.current_points = hp_casa.total_of_points;
				stop_wave();
				if ( read_card )
				{
					current_rest_time += Time.deltaTime;
					if ( current_rest_time > rest_time )
					{
						rest_mode = false;
						current_rest_time = 0f;
					}
				}
				else
				{
					cards[ current_item ].SetActive( true );
					items[ current_item ].SetActive( true );
					curent_wait_time += Time.deltaTime;
					if ( curent_wait_time > wait_time )
					{
						if ( Input.anyKey )
						{
							cards[ current_item ].SetActive( false );
							read_card = true;
							++current_item;
						}
					}
				}
			}
			else
			{
				if ( set_next_spanner )
				{
					spanner_current_time = 0f;
					spanner_time = Random.Range( spawn_time_min, spawn_time_max );
					change_spaner();
					set_next_spanner = false;
				}
				else
				{
					spanner_current_time += Time.deltaTime;
					if ( spanner_current_time > spanner_time )
						set_next_spanner = true;
				}
				current_time += Time.deltaTime;
				if ( current_time > wave_times[ current_wave ] )
				{
					rest_mode = true;
					var e = GameObject.FindGameObjectsWithTag(
						helper.consts.tags.enemy );
					foreach ( var o in e )
					{
						var h = o.GetComponent<Enemy_attack>();
						if ( h )
							h.died();
					}
					read_card = false;
					curent_wait_time = 0f;
				}
			}
		}

		public void change_spaner()
		{
			stop_wave();
			int spanner_post = new System.Random().Next( 0, spanner.Count );
			Debug.Log( spanner[ spanner_post ].name );
			spanner[ spanner_post ].SetActive( true );
		}

		public void start_wave()
		{
			foreach ( GameObject obj in spanner )
			{
				obj.SetActive( true );
			}
		}

		public void stop_wave()
		{
			foreach ( GameObject obj in spanner )
			{
				obj.SetActive( false );
			}
		}
	}
}