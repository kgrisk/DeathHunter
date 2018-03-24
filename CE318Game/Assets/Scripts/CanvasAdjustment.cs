using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAdjustment : MonoBehaviour {
	GameObject obj;
	Quaternion rotation;
	// Use this for initialization
	void Start () {
		obj = GetComponentInChildren < Canvas> ().gameObject;
		rotation = obj.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		obj.transform.rotation = rotation;
	}
}
