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
	
	void FixedUpdate()
    {
		//if (colocado en torreta){
        if(Input.GetKey(derecha)){
			transform.Rotate(0, Time.deltaTime * 100.0f, 0);
		}
		if(Input.GetKey(izquierda)){
			transform.Rotate(0, Time.deltaTime * -100.0f, 0);
		}
		if(Input.GetKeyDown(disparar)){
			GetComponentInChildren<weapon.gun.Linear_gun>().shot();
			clip1();
			//disparo.SetActive(true);
			//disparo.SetActive(false);
		}
		//}
	}
	void OnTriggerEnter (Collider other) {
		if(other.gameObject.tag=="Player")
		{
			Debug.Log("Colision con torreta");
		}
		
	}
	
	void clip1 () {
		AudioSource.PlayClipAtPoint(adisparo, new Vector3(0, 25, 0), 0.75f);
	}
	
	
}
