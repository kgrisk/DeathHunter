using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {
	bool walk;
	bool run;
	bool shoot;
	bool changeWeapon;
	bool pickUp;
	// Use this for initialization
	public GameObject walkText;
	public GameObject runText;
	public GameObject shootText;
	public GameObject changeGunText;
	public GameObject pickUpText;
	public GameObject smallCollider;
	public GameObject pickUpObj;
	public Animator anim;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!walk) {
			if ((Input.GetAxis ("Horizontal") > 0 || Input.GetAxis ("Vertical") > 0)) {
				walk = true;
				walkText.SetActive (false);
				runText.SetActive (true);
			}
		} else if (!run) {
			if ((Input.GetAxis ("Horizontal") > 0 || Input.GetAxis ("Vertical") > 0) && Input.GetKey (KeyCode.LeftShift)) {
				run = true;
				runText.SetActive (false);
				shootText.SetActive (true);
			}
		} else if (!shoot) {
				if (Input.GetMouseButton (0) || Input.GetKeyDown (KeyCode.F)) {
					shoot = true;
					shootText.SetActive (false);
					changeGunText.SetActive (true);
				}
		}else if (!changeWeapon) {
					if (Input.GetKey (KeyCode.E)) {
						changeWeapon = true;
						changeGunText.SetActive (false);
						pickUpText.SetActive (true);
				smallCollider.GetComponent<BoxCollider> ().enabled = false;		
		}
		}else if (!pickUp) {
			if (pickUpObj == null) {
				anim.SetTrigger("Die");
				pickUpText.SetActive (false);
			}
		}

	}

}
