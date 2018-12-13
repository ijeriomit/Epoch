using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour {

    private Ray ray;
    private RaycastHit hit;
    public LayerMask obstacle =-1;
    int shift;
	// Use this for initialization
	void Start () {
        shift = 3;
    }
    public float setRadius(char side,GameObject obj)
    {
        float radius = 1f;
        
        if (obj.GetComponent<Collider>() != null)
        {
            if (side == 'x')
            {
                radius = obj.GetComponent<Collider>().bounds.extents.x;
            }
            else if (side == 'y')
            {
                radius = obj.GetComponent<Collider>().bounds.extents.y;
            }
            else if (side == 'z')
            {
                radius = obj.GetComponent<Collider>().bounds.extents.z;
            }
          
        }
        return radius;
    }
    public void setShift(int newShift)
    {
        shift = newShift;
    }
    public void setMask()
    {
        
    }
    public bool shootRayLeft(GameObject obj,Vector3 playerPos,float withinDistance,bool moveObj,bool facingRight) //checks if their is an obstacle within a certain distance
    {
        ray = new Ray(playerPos, Vector3.left);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, obstacle))
        {
            if (hit.collider != null)
            {
                if (moveObj)
                {
                    return PlacementCheck(hit.point, obj, playerPos, facingRight);
                }
                if (hit.distance <= withinDistance)
                {
                    if (hit.collider.gameObject.name.Equals("Player"))//edit this to handle multiple execeptions
                        return true;

                    return false;
                }
            }
        }
        return true;
    }
    public bool shootRayRight(GameObject obj, Vector3 playerPos,float withinDistance, bool moveObj, bool facingRight) //checks if their is an obstacle within a certain distance
    {
        float radius = setRadius('x',obj);
        playerPos = new Vector3(playerPos.x + radius, playerPos.y, playerPos.z);
        ray = new Ray(playerPos, Vector3.right);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, obstacle))
        {
            if (hit.collider != null)
            {
                if(moveObj)
                {
                    return PlacementCheck(hit.point, obj, playerPos, facingRight);
                }
                if (hit.distance <= withinDistance)
                {
                    if (hit.collider.gameObject.name.Equals("Player"))//edit this to handle multiple execeptions
                        return true;

                    return false;
                }
            }
        }
        return true;
    }
    public bool shootRayDown(GameObject obj,Vector3 playerPos,float withinDistance, bool moveObj, bool facingRight)
    {
        ray = new Ray(playerPos + Vector3.up, Vector3.down);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, obstacle))
        {
            if (hit.collider != null)
            {
                //print("hit");
               // print(hit.distance);
                if (moveObj)
                {
                    return PlacementCheck(hit.point, obj, playerPos, facingRight);
                }
                if (hit.distance <= withinDistance)
                {
                    
                    if (hit.collider.gameObject.name.Equals("Player"))//edit this to handle multiple execeptions
                        return true;

                    return false;
                }
            }
            
        }
        return true;

    }
    public bool shootRayUp(GameObject obj,Vector3 playerPos, float withinDistance, bool moveObj, bool facingRight)
    {
        ray = new Ray(playerPos+Vector3.down, Vector3.up);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, obstacle))
        {
            if (hit.collider != null)
            {
                if(moveObj)
                {
                    return PlacementCheck(hit.point, obj, playerPos, facingRight);
                }
                if (hit.distance <= withinDistance)
                {
                    if (hit.collider.gameObject.name.Equals("Player"))//edit this to handle multiple execeptions
                        return true;

                    return false;
                }
            }
        }
        return true;

    }
    public bool PlacementCheck(Vector3 hit, GameObject obj, Vector3 playerPos, bool facingRight)
    {
        if (facingRight)
        {
            if (shootRayRight(obj, playerPos, shift, false, facingRight))
            {
                positionObject(hit, obj, shift, playerPos);
            }
            else {
                print("too close");
                return false;
            }

        }
        else
        {
            if (shootRayLeft(obj, playerPos, -shift, false, facingRight))
            {
                positionObject(hit, obj, -shift, playerPos);
            }
            else
            {
                print("too close");
                return false;
            }
        }
        return true;
    }
    public void positionObject(Vector3 hit,GameObject obj, int shift,Vector3 pos)
    {
        float radius;
            radius = setRadius('y', obj);
            print("here");
            obj.transform.position = new Vector3(pos.x + shift, hit.y + radius, 0);
    }
   
    // Update is called once per frame
    void Update () {
       
    }
}
