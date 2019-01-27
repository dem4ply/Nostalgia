using UnityEngine;
using System.Collections.Generic;

namespace spawner
{
	namespace invoker
	{
		public class Timer_hack : chibi.Chibi_behaviour
		{
			public Spawn_enemy_1 spawn;
			public float delta_time = 1f;
			public int amount_of_spawn = 0;

			protected float _sigma_time = 0f;
			protected int _amount_of_spawns = 0;

			protected void Update()
			{
				_sigma_time += Time.deltaTime;
				if ( _sigma_time >= delta_time )
				{
					spawn.spawn();
					_sigma_time -= delta_time;
				}
			}
		}
	}
}