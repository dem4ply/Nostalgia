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

		protected void Update()
		{
			if ( rest_mode )
			{
				current_time = 0f;
				spanner_current_time = 0f;
				spanner_time = 0f;
				hp_casa.current_points = hp_casa.total_of_points;
				stop_wave();
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
					rest_mode = true;
			}
		}

		public void change_spaner()
		{
			stop_wave();
			int spanner_post = new System.Random().Next( 0, spanner.Count );
			Debug.Log( spanner[ spanner_post ].name );
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