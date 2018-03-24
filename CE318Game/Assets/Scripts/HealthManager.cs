using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
	public Image currentHealthbar;
	public float currentHealth;
	public float maximumHealth;
	public float timeForInvincible;
	private static bool invincible = true;

	public bool dead = false;
	private Animator anim;
	public void Demage(int demage){
		if (invincible && !dead) {
			TakeDemage (demage);
		}
	}
	private void TakeDemage(int demage){
		currentHealth = currentHealth - demage;
		invincible = false;
		Invoke ("ResetInvincible", timeForInvincible);
		UpdateHealthbar ();
	}
	private void UpdateHealthbar(){
		float ratio = currentHealth / maximumHealth;
		currentHealthbar.rectTransform.localScale = new Vector3 (ratio, 1, 1);
	}
	private void ResetInvincible(){
		invincible = true;
	}
	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		maximumHealth = maximumHealth * GameMode.instance.gameMode;
		currentHealth = maximumHealth;

		UpdateHealthbar ();
	}

	// Update is called once per frame
	void LateUpdate () {
		if ((currentHealth <= 0 ) && !dead){
			anim.SetBool ("dead", true);
			dead = true;

			currentHealth = 0;
			UpdateHealthbar ();
		}else if(currentHealth > 0){
			dead =false;

			anim.SetBool ("dead", false);
		}
	}
	public void Die(){
		Invoke("Deactivate", 0.5f);

	}
	private void Deactivate(){
		
		dead = true;
	}
}