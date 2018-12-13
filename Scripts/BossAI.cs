using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour {

	private Transform enemyT;
	//private Rigidbody enemyR;
	private BossAI enemy;

	private bool seesPlayer,isMoving,isIdle,isStun;
	private CoolDown timeForCool1,timeForCool2,proCoolDown;

	public SpriteRenderer capsule;
	public BossStun stun;
	public float pos;
	//public bool facingRight;
	public Movement playerPosition;
	public BossHealth health;
	public GameObject projectile;
	public Projectile pro;
	public PlayerInfo player; //use to grab info regarding player such as AttackPower
	public const int speed = 4; //changed speed to constant 
	public int newSpeed = speed, hp = 60, wandBonus, swordBonus; //created newspeed variable and update this instead of speed var which should stay constant.

	void OnTriggerEnter(Collider collisionInfo)
	{

		if(collisionInfo.gameObject.CompareTag("Projectile"))
		{
			health.takeDamage(player.GetAttackPower() * player.spell + wandBonus);
			print("hurt");
		}
		if (collisionInfo.gameObject.CompareTag ("Freeze")) 
		{
			health.takeDamage (player.GetAttackPower ());
            stun.startStun();

		}

		/*print("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
		print("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
		print("Their relative velocity is " + collisionInfo.relativeVelocity);*/
	}
	// Use this for initialization
	void Start () {
		pos = transform.position.x;
		capsule.enabled = false;
		enemy = GetComponent<BossAI> ();
		enemyT = GetComponent<Transform> ();
		//enemyR = GetComponent<Rigidbody> ();
		isStun = false;

		seesPlayer = false;
		isMoving = false;
		isIdle = false;
		timeForCool1 = GetComponent<CoolDown>();
		timeForCool2 = GetComponent<CoolDown>();
		proCoolDown = GetComponent<CoolDown>();

		if (PlayerPrefs.GetString ("hasWand") == "true") {
			wandBonus = 1;
		} else
			wandBonus = 0;
		if (PlayerPrefs.GetString ("hasSword") == "true") {
			swordBonus = 1;
		} else
			swordBonus = 0;
	}
	void knockBack() //code will eventually knockback eniemes
	{
		//enemyT.transform.Translate(direction * Time.deltaTime * newSpeed);
	}
		
	// Update is called once per frame
	public void SetStun(bool stun)
	{
		isStun = stun;
	}
	void makeProjectile(Vector3 direct, float area)
	{
		GameObject bul = Instantiate(projectile, transform.position + new Vector3(area, 0, 0), Quaternion.identity) as GameObject;
		bul.transform.Translate(direct); //check this
	}
	void Update()
	{

		if (Input.GetKeyDown(KeyCode.P))
		{
			print (enemy.transform.position);
			if (playerPosition.facingRight)
				Debug.DrawLine(playerPosition.transform.position, playerPosition.transform.position + new Vector3(4, 0, 0), Color.red);
			else if (playerPosition.facingLeft)
				Debug.DrawLine(playerPosition.transform.position, playerPosition.transform.position - new Vector3(4, 0, 0), Color.red);
			if (Inrange(10f))
			{
				
				health.takeDamage(player.GetAttackPower() * player.str + swordBonus);
			}
		}

		if (isStun == false)
		{
			if (proCoolDown.canUse(Time.time))
			{
				shootPlayer();
			}
			capsule.enabled = false;
		}else
		{

			capsule.enabled = true;
			//print("Pause");
		}
	}



	public void shootPlayer()
	{
		pro.setSpeed(false);
		makeProjectile(Vector3.left,-8f);

		proCoolDown.addTime(Time.time, 0.6f);
	}


	public bool Inrange(float range) //function to tell if player is in range
	{
		Vector3 playerpos = playerPosition.transform.position;
		Vector3 Enenmypos = enemy.transform.position;
		float totalx = playerpos.x - Enenmypos.x;
		float totaly = playerpos.y - Enenmypos.y;
		if ((totalx < range && totalx > -range) && (totaly < range && totaly > -range))
		{
			return true;
		}
		else return false;
	}
	public void RemoveEnemy()
	{
		gameObject.SetActive(false);
	}
	public void RespawnEnemy()
	{
		gameObject.SetActive(true);
	}
}
