using UnityEngine;
using Unity.Entities;
using chibi.motor;

namespace chibi.systems.animator
{
	public class Animator_player_0 : ComponentSystem
	{
		struct group
		{

			public chibi.motor.animator.Player_0 animator;
			public chibi.motor.npc.Motor_isometric motor;
		}

		protected override void OnUpdate()
		{
			foreach ( var entity in GetEntities<group>() )
			{
				entity.animator.animator.SetFloat(
					"speed", entity.motor.current_speed.magnitude );

				entity.animator.animator.SetBool(
					"isTurret", entity.animator.is_turrent );
			}
		}
	}
}
