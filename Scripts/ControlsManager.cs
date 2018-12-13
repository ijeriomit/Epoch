using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsManager : MonoBehaviour {
	public Text text;
	public Image panel;
	public bool display;
	// Use this for initialization
	void Start () {
		text.color = Color.clear;
		panel.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Tab)) {
			display = true;
		} else if (Input.GetKeyUp (KeyCode.Tab)) {
			display = false;
		}

		if (display) {
			text.color = Color.black;
			panel.color = Color.white;
		} else {
			text.color = Color.clear;
			panel.color = Color.clear;
		}
	}

}
