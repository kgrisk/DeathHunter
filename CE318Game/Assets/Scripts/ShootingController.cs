using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour {
	public GameObject[] Weapons;
	// Use this for initialization
	public GameObject weapon;

	public static int equipted;
	void Start () {
		weapon = Weapons[0];
		equipted = 0;
		weapon.GetComponent<ShootTheBullet> ().equipted = true;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject temporary = null;
		if (Input.GetKeyDown (KeyCode.E)) {
			weapon.GetComponent<ShootTheBullet> ().equipted = false;
			for (int i = equipted + 1; i < Weapons.Length; i++) {
				if (Weapons [i].activeSelf) {
					temporary = Weapons [i];
					equipted = i;
					break;
				}
			}
			if (temporary != null) {
				weapon = temporary;
			} else {
				weapon = Weapons [0];
				equipted = 0;
			}
			weapon.GetComponent<ShootTheBullet> ().equipted = true;

		}	
	}
}
