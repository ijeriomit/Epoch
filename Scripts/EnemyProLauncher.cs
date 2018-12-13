using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProLauncher : MonoBehaviour {
	public GameObject projectile;
	public Projectile pro;
	public AI enemy;
	public Stun stun;
	public CoolDown coolDown;
	private float timeforCoolDown = 1.5f;
	private float enemyPo;
    private Animator anim;
	// Use this for initialization

	void Start () {
        
	}
	void makeProjectile(int direction, float area)
	{
        enemy.isShooting = true;
        //updateDirection(direction);
        //enemy.callShootingAnimation();
        GameObject bul = Instantiate(projectile, transform.position + new Vector3(area, 0, 0), Quaternion.identity) as GameObject;
		bul.transform.Translate(direction, 0, 0);
        //enemy.isShooting = false;
        //enemy.callShootingAnimation();
    }
    void updateDirection(int direction)
    {
        if((enemy.dirRight == true)&&(direction == -1)||(enemy.dirRight == false)&&(direction == 1))
        {
            enemy.changeDirection();
        }
    }
	// Update is called once per frame
	void Update () {
		enemyPo = enemy.rb.position.x; 
		if (coolDown.canUse (Time.time) && enemy.Inrange(10)) {// && !stun.isStun) {
			//if (Input.GetKey (KeyCode.T)) {
				// bul.SetActive(true);
				if (enemyPo - enemy.playerPosition.transform.position.x < 0) {
					pro.setSpeed (true);
					makeProjectile (1, 1.5f);
				} else {
					pro.setSpeed (false);
					//print (pro.projectileSpeed);
					makeProjectile (-1, -1.5f);
				}
				coolDown.addTime (Time.time, timeforCoolDown);
			}
		//}
	}

}
