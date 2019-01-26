using UnityEngine;
using System.Collections;

using Unity.Entities;

namespace chibi.systems.motor.behavior.steering
{
	public class Seek : ComponentSystem
	{
		struct group
		{
			public chibi.motor.behavior.steering.Seek behavior;
			public Transform transform;
			public chibi.motor.npc.Motor_isometric motor;
		}

		protected override void OnUpdate()
		{
			foreach ( var entity in GetEntities<group>() )
			{
				var behavior = entity.behavior;
				if ( helper.game_object.comp.is_null( behavior.target ) )
				{
					entity.motor.desire_direction = Vector3.zero;
					continue;  // no se movera de su posicion actual
				}
				var desire_direction = behavior.target.transform.position
					- entity.transform.position;

				entity.motor.desire_direction = desire_direction;
				entity.motor.desire_speed = entity.motor.max_speed;
			}
		}
	}
}
