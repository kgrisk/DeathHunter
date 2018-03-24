using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
[System.Serializable]
public class SaveData {
	//class used for saving and loading to file
	public int gold;
	public float hp;
	public bool[] deadEnemies;
	public bool [] rooms;
	public int dificulty;
	public int level;
	public bool fireWeapon;
	public bool BlueWeapon;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

}
