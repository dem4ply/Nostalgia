using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giroTorreta : MonoBehaviour
{	
	public Rigidbody rb;
	public KeyCode derecha;
	public KeyCode izquierda;
	public KeyCode disparar;
	
	public GameObject disparo;
	
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
	
	
}
