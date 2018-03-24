﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

	public static DontDestroy instance;
	public void Awake(){
		DontDestroyOnLoad(gameObject);
		if(instance == null)
			instance = this;
		else
			DestroyObject(gameObject);
	}
}
