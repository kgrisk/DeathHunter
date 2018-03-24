using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraFollowFixed : MonoBehaviour {
	Vector3 position1 = new Vector3(17.6f,0f,15f);
	Vector3 position2 = new Vector3 (209.2f,0f,171.5f);
	Vector3 position3 = new Vector3 (30.9f,0.1f,54.2f);
	Transform target;
	Vector3 offset;
	float smoothing = 5f;
	// Use this for initialization
	void Start () {
		
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		if (SceneManager.GetActiveScene ().buildIndex == 1) {
			target.position = position1;
			GetComponent<Animator> ().applyRootMotion = true;
		} else if (SceneManager.GetActiveScene ().buildIndex == 2) {
			target.position = position2;
			GetComponent<Animator> ().applyRootMotion = true;
		}
		else target.position = position3;
		offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos,smoothing * Time.deltaTime);
	}
}
