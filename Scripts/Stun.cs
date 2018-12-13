using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour
{
	public HealthHandler manaCount;
    public AI enemy;
    public EnemyHealth enemyDmg;
    private Vector3 playerposition;
    private float stunTime;
    //public bool isStun;
    // Use this for initialization
	void OnTriggerEnter(Collider info){ //was collisoin
		if(info.gameObject.CompareTag("Freeze")){
			startStun();
		}
	}
    void Start()
    {
        enemy = GetComponent<AI>();
        stunTime = 1.5f;
    }
    private IEnumerator WaitforNext() //waits for the next stun
    {
        yield return new WaitForSeconds(1.0f);
        //Debug.Log("WaitForNextStun Done");
    }
    private IEnumerator WaitForStun()
    {
        yield return new WaitForSeconds(stunTime); //waits for the amount of seconds of stun
        //enemy.resetSpeed();
        enemyDmg.resetDamage();
        enemy.SetStun(false);
        // Debug.Log("WaitForNextStun Done");
        StartCoroutine(WaitforNext());
    }
    public void startStun()
    {
		if (/*checkStun() && */manaCount.getMana() > 0)
        {
			//manaCount.useMana (1);
            //enemy.SetSpeed(0);  //sets the enemies speed to 0
            enemyDmg.multiplyDamage(2);
            enemy.SetStun(true);
            StartCoroutine(WaitForStun()); // Starts the wait time for stun
        }
    }
    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Alpha2) && enemy.Inrange(8))
        {
			enemy.playerPosition.SFX.PlayOneShot (enemy.playerPosition.spellSFX);
            startStun();
			manaCount.useMana (1);
        }

    }
}
