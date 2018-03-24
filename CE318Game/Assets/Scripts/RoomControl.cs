using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour {
	public GameObject Rock;
	bool startRoom =false;
	// Use this for initialization
	public GameObject[] Enemies;
	public bool roomFinished = false;
	void Start () {
		
	}
	
	public void Update(){
		if (startRoom) {
			foreach (GameObject enemy in Enemies) {
				if (enemy.GetComponent<HealthManager>().dead == true) {
					roomFinished = true;
				} else {
					roomFinished = false;
					break;
				}
			}if (roomFinished) {
				Rock.SetActive (false);
			}

		}
	}
	void OnTriggerEnter(Collider other){

		if (!startRoom) {
			Rock.SetActive (true);
			startRoom = true;
			SpawnEnemies ();
		}
	}
	void SpawnEnemies(){
		foreach (GameObject enemy in Enemies) {
			enemy.SetActive(true);
		}
	}
}
