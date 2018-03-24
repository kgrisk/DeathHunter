using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class MainMenu : MonoBehaviour {
	public GameObject difficultyEasy;
	public GameObject difficultyHard;
	public GameObject newGameButton;

	public GameObject menuPanel;
	public GameObject OptionsPanel;
	public void Tutorial(){
		SceneManager.LoadScene (3);
	}
	public void Update(){
		if (PlayerStats.instance != null) {
			Destroy (GameObject.Find ("Player").gameObject);
			Destroy (GameObject.Find ("HeathCanvas").gameObject);
		}
	}
	public void NewGame(){
		difficultyEasy.SetActive (true);
		difficultyHard.SetActive (true);
		newGameButton.SetActive (false);

	}
	public void Dificulty(int hard){
		GameMode.instance.gameMode = hard;
		GameMode.instance.loadGame = false;
		SceneManager.LoadScene (1);
	}
	public void LoadGame(){
		string filename = Application.persistentDataPath + "/playerInfo.dat";
		if (File.Exists (filename)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (filename, FileMode.Open);
			SaveData sd = (SaveData) bf.Deserialize(file);
			file.Close ();
			GameMode.instance.gameMode = sd.dificulty;
			GameMode.instance.loadGame = true;
			SceneManager.LoadScene (sd.level);
		}else
		SceneManager.LoadScene (1);
	}
	public void Options(){
		menuPanel.SetActive (false);
		OptionsPanel.SetActive (true);
	}
	public void BackToMainMenu(){
		menuPanel.SetActive (true);
		OptionsPanel.SetActive (false);
	}
	public void Quit(){
		Application.Quit ();
	}
}
