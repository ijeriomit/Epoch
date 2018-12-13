using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDown : MonoBehaviour {

    private float timeStamp;
    //private float coolDowntime;
	// Use this for initialization
	void Start () {
        timeStamp = Time.time;
	}
	public bool canUse(float currentTime)
    {
        if (timeStamp<= currentTime)
        {
            return true;
        }

        return false;

    }
    public void addTime(float currentTime, float coolDowntime)
    {
        timeStamp = currentTime + coolDowntime;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
