using UnityEngine;
using Unity.Entities;
using chibi.motor;

namespace chibi.systems.motor
{
	public class Motor_bullet : ComponentSystem
	{
		struct group
		{
			
			public chibi.motor.weapons.gun.bullet.Bullet_motor motor;
			public Rigidbody rigidbody;
		}

		protected override void OnUpdate()
		{
			float delta_time = Time.deltaTime;
			foreach ( var entity in GetEntities<group>() )
			{
				Vector3 desire_velocity = entity.motor.desire_velocity;
				entity.rigidbody.velocity = desire_velocity;
				entity.motor.current_speed = desire_velocity;
			}
		}
	}
}
