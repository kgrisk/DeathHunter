using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopController : MonoBehaviour {
	GameObject FireWeapon;
	GameObject blueWeapon;

	public GameObject panel;

	public Text FireText;
	public Text blueText;

	public Button Fire;
	public Button blue;
	void Start(){
		FireWeapon = PlayerStats.instance.transform.GetChild(0).Find ("FireGun").gameObject;

		blueWeapon = PlayerStats.instance.transform.GetChild(0).Find ("BlueGun").gameObject;
	}
	// Use this for initialization
	void OnTriggerEnter(Collider other){
		panel.SetActive (true);
		if (FireWeapon.activeSelf) {
			FireText.text = "bought";
			Fire.interactable = false;
		}
		if (blueWeapon.activeSelf) {
			blueText.text = "bought";
			blue.interactable = false;
		}
	}

	void OnTriggerExit(Collider other){
		panel.SetActive (false);
	}

	public void BuyFireBullet(){
		if (PlayerStats.instance.GetGold () >= 60) {
			PlayerStats.instance.SetGold (-60);
			FireText.text = "bought";
			Fire.interactable = false;
			FireWeapon.SetActive (true);
		}
		Debug.Log ("pressed");
	}

	public void BuyBlueBullet(){
		if (PlayerStats.instance.GetGold () >= 60) {
			PlayerStats.instance.SetGold (-60);
			blueText.text = "bought";
			blue.interactable = false;
			blueWeapon.SetActive (true);

		}
	}
}
