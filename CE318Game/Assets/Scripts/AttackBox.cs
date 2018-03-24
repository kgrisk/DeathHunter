using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AttackBox : MonoBehaviour {
	
	public int demage;
	void Update(){
		if (GetComponent<BoxCollider> ().enabled) {
			transform.parent.GetComponent<NavMeshAgent> ().velocity = Vector3.zero;
			GetComponent<AudioSource> ().time = 1;
			GetComponent<AudioSource> ().Play();
		}
	}
	void OnTriggerEnter(Collider other){
		
		if ( other.CompareTag("Player")) {
			other.GetComponent<PlayerHealthManager> ().Demage (demage * GameMode.instance.gameMode);

			if(gameObject.CompareTag("Bullet"))
				Destroy (gameObject);
		}
	}
}
