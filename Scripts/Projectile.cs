using UnityEngine;
using System.Collections;


public class Projectile : MonoBehaviour {
	public int damage = 1;

	public float projectileSpeed;
	public SpriteRenderer sprite;

    // Use this for initialization
    void OnTriggerEnter(Collider info) {
        if (info.gameObject.CompareTag("Enemy")||info.gameObject.CompareTag("inGameWall")||info.gameObject.CompareTag("Ground")||
            info.gameObject.name.Equals("Player")||info.gameObject.CompareTag("MovingPlatform"))
        {
            Destroy(gameObject);
        }
    
	}
	void Start () {
		//projectileSpeed = setSpeed();
        Destroy(gameObject, 0.5f);
       //gameObject.SetActive(false);
		if (PlayerPrefs.GetString ("hasWand") == "true") {
			damage++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (projectileSpeed, 0, 0);
	}
	public void setSpeed(bool facingRight){
		if (facingRight) {
			facingRightSpeed ();
		} else {
			facingLeftSpeed ();
		}
	}
	public void facingLeftSpeed(){
		sprite.flipX = true;
		projectileSpeed = -0.5f;
	}
	public void facingRightSpeed(){
		sprite.flipX = false;
		projectileSpeed = 0.5f;
	}
}
