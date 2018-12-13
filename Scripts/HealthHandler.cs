using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHandler : MonoBehaviour {

	//public Text hpText;
	public PlayerInfo playerInfo;
	public Movement playerPos;
	public Slider healthSlider;
	public Slider manaSlider;
	public int maxHP;
	public int curHP;
	public int maxMana;
	public int curMana;
	public float manaRegen = 10.0f;

	void OnTriggerEnter(Collider collisionInfo){
		if(collisionInfo.gameObject.CompareTag("HPickup")){
			playerPos.SFX.PlayOneShot (playerPos.pickupSFX);
			heal();
			//print ("shoop");
		}
		if (collisionInfo.gameObject.CompareTag ("ManaPickup")) {
			playerPos.SFX.PlayOneShot (playerPos.pickupSFX);
			addMana ();
		}
	}
	// Use this for initialization
	void Start () {
		
		maxHP = 10 + PlayerPrefs.GetInt ("fort")*2; //set the max hp value for slider.
		healthSlider.maxValue = maxHP; //playerInfo.getMaxHP();  //get the max hp slider value


		curHP = maxHP; //set the current hp to the max possible HP at the start
		healthSlider.value = curHP; //set the sliders value to the current hp
		healthSlider.minValue = 0; //min value = 0...
		playerInfo.hptext.text = curHP + "/" + maxHP;


		maxMana = 2 + PlayerPrefs.GetInt ("spell");
		manaSlider.maxValue = maxMana;

		curMana = maxMana;
		manaSlider.value = curMana;
		manaSlider.minValue = 0;
		playerInfo.manatext.text = curMana + "/" + maxMana;
	}
	// Update is called once per frame
	void Update () {
		if (getMana () < maxMana) {
			manaRegen -= Time.deltaTime;

			if (manaRegen <= 0.0f) {
				manaRegen = 10.0f;
				timerEnded ();
			}
			playerInfo.manatext.text = curMana + "/" + maxMana;
		}

	}
	void timerEnded()
	{
		addMana ();
	}
	public void useMana(int x){
		if (curMana <= 0) {
			curMana = 0;
		} else {
			curMana = curMana - x;
			manaSlider.value = curMana;
		}
		playerInfo.manatext.text = curMana + "/" + maxMana;
	}

	public int getMana(){
		return curMana;
	}

	public void addMana(){
		if (curMana >= maxMana)
			curMana = maxMana;
		else {
			curMana += 1;
			print (curMana);
			manaSlider.value = curMana;
		}
		playerInfo.manatext.text = curMana + "/" + maxMana;
	}

	public void takeDamage(){
		playerPos.SFX.PlayOneShot (playerPos.damageSFX);
		curHP = curHP - 1; //decrement health upon taking damage 
		playerInfo.hptext.text = curHP + "/" + maxHP;
		if (curHP <= 0) {
			curHP = 0;
			respawn (); //respawn when you hit 0
		}

		//regenerate ();


		healthSlider.value = curHP;//reset 
	}
	public void respawn(){
		playerPos.transform.position = new Vector3 (0, 2, 0);
		curHP = maxHP;
		healthSlider.value = curHP;
		curMana = maxMana;
		manaSlider.value = curMana;
		playerInfo.hptext.text = curHP + "/" + maxHP;
	}
	public void regenerate(){
		if (curHP < maxHP) {
			curHP += 1;
		}
	}
	public void heal(){
		if (curHP >= maxHP)
			curHP = maxHP;
		else{
			curHP += 1;
			healthSlider.value = curHP;
		}
		playerInfo.hptext.text = curHP + "/" + maxHP;
	}
}