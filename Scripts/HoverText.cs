using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverText : MonoBehaviour {
	public string myString;
	public Text myText;
	public bool displayInfo;
	public Image panel;

	// Use this for initialization
	void Start () {
		//myText = GameObject.Find ("Text").GetComponent<Text> ();
		myText.text = myString;
		myText.color = Color.clear;
		panel.color = Color.clear;
		panel.raycastTarget = false;

	}
	
	// Update is called once per frame
	void Update () {
		toggleText ();
	}
	public void onHover(){
		displayInfo = true;

	}
	public void onUnhover(){
		displayInfo = false;
	}
	void toggleText(){
		if (displayInfo) {
			myText.color = Color.black;
			panel.color = Color.white;
		} else {
			myText.color = Color.clear;
			panel.color = Color.clear;
		}
	}
}
