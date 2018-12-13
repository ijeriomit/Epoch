using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallInfo : MonoBehaviour {
    public float duration;
    public GameObject wall;
    // Use this for initialization
    public void makeWall(){
        StartCoroutine(wallDuration());
	}
	void Start () {
        duration = 1.5f;
	}
    private IEnumerator WaitforNext() //waits for the next stun
    {
        yield return new WaitForSeconds(1.0f);
        //Debug.Log("WaitForNextStun Done");
    }
    private IEnumerator wallDuration()
    {
        yield return new WaitForSeconds(duration);
        wall.SetActive(false);

    }
	// Update is called once per frame
	void Update () {
		
			}
		}
