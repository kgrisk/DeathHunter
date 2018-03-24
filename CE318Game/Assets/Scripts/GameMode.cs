using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour {
	//is set from canvas giving it different values and having it procced through the all game
	public int gameMode;
	public bool loadGame;
	public static GameMode instance;
	public void Awake(){
		DontDestroyOnLoad(gameObject);
		if(instance == null)
			instance = this;
		else
			DestroyObject(gameObject);
	}
}
