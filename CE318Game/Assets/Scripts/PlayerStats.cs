using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
	public static PlayerStats instance;
	private int gold = 0;
	// Use this for initialization
	public GameObject[] Weapons;
	public float hp;
	public PlayerHealthManager phm;
	public Text goldText;
	public int gameMode = 1;
	public void Awake(){
		DontDestroyOnLoad(gameObject);
		if(instance == null)
			instance = this;
		else
			DestroyObject(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		hp = phm.currentHealth;	
	}
	public void SetGold(int goold){
		Debug.Log (this.gold);
		this.gold =this.gold + goold;
		goldText.text = "Gold: " + this.gold;
	}
	public void ResetGold(int goold){
		Debug.Log (this.gold);
		this.gold =goold;
		goldText.text = "Gold: " + this.gold;
	}
	public int GetGold(){
		return this.gold;
	}
	public void BuyWeapon(int nr){
		Weapons [nr].SetActive(true);
	}
	public GameObject[] GetActiveWeapons(){
		return Weapons;
	}
	public void SetHp(float hp){
		phm.currentHealth = hp;
		this.hp = hp;
		phm.UpdateHealthbar ();
	}
	public float GetHp(){
		return phm.currentHealth;
	}
		
}
