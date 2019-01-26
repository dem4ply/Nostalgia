using UnityEngine;
using Unity.Entities;
using chibi.motor.behavior;

namespace chibi.systems.motor.behavior
{
	public class Look_at : ComponentSystem
	{
		struct group
		{
			public chibi.motor.behavior.Look_at behavior;
			public Transform transform;
		}

		protected override void OnUpdate()
		{
			float delta_time = Time.deltaTime;
			foreach ( var entity in GetEntities<group>() )
			{
				var look_at = entity.behavior;
				Vector3 desire_direction = look_at.desire_direction;
				Quaternion rotation = Quaternion.LookRotation( desire_direction );
				entity.transform.rotation = rotation;
			}
		}
	}
}
