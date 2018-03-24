using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public Vector3 movement;
	public float speed;
	Rigidbody rgb;
	int groundMask;
	Animator anim;
	float rayLenghtToCamera = 100f;
	bool accelerate = false;
	public bool accelerateEnabled = true;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rgb = GetComponent<Rigidbody> ();
	}
	void Update(){
		
			
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.LeftShift) && accelerateEnabled) {
			accelerate = true;
		} else
			accelerate = false;
		groundMask = LayerMask.GetMask ("Ground");
		movement = new Vector3 (Input.GetAxis("Horizontal") * speed,0,Input.GetAxis("Vertical") * speed);

		if (accelerate)
			movement = movement * 2;
		anim.SetFloat ("speed",Mathf.Abs(movement.magnitude));
		rgb.velocity = movement;
		playerDirection ();
	}
	void playerDirection(){
		Ray rayToGround = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		if(Physics.Raycast(rayToGround, out floorHit, rayLenghtToCamera ,groundMask)){

			Vector3 playerToPoint = floorHit.point - transform.position;
			playerToPoint.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation (playerToPoint);
			rgb.MoveRotation(newRotation);
		}
	}
}
