using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * script responsible for players hp and demage
 * in levels it also checks if player is dead and 
 * finishes the level if yes
 */

public class PlayerHealthManager : MonoBehaviour {
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
	public void UpdateHealthbar(){
		
		float ratio = currentHealth / maximumHealth;
		currentHealthbar.rectTransform.localScale = new Vector3 (ratio, 1, 1);
	}
	private void ResetInvincible(){
		invincible = true;
	}
	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		currentHealth = maximumHealth;
		if (SceneManager.GetActiveScene ().buildIndex == 3) {
			TakeDemage (20);
			UpdateHealthbar ();
		}
	}

	// Update is called once per frame
	void LateUpdate () {
		if (currentHealth > maximumHealth) {
			currentHealth = maximumHealth;
			UpdateHealthbar ();
		}
		if ((currentHealth <= 0 )){
			anim.SetBool ("dead", true);
			dead = true;
			//GetComponent<EnemyController>().dead = true;
			//GetComponent<EnemyController> ().agent.velocity = Vector3.zero;
			currentHealth = 0;
			UpdateHealthbar ();
		}else{
			anim.SetBool ("dead", false);
		}
	}
	public void Die(){
		Invoke("Deactivate", 0.5f);

	}
	public void ResetHp(float hp){
		currentHealth = hp;
		UpdateHealthbar ();
	}
	private void Deactivate(){

		GetComponent<EnemyController>().dead = true;
	}
}
