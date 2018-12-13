using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

	private Transform enemyT;
	//private Rigidbody enemyR;
	private AI enemy;
    private Vector2 direction;
    private bool isMoving,isIdle,isStun;
    private CoolDown timeForCool1,timeForCool2,proCoolDown;
    private Animator anim;

	public AudioSource SFX;
	public AudioClip hurtSFX;
	public SpriteRenderer capsule;
    public Rigidbody rb;
    public bool dirRight,isShooting;
    public float pos;
	//public bool facingRight;
	public Movement playerPosition;
	public EnemyHealth health;
	public GameObject projectile;
	public Projectile pro;
	public Freeze freeze;
	public PlayerInfo player; //use to grab info regarding player such as AttackPower
	public const int speed = 2; //changed speed to constant 
	public int newSpeed = speed, hp = 3, wandBonus, swordBonus; //created newspeed variable and update this instead of speed var which should stay constant.
 
    void OnTriggerEnter(Collider collisionInfo)
	{
       
		if (collisionInfo.gameObject.name.Equals ("Player"))
        {
          //  print("hit");
            changeDirection();
        }
		if(collisionInfo.gameObject.CompareTag("Ground") || collisionInfo.gameObject.CompareTag("inGameWall")) {
           // print("wall");
            changeDirection();
		}
         if(collisionInfo.gameObject.CompareTag("Enemy"))
        {
            //changeDirection();
        }
		if(collisionInfo.gameObject.CompareTag("Projectile"))
		{
			health.takeDamage(player.GetAttackPower() * player.spell + wandBonus);
			print("hurt");
		}
		if (collisionInfo.gameObject.CompareTag ("Freeze")) 
		{
			health.takeDamage (player.GetAttackPower ());

		}

		/*print("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
		print("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
		print("Their relative velocity is " + collisionInfo.relativeVelocity);*/
	}
	// Use this for initialization
	void Start () {
		capsule.enabled = false;
		pos = transform.position.x;
		dirRight = true;
		enemy = GetComponent<AI> ();
		enemyT = GetComponent<Transform> ();
		//enemyR = GetComponent<Rigidbody> ();
		isStun = false;
        direction = Vector2.right;
        isMoving = false;
        isIdle = false;
		SFX = GetComponent<AudioSource> ();
        timeForCool1 = GetComponent<CoolDown>();
        timeForCool2 = GetComponent<CoolDown>();
        proCoolDown = GetComponent<CoolDown>();
        anim = GetComponent<Animator>();

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
    public void changeDirection()
    {
        if (dirRight == true) 
        {
            direction = Vector2.left; //changes direction left
            dirRight = false;
          //  Move();

        }
        else if (dirRight == false)
        {
            direction = Vector2.right;
            dirRight = true;
          //  Move();
        }
        //Update();
    }
	public void SetSpeed(int speedChange)// function to set the speed of enemy to 0 
	{
		newSpeed = speedChange;
	}
	public void resetSpeed() //resets the speed back to the original
	{
		newSpeed = speed;
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
            if (playerPosition.facingRight)
                Debug.DrawLine(playerPosition.transform.position, playerPosition.transform.position + new Vector3(4, 0, 0), Color.red);
            else if (playerPosition.facingLeft)
                Debug.DrawLine(playerPosition.transform.position, playerPosition.transform.position - new Vector3(4, 0, 0), Color.red);
            if (Inrange(4))
            {

                health.takeDamage(player.GetAttackPower() * player.str + swordBonus);
				SFX.PlayOneShot (hurtSFX);
            }
        }
        if (isStun == false)
        {
            anim.enabled = true;
			capsule.enabled = false;
            if (Inrange(10))
            {
				peacefulBehavior ();
                if (proCoolDown.canUse(Time.time))
                {
                    shootPlayer();
                }
                /*else
                {
                    Idle();
                }*/
            }
            else
            {
                peacefulBehavior();
            }
        }else
        {
            anim.enabled = false;
			capsule.enabled = true;

            //print("Pause");
        }
    }
    
    public void callAnimation(bool moving, bool faceRight, bool shoot)
    {
        if (anim.enabled == true)
        {
            anim.SetBool("Moving", moving);
            anim.SetBool("FacingRight", faceRight);
            anim.SetBool("Shooting", shoot);
        }
        
    }


    void peacefulBehavior()
    {
        if (transform.position.x > pos + 5.0f)
        {
            changeDirection();
        }
        if (transform.position.x < pos - 5.0f)
        {
            changeDirection();
        }
        if (isMoving == false && isIdle == false)
        {
            timeForCool1.addTime(Time.time, 5f);
            isMoving = true;
        }
        if (isMoving == true && isIdle == false)
        {
            if (!timeForCool1.canUse(Time.time))
            {
                Move();
            }
            else
            {
                timeForCool2.addTime(Time.time, 3f);
                isIdle = true;
                isMoving = false;
            }
        }
        if (isMoving == false && isIdle == true)
        {
            if (!timeForCool2.canUse(Time.time))
            {
                Idle();
            }
            else
            {
                isIdle = false;
                isMoving = false;
            }
        }
    }
    public void shootPlayer()
    {
        if(playerPosition.gameObject.transform.position.x < gameObject.transform.position.x)
        {
            if (dirRight == true)
                changeDirection();
            callAnimation(false, dirRight, true);
            pro.setSpeed(false);
            makeProjectile(Vector3.left,-1.5f);
        }
        else if(playerPosition.gameObject.transform.position.x > gameObject.transform.position.x)
        {
            if (dirRight == false)
                changeDirection();
            callAnimation(false, dirRight, true);
            pro.setSpeed(true);
            makeProjectile(Vector3.right,1.5f);
        }
        proCoolDown.addTime(Time.time, 1.5f);
    }
    public void Idle()
    {
        callAnimation(isMoving,dirRight,false);
    }
    public void Move()
    {
        callAnimation(isMoving,dirRight,false);
        enemyT.transform.Translate(direction * Time.deltaTime * newSpeed);
		//rb.AddForce (direction * newSpeed);

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
