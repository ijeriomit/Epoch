using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpell : MonoBehaviour
{

    private RaycastHit hit;
    private float duration = 3.5f;
    private int wallcount;
    private GameObject obj;
    private bool movewall = false, buttonPressed;
    private Vector3 pos;
    public HealthHandler manaCount;
    public Movement playerpos;
    public GameObject wall;
    public CoolDown timeforCool1,timeforCool2;
    public float wallCoolDown = 0f;
    public PutOnTheGround location;
    public LayerMask obstacle = -1;
    public RayCast Ray;
    //public float radius;


    //change to grab from playerINfo 
    //public WallInfo info = wall.GetComponent<WallInfo>();
    //public Camera camera;
    // Use this for initialization
    void Start()
    {
        //Destroy(prefab.gameObject, 2);
        obj = Instantiate(wall, Vector3.zero, Quaternion.identity) as GameObject;
        obj.SetActive(false);
        wallcount = 0;
        buttonPressed = false;

    }
    private IEnumerator wallDuration() //destory wall after certain amount of time
    {
        yield return new WaitForSeconds(duration);
        obj.SetActive(false);
        wallcount = 0;
    }
    private IEnumerator moveWall()
    {
         print("moveWall");

        if (Input.GetKeyDown(KeyCode.D)) //this code will eventually make it so the you can change the positoin of the wall
        {
             print("move wall right");
            if (Ray.shootRayRight(obj, obj.transform.position, 2, false, playerpos.facingRight))
                obj.transform.position = new Vector3(obj.transform.position.x + 2, obj.transform.position.y, obj.transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
             print("move wall left");
            if (Ray.shootRayRight(obj, obj.transform.position, 2, false, playerpos.facingRight))
                obj.transform.position = new Vector3(obj.transform.position.x - 2, obj.transform.position.y, obj.transform.position.z);
        }
        yield return new WaitForEndOfFrame();

    }
    private void finishWallMove()
    {
        //  print("finishWallMove");
        //StopCoroutine(moveWall());
        StartCoroutine(wallDuration());
        playerpos.unlockMovement();
        movewall = false;
        timeforCool1.addTime(Time.time, wallCoolDown);
    }
   
    // Update is called once per frame
    void Update()
    {
        if (timeforCool1.canUse(Time.time)) //Uncomment for cool down
        {
            if (Input.GetKey(KeyCode.Alpha1) && buttonPressed == false)
            {
                if (wallcount == 0 && (manaCount.getMana() > 0))
                {
                    obj.SetActive(true);
                    if (Ray.shootRayDown(obj, playerpos.transform.position, 3, true, playerpos.facingRight))
                    {
                        playerpos.SFX.PlayOneShot(playerpos.spellSFX);
                        manaCount.useMana(1);
                        wallcount = 1;
                        timeforCool1.addTime(Time.time, wallCoolDown);
                        //playerpos.lockMovement();
                        timeforCool2.addTime(Time.time, 3.5f);
                        buttonPressed = true;
                        movewall = true;
                    }
                    else
                    {
                        obj.SetActive(false);
                    }
                }

            }
            if (movewall)
            {
                //print("moveWall");
                if ((timeforCool2.canUse(Time.time)) || Input.GetKeyUp(KeyCode.Alpha1))
                {
                    finishWallMove();
                }
                else
                {
                    //print("here");
                    StartCoroutine(moveWall());
                }
            }
            if (Input.GetKeyUp(KeyCode.Alpha1))
                buttonPressed = false;
        }
    }
}