using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour {

    public void exit_open()
    {
        Application.Quit();
    }
	void Update(){
		if(Input.GetKey(KeyCode.Escape))
			exit_open();
	}

}
