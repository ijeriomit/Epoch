using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour {

	public GameObject freeze;
	public GameObject projectile;
	public Movement player;
	public HealthHandler playerHP;
	public Projectile pro;
	public Freeze ice;
    private CoolDown coolDown, freezeCool;
    private float timeforCoolDown = 0.4f; // set this variable with data from playerINfo;
	//public bool wandBonus;
	private bool hasWand;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetString ("hasWand") == "true")
			hasWand = true;
		else
			hasWand = false;
        coolDown = GetComponent<CoolDown>();
        freezeCool = GetComponent<CoolDown>();
	}
	void makeProjectile(int direction, float area)
    {
        GameObject bul = Instantiate(projectile, transform.position + new Vector3(area, 0, 0), Quaternion.identity) as GameObject;
        bul.transform.Translate(direction, 0, 0);
    }
	void makeFreeze(int direction, float area){
		GameObject bul = Instantiate (freeze, transform.position + new Vector3 (area, 0, 0), Quaternion.identity) as GameObject;
		bul.transform.Translate(direction, 0, 0);
	}
	// Update is called once per frame
	void Update () {
		if (coolDown.canUse(Time.time))
        {
			if (Input.GetKeyDown (KeyCode.O) && playerHP.getMana () > 0 && !hasWand) {
				player.animator.SetBool ("Spellcasting", true);
				player.SFX.PlayOneShot (player.fireball);
				// bul.SetActive(true);
				if (player.facingRight) {
					pro.setSpeed (player.facingRight);
					makeProjectile (2, 0.15f);
					playerHP.useMana (1);
				} else {
					pro.setSpeed (player.facingRight);
					print (pro.projectileSpeed);
					makeProjectile (-2, -0.15f);
					playerHP.useMana (1);
				}
				coolDown.addTime (Time.time, timeforCoolDown);
			} else if (Input.GetKeyDown (KeyCode.O) && hasWand) {
				player.animator.SetBool ("Spellcasting", true);
				player.SFX.PlayOneShot (player.fireball);
				// bul.SetActive(true);
				if (player.facingRight) {
					pro.setSpeed (player.facingRight);
					makeProjectile (2, 0.15f);
				} else {
					pro.setSpeed (player.facingRight);
					print (pro.projectileSpeed);
					makeProjectile (-2, -0.15f);
				}
				coolDown.addTime (Time.time, timeforCoolDown);
			}

        }


		if(Input.GetKeyUp(KeyCode.O)){
			
			player.animator.SetBool ("Spellcasting", false);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4) && playerHP.getMana() > 0 )//&& (PlayerPrefs.GetString("hasFreeze") == "true"))
		{
			// bul.SetActive(true);
			if (player.facingRight)
			{
				ice.setSpeed(player.facingRight);
				makeFreeze(1, 1);
			}
			else
			{
				ice.setSpeed(player.facingRight);
				//print(ice.projectileSpeed);
				makeFreeze(-1, -1);
			}
            playerHP.useMana(1);
			freezeCool.addTime(Time.time, timeforCoolDown);
		}
		
		if (Input.GetKeyDown (KeyCode.Alpha3) && playerHP.getMana () > 0 && (PlayerPrefs.GetString ("hasHeal") == "true")) {
			player.SFX.PlayOneShot (player.spellSFX);
			playerHP.useMana (1);
			playerHP.heal ();
		}
	}
}
