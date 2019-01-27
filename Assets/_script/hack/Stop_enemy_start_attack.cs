using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using chibi.motor.npc;

public class Stop_enemy_start_attack : chibi.Chibi_behaviour
{

	protected void OnTriggerEnter( Collider other )
	{
		if ( other.tag == helper.consts.tags.enemy )
		{
			var motor = other.gameObject.GetComponent<Motor_isometric>();
			motor.stop = true;
			var attack = other.GetComponent< Enemy_attack >();
			attack.is_going_to_attack = true;
		}
	}

	protected void OnDrawGizmos()
	{
		var collider = GetComponent<BoxCollider>();
		Matrix4x4 rotationMatrix = Matrix4x4.TRS(
			transform.position, transform.rotation, transform.lossyScale );
		Gizmos.matrix = rotationMatrix;
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube( collider.center, collider.size );
	}
}
