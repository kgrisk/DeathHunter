using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
public class LevelManger : MonoBehaviour {
	public GameObject[] Enemies;
	GameObject FireWeapon;
	GameObject blueWeapon;
	// Use this for initialization
	public GameObject[] rooms;

	public bool levelCleared;
	public bool TurnItOf;
	public GameObject levelClearedText;
	private GameMode gM;
	public GameObject DyingWindow;
	void Start () {
		FireWeapon = PlayerStats.instance.transform.GetChild(0).Find ("FireGun").gameObject;

		blueWeapon = PlayerStats.instance.transform.GetChild(0).Find ("BlueGun").gameObject;
		gM = GameObject.FindGameObjectWithTag ("gameinfo").GetComponent<GameMode>();
		if (gM.loadGame) {
			Load ();
			gM.loadGame = false;

		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && levelCleared)
			TurnItOf = true;
		if (!levelCleared) {
			for (int i = 0; i < rooms.Length; i++) {
				if (!rooms [i].GetComponentInChildren<RoomControl> ().roomFinished)
					break;
				if (i == rooms.Length - 1) {
					levelCleared = true;
					TurnItOf = false;
				}
			}
				
		}
		if (levelCleared && !TurnItOf) {
			levelClearedText.SetActive (true);
		}else if(levelCleared && TurnItOf)
			levelClearedText.SetActive(false);
		
		if (PlayerStats.instance.GetHp () <= 0f)
			DyingWindow.GetComponent<Animator> ().SetTrigger ("Die");
		if(levelCleared && SceneManager.GetActiveScene ().buildIndex == 2)
			DyingWindow.GetComponent<Animator> ().SetTrigger ("Win");
	}


	public void Save () {
		string filename = Application.persistentDataPath + "/playerInfo.dat";
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (filename,FileMode.OpenOrCreate);
		SaveData sd = new SaveData ();
		sd.level = SceneManager.GetActiveScene().buildIndex;
		Debug.Log (sd.level);
		sd.gold = PlayerStats.instance.GetGold ();
		sd.hp = PlayerStats.instance.hp;
		sd.deadEnemies = new bool[Enemies.Length];
		for(int i = 0; i< Enemies.Length;i++){
			sd.deadEnemies [i] = Enemies [i].GetComponent<HealthManager> ().dead;			
		}
		sd.rooms = new bool[rooms.Length];
		for(int i = 0;i< rooms.Length;i++)
			sd.rooms[i] = rooms[i].GetComponentInChildren<RoomControl> ().roomFinished;
		sd.fireWeapon = FireWeapon.activeSelf;
		sd.BlueWeapon = blueWeapon.activeSelf;
		sd.dificulty = GameMode.instance.gameMode;
		bf.Serialize (file,sd);
		file.Close ();
	}
	public void Load () {
		string filename = Application.persistentDataPath + "/playerInfo.dat";
		if (File.Exists (filename)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (filename, FileMode.Open);
			SaveData sd = (SaveData) bf.Deserialize(file);
			file.Close ();
			PlayerStats.instance.ResetGold (sd.gold);
			PlayerStats.instance.SetHp (sd.hp);

			for (int i = 0; i < Enemies.Length; i++) {
				Enemies [i].GetComponent<HealthManager> ().dead = sd.deadEnemies [i];
				if (Enemies [i].GetComponent<HealthManager> ().dead) {
					Enemies [i].GetComponent<HealthManager> ().currentHealth = 0;
					PlayerStats.instance.SetGold (-10);
					Enemies [i].GetComponent<Animator> ().SetBool ("dead", true);
				}
			}
			for (int i = 0; i < rooms.Length; i++) {
				rooms[i].GetComponentInChildren<RoomControl> ().roomFinished = sd.rooms[i];
				if (rooms[i].GetComponentInChildren<RoomControl> ().roomFinished) {
					rooms[i].GetComponentInChildren<RoomControl> ().Rock.SetActive (true);
				}

				FireWeapon.SetActive (sd.fireWeapon);
				blueWeapon.SetActive (sd.BlueWeapon);
				GameMode.instance.gameMode = sd.dificulty;
			}
		}
	}
}
