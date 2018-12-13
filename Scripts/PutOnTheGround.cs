using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutOnTheGround : MonoBehaviour
{

    public LayerMask ground = -1;
    //public Movement playerPos; //barrier;
    public RaycastHit hit;
    private float radius;

    // Use this for initialization
    void Start()
    {
      
    }
    
    public void spawnOnGround(GameObject barrier, Vector3 pos, bool facingRight)
    {
        if (barrier.GetComponent<Collider>() != null)
        {
            radius = barrier.GetComponent<Collider>().bounds.extents.y;
        }
        else
        {
            radius = 1f;
        }
 
        // note that the ray starts at 100 units
        Ray ray = new Ray(pos + Vector3.up, Vector3.down);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
        {
            if (hit.collider != null)
            {
               if(facingRight)
                barrier.transform.position = new Vector3(pos.x+3, hit.point.y + radius, pos.z);
               else
                barrier.transform.position = new Vector3(pos.x - 3, hit.point.y + radius, pos.z);
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {

    }
}
