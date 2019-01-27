using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using chibi.motor.npc;

public class Enemy_attack : chibi.Chibi_behaviour
{
	public float distance_attack = 1f;
	public float attack_by_second = 2f;
	public float last_time_attack = 0f;
	public GameObject prefab_damage;

	public bool is_going_to_attack = false;

	public Vector3 attack_position
	{
		get {
			return new Vector3( 0, 0.5f, 0) + transform.position +
			( transform.forward.normalized * distance_attack );
		}
	}

	public void instance_damage()
	{
		if ( helper.game_object.comp.is_null( prefab_damage ) )
		{
			Debug.LogError( "un enemigo no tiene el prefab de danno" );
			return;
		}
		helper.instantiate._( prefab_damage, attack_position );
	}

	protected void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere( attack_position, 0.2f );
			
	}
}
