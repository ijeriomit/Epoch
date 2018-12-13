using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour {

	public BossAI enemyInfo;
	public Slider healthSlider;
	public int maxHP;
	public int curHP;
	private int damageMultiplier =1; //int to multiply damage
	// Use this for initialization
	void Start () {

		maxHP = enemyInfo.hp;
		curHP = maxHP;
		healthSlider.maxValue = maxHP;
		healthSlider.value = curHP;
		damageMultiplier = 1;
	}

	// Update is called once per frame
	void Update () {

	}
	public void checkIfDead() //checks if enemy is dead
	{
		if (curHP <= 0)
		{
			curHP = 0;
			enemyInfo.RemoveEnemy();
            Application.LoadLevel("Example");
		}
	}
	public void takeDamage(int attack){
		attack = damageMultiplier * attack;
		curHP = curHP - attack; //decrement health upon taking damage 
		healthSlider.value = curHP;
		checkIfDead();
		//regenerate (); 
	}
	public void multiplyDamage(int dmgMult)// multipies the damage when debuffed
	{
		damageMultiplier = dmgMult;
	}
	public void resetDamage()
	{
		damageMultiplier = 1;
	}

}
