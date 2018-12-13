using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_scene : MonoBehaviour {

    public void OnCollisionEnter(Collision info)
    {
        if (info.gameObject.name.Equals("Player"))
        {

            Application.LoadLevel("boss");
        }
    }

}
