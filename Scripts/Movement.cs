using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

	public Animator animator;

	public float speed = 10f;
	public float jumpForce = 3;

	//public float maxHP = 10;
	//public float curHP;
	//public int maxMana = 2;
	//public int curMana;
	public bool facingRight;
    public bool facingLeft;
	public float dashDist = 10f;
    public LayerMask groundLayer;
	public Transform animTransform;
	public AudioClip swordSFX;
	public AudioClip fireball;
	public AudioClip CoinSFX;
	public AudioClip spellSFX;
	public AudioClip pickupSFX;
	public AudioClip damageSFX;

    //public Transform feet;


	public AudioSource SFX;
	private Collision col2D; 
	private Rigidbody rb;
    private RayCast ray;
	public SpriteRenderer sprite;
	private Transform spriteTransform;
	private Respawn spawner;
	public HealthHandler hp;
    private float timeStamp;
    private bool canMove;
	private float speedLimit = 30;
	private float dashCooldown = 1.0f;
	private float timeToCooldown;
    private int i = 0;
	public bool canJump;
    private bool wantsJump;
	void OnTriggerEnter(Collider info){
		if (info.gameObject.tag == "EnemyProjectile") {
			hp.takeDamage ();
		}
	}
	void OnCollisionEnter(Collision collisionInfo){
        //if(collisionInfo.gameObject.tag != "MovingPlatform")
		    //canJump = true;
		if (collisionInfo.gameObject.CompareTag("Enemy")){
			hp.takeDamage();
            //print("ouch");
			//rb.AddForce (new Vector3 (-50, 0, 0));
             rb.AddForce (new Vector3 (-100, 180, 0));

            //rb.AddForce(new Vector3(0, 180, 0));
        }
		if (collisionInfo.gameObject.CompareTag("Boss")){
			hp.takeDamage();
			//print("ouch");
			//rb.AddForce (new Vector3 (-50, 0, 0));
			rb.AddForce (new Vector3 (-300, 300, 0));

			//rb.AddForce(new Vector3(0, 180, 0));
		}

		if(collisionInfo.gameObject.name.Equals("Projectile(Clone)")){
			hp.takeDamage();
		}
		if (collisionInfo.gameObject.tag == "MovingPlatform") {
			transform.SetParent (collisionInfo.gameObject.transform);
		}
	}
    private void OnCollisionExit(Collision info)
    {
		if (info.gameObject.tag == "MovingPlatform") {
			transform.parent = null;
		}
    }
    bool isGrounded()
    {
        if(ray.shootRayDown(gameObject, transform.position, 2.6f, false, facingRight))
        {
          //  print("jumping");
            return false;
        }
        return true;
    }
	/*public float GetMaxValue(){
		return maxHP;
	}
	public float GetMaxMana(){
		return maxMana;
	}*/
    public void lockMovement(){
        canMove = false;
    }
    public void lockMovementTillFrameEnds(){
        lockMovement();
        StartCoroutine(StopMovement());
        unlockMovement();
    }
    public void unlockMovement(){
        canMove = true;
    }
    private IEnumerator StopMovement(){
        yield return new WaitForEndOfFrame();
    }
    void Start (){
		SFX = GetComponent<AudioSource> ();
		spawner = GetComponent<Respawn> ();
		rb = GetComponent<Rigidbody>();
		hp = GetComponent<HealthHandler>();
        ray = GetComponent<RayCast>();
		facingRight = true;
        facingLeft = false;
        canMove = true;
        //canJump = isGrounded();
		speed = 10f + PlayerPrefs.GetInt ("dex");
        wantsJump = false;
		
	}
	void Update(){
        canJump = isGrounded();
		if (Input.GetKeyDown(KeyCode.W)) {
            //Jump();
            wantsJump = true;
		}
		if (Input.GetKeyDown (KeyCode.Space) && Time.time > timeToCooldown) {
			timeToCooldown = Time.time + dashCooldown;
			Dash ();
		}
		if (facingRight) {
			animTransform.localScale = new Vector3 (1, 1, 1);
		} else {
			animTransform.localScale = new Vector3 (-1, 1, 1);
		}
        if (canMove)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                animator.SetBool("IsMoving", true);
            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                //print ("stopping");
                animator.SetBool("IsMoving", false);
            }
        }
		if (canJump) {
			animator.SetBool ("Jumping", false);
		} else {
			animator.SetBool ("Jumping", true);
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			SFX.PlayOneShot (swordSFX);
			animator.SetBool ("Attacking", true);
		}
		if (Input.GetKeyUp(KeyCode.P)) {
			animator.SetBool ("Attacking", false);
		}
        isGrounded();
	}
	void FixedUpdate (){
        if(wantsJump)
        {
            Jump();
            wantsJump = false;
        }
		if (canMove)
        {
			if (Input.GetKey (KeyCode.D)) {
				facingRight = true;
				facingLeft = false;
				sprite.flipX = false;
				//rb.AddForce(Vector3.right * speed *3);
				transform.Translate (Vector3.right * Time.deltaTime * speed);

			} else if (Input.GetKey (KeyCode.A)) {
				facingLeft = true;
				facingRight = false;
				sprite.flipX = true;
				//rb.AddForce(Vector3.right * speed *-1*3);
				transform.Translate (Vector3.left * Time.deltaTime * speed);
			}
			if (Input.GetKeyDown (KeyCode.E) && Time.time > timeToCooldown) {
				timeToCooldown = Time.time + dashCooldown;
				Dash ();
			}
		}

	}
	public void Jump(){
        //canJump = isGrounded();
		if (canJump == true){
			rb.AddForce(new Vector3(0, 1.35f, 0) * jumpForce);
            //rb.velocity = new Vector3(0, 1, 0) * jumpForce;
            
            //canJump = false;
        }		
     }
	
	public void Dash(){
		var DashPos = transform.position; 

		//float t = 0f;
        if(facingRight)
			rb.AddRelativeForce(Vector3.right * 650);
			//DashPos.x = transform.position.x + dashDist;
        else if(facingLeft)
			rb.AddRelativeForce(Vector3.left * 650);
        	//DashPos.x = transform.position.x - dashDist;
		if (rb.velocity.x > speedLimit) {
			//print (rb.velocity.x);
			rb.velocity = new Vector3 (0, 0, 0);

		}
	}
}
