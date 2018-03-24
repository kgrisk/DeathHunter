using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour {
	public bool playerInRange = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerExit(Collider other){
		if (other.CompareTag("Player")) {
			playerInRange = false;
			Debug.Log ("see ya");
		}

	}
	void OnTriggerEnter(Collider other){
		
		if (other.CompareTag("Player")) {
			playerInRange = true;
		} 

	}
}
