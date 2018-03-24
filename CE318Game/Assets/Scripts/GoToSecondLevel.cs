using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToSecondLevel : MonoBehaviour {
	public LevelManger lm;

	public GameObject showMission;
	public GameObject showFinishText;
	// Use this for initialization
	bool teleportation;
	void Start () {
		
	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.Space) && lm.levelCleared)
			teleportation = true;
		else teleportation = false;
	}
	
	// Update is called once per frame
	void OnTriggerStay(Collider other){
		if (lm.levelCleared) {
			showFinishText.SetActive (true);
			if (teleportation)
				SceneManager.LoadScene (2);
		} else
			showMission.SetActive (true);
	}
	void OnTriggerExit(Collider other){
		
			showFinishText.SetActive (false);
			showMission.SetActive (false);
	}
}
