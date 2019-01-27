using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giroTorreta : MonoBehaviour
{
	public Rigidbody rb;
	public KeyCode derecha;
	public KeyCode izquierda;
	public KeyCode disparar;
	
	//public GameObject disparo;
	public AudioClip adisparo;
	
	public Transform position;

	public chibi.motor.weapons.gun.controller.Turrent_controller controller;

	public GameObject disparo;


	void FixedUpdate()
	{
		/*
		//if (colocado en torreta){
		if ( Input.GetKey( derecha ) )
		{
			transform.Rotate( 0, Time.deltaTime * 100.0f, 0 );
		}
		if ( Input.GetKey( izquierda ) )
		{
			transform.Rotate( 0, Time.deltaTime * -100.0f, 0 );
		}
		if(Input.GetKeyDown(disparar)){
			GetComponentInChildren<weapon.gun.Linear_gun>().shot();
			clip1();
		if ( Input.GetKeyDown( disparar ) )
		{
			//disparo.SetActive(true);
			//disparo.SetActive(false);
		}
		//}
		*/
	}

	public void turn( Vector3 direction )
	{
		if ( direction == Vector3.zero )
			return;
		float sign = Mathf.Sign( direction.x );
		if ( sign > 0 )
			transform.Rotate( 0, Time.deltaTime * 100.0f, 0 );
		else if ( sign < 0 )
			transform.Rotate( 0, Time.deltaTime * -100.0f, 0 );
	}

	public void shot()
	{
		GetComponentInChildren<weapon.gun.Linear_gun>().shot();
		clip1();
	}

	void OnTriggerEnter( Collider other )
	{
		if ( other.gameObject.tag == helper.consts.tags.player )
		{
			Debug.Log( "Colision con torreta" );
			var player = other.gameObject.GetComponent<
				chibi.controller.npc.Controller_player >();
			player.turrent = this;
		}
	}

	void OnTriggerExit( Collider other )
	{
		if ( other.gameObject.tag == helper.consts.tags.player )
		{
			Debug.Log( "salio de la torreta" );
			var player = other.gameObject.GetComponent<
				chibi.controller.npc.Controller_player >();
			player.turrent = null;
		}
	}
	
	void clip1 () {
		AudioSource.PlayClipAtPoint(adisparo, new Vector3(0, 25, 0), 0.75f);
	}
	
	
}
