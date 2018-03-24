using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {
	public float range = 10f;
	public int demage = 10;
	Ray shootRay;

	RaycastHit shootHit;
	int ShootableMask;
	LineRenderer gunLine;
	// Use this for initialization
	void Start () {
		ShootableMask = LayerMask.GetMask ("Shootable");
		gunLine = GetComponent<LineRenderer> ();
		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;
		gunLine.positionCount = 2;
		gunLine.startWidth = 0.025f;
		gunLine.endWidth = 0.025f;

		gunLine.SetPosition (0, transform.position);
		if (Physics.Raycast (shootRay, out shootHit, range, ShootableMask)) {
			gunLine.SetPosition (1, shootHit.point);


			shootHit.collider.transform.GetComponent<HealthManager> ().Demage (demage);

			
		} else
			gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
