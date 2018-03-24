using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			other.GetComponent<PlayerHealthManager> ().currentHealth = other.GetComponent<PlayerHealthManager> ().currentHealth + 10;
			other.GetComponent<PlayerHealthManager> ().UpdateHealthbar ();
			Destroy (gameObject);
		}
	}
}
