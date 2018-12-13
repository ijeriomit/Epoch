using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDrop : MonoBehaviour {
    PlayerInfo Player;
	//public int coinCount;
	public Rigidbody body;
    public GameObject coin;
	void OnTriggerEnter(Collider info)
    {
        if (info.gameObject.name.Equals("Player"))
        {
           // Player.heal();
           // gameObject.SetActive(false);
            Destroy(gameObject);
			//coinCount++;
        }
    }
    public void dropCoin(Vector3 enemyPos)
    {
		int numOfCoins = Random.Range (1, 4);
		for (int i = 0; i < numOfCoins; i++) {
			GameObject drop = Instantiate (coin, enemyPos + new Vector3 (i*.5f, i, 0), Quaternion.identity) as GameObject;
			body.AddForce (i*200, i * 500, 0);
		}
        //coin.SetActive(true);
    }
    // Use this for initialization
    void Start () {
        Destroy(gameObject, 15);
	}
	// Update is called once per frame
	void Update () {
		
	}
	/*public int getCoinCount(){
		return coinCount;
	}*/
}
