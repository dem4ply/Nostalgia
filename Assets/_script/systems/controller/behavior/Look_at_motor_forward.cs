using UnityEngine;
using Unity.Entities;
using chibi.motor.behavior;

namespace chibi.systems.motor.behavior
{
	public class Look_at_motor_forward : ComponentSystem
	{
		struct group
		{
			public chibi.motor.behavior.Look_at_motor_forward behavior;
			public Transform transform;
			public chibi.motor.npc.Motor_isometric motor;
		}

		protected override void OnUpdate()
		{
			float delta_time = Time.deltaTime;
			foreach ( var entity in GetEntities<group>() )
			{
				var look_at = entity.behavior;
				var motor = entity.motor;
				Vector3 desire_direction = motor.desire_direction;
				if ( desire_direction == Vector3.zero )
					desire_direction = look_at.desire_vector;
				else
					look_at.desire_vector = desire_direction;
				Quaternion rotation = Quaternion.LookRotation( desire_direction );
				entity.transform.rotation = rotation;
			}
		}
	}
}
