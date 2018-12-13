using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

	//public HealthHandler Player;
	void OnTriggerEnter(Collider info){
		if(info.name.Equals("Player")){
			//print ("touchie");
			//Player.heal();
			gameObject.SetActive(false);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
