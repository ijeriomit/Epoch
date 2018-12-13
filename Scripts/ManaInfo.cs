using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaInfo : MonoBehaviour {
	
	//public HealthHandler Player;
	void OnTriggerEnter(Collider info){
		if (info.name.Equals ("Player")) {
			//Player.addMana();
			gameObject.SetActive (false);
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

}
