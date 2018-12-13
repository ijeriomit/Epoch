using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//namespace HealthHandler{ 

public class Respawn : MonoBehaviour {

		// Use this for initialization
	private Transform Player;
	public HealthHandler hp;
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			if (transform.position.y < -5) {
				respawn ();
			}
		}
		void respawn(){
			
		//transform.position = new Vector3 (0, 2, 0);
		hp.respawn ();

		}
	}
//}