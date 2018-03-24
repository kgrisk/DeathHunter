using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTheBullet : MonoBehaviour {
	public float timeUntilNextBullet;
	public Transform ShootPoint;
	public GameObject bullet;
	public bool equipted = false;
	float nextBullet;
	// Use this for initialization
	void Start () {
		nextBullet = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0) && nextBullet < Time.time && equipted){
			nextBullet = Time.time + timeUntilNextBullet;
			Instantiate (bullet, ShootPoint.position, ShootPoint.rotation);
		}

	}
}
