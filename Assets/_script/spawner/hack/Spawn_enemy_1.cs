using UnityEngine;
using System.Collections.Generic;

namespace spawner
{
	public class Spawn_enemy_1 : chibi_base.Chibi_behaviour
	{
		public GameObject objects;
		public List< GameObject > target;

		public virtual GameObject spawn()
		{
			if ( helper.game_object.comp.is_null( objects ) )
			{
				Debug.LogError( "el spawn no tiene object" );
				return null;
			}
			var result = _instance( objects );
			return result;
		}

		protected virtual GameObject _instance( GameObject obj )
		{
			var collider = GetComponent<BoxCollider>();
			var max = collider.bounds.max;
			var min = collider.bounds.min;
			var position = new Vector3(
				Random.Range( min.x, max.x ),
				Random.Range( min.y, max.y ),
				Random.Range( min.z, max.z )
			);
			var result = helper.instantiate._( obj, position );
			var seek = result.GetComponent<
				chibi.motor.behavior.steering.Seek >();
			int pos = new System.Random().Next( 0, target.Count );
			seek.target = target[ pos ];
			return result;
		}

		protected void OnDrawGizmos()
		{
			var collider = GetComponent<BoxCollider>();
			Matrix4x4 rotationMatrix = Matrix4x4.TRS(
				transform.position, transform.rotation, transform.lossyScale );
			Gizmos.matrix = rotationMatrix;
			Gizmos.color = Color.cyan;
			Gizmos.DrawWireCube( collider.center, collider.size );
		}
	}
}