using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class InGameMenu : MonoBehaviour {
	public GameObject otherCanvas;
	public GameObject blackening;
	public Text saveText;
	public GameObject menuPanel;
	public GameObject OptionsPanel;
	public LevelManger lm;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			menuPanel.SetActive (true);
			Time.timeScale = 0f;
			saveText.text = "SAVE";
			otherCanvas.SetActive (false);
			blackening.SetActive (false);
		}
	}
	public void Resume(){
		menuPanel.SetActive (false);
		blackening.SetActive (true);
		otherCanvas.SetActive (true);
		Time.timeScale = 1f;
	}
	public void save(){
		lm.Save ();
		saveText.text = "SAVED";
	}

	public void Options(){
		menuPanel.SetActive (false);
		OptionsPanel.SetActive (true);
	}
	public void BackToMainPage(){
		menuPanel.SetActive (true);
		OptionsPanel.SetActive (false);
	}
	public void BackToMainMenu(){
		otherCanvas.SetActive (true);
		blackening.SetActive (true);
		Time.timeScale = 1f;
		SceneManager.LoadScene (0);
	}
	// Use this for initialization
	void Start () {
		
	}
	

}
