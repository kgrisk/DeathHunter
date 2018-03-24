using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttackBox : MonoBehaviour {

	public int demage;

	void OnTriggerEnter(Collider other){

		if ( other.CompareTag("Enemy")) {
			other.GetComponent<HealthManager> ().Demage (demage);
			if(gameObject.CompareTag("Bullet"))
				Destroy (gameObject);
		}
	}
}
