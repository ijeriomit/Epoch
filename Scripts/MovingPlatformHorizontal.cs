using UnityEngine;
using System.Collections;

public class MovingPlatformHorizontal : MonoBehaviour {

    public float frequency = 1f; //movement speed
    public float amplitude = 10f; //movement amount
    Vector3 startPos;
    float elapsedTime = 0f;
	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime * Time.timeScale * frequency;
        transform.position = startPos + Vector3.right * Mathf.Sin(elapsedTime) * amplitude;
	}
	void FixedUpdate(){
		//rb.MovePosition (transform.position + transform.right * Mathf.Sin (elapsedTime)*amplitude);
	}
}
