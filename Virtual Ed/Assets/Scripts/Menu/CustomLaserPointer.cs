using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomLaserPointer : MonoBehaviour
{

    public static CustomLaserPointer instance;

    public Transform handTransform;

    RaycastHit hit;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

   public bool LaserHit()
    {
        //ray is cast that follows laser's line renderer, Hit is from collision on ray
        if (Physics.Raycast (handTransform.transform.position, handTransform.forward, out hit))
        {
            //if laser hits the right layer then true
            if(hit.collider.gameObject.tag == "Maze_Layer")
            {
                return true;
            }
        }
        //if nothing is hit by laser
        return false;
    }

    //get hit from recent collision
    public RaycastHit getHit()
    {
        return hit;
    }
}
