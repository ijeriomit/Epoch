using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

    public float fire_rate = 0;
    public float Damage = 5;
    public LayerMask NotToHit;
    public Movement FP;

    float TimeToFire = 0;
    Transform firePoint;
    // Use this for initialization
    void Awake()
    {

        firePoint = FP.transform;
        if (firePoint == null)
        {
            Debug.LogError("no firepoint");

        }
    }
	// Update is called once per frame
	void Update () {
	    //if (fire_rate==0)
        //{
            //if (Input.GetKey(KeyCode.Q))
            //{
                Shoot();
            //}
        //}
	}
    void Shoot()
    {
        Vector2 MousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        print(Input.mousePosition);
        Vector2 FirePosition = firePoint.position; //new Vector2(firePoint.position.x, firePoint.position.y);
        //print(FirePosition);
        RaycastHit2D hit = Physics2D.Raycast(FirePosition, MousePosition - FirePosition, 100 ,NotToHit);
        //Debug.DrawLine(firePoint.position, (MousePosition*20));
        Debug.DrawRay(firePoint.position, Input.mousePosition - firePoint.position);
    }
}


