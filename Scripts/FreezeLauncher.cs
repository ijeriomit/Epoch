using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeLauncher : MonoBehaviour {

	public GameObject projectile;
	public Movement player;
	public Freeze ice;
	public CoolDown coolDown;
	//private float timeForCoolDown = 0.4f;
	// Use this for initialization
	void Start () {
	}

	void makeProjectile(int direction, float area)
	{
		GameObject bul = Instantiate (projectile, transform.position + new Vector3 (area, 0, 0), Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
