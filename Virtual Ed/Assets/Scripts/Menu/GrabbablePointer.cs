using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbablePointer : MonoBehaviour
{
    public static GrabbablePointer instance;

    public Transform rightHandTransform;
    public Transform leftHandTransform;


    RaycastHit hit;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public bool LaserHit()
    {
        //ray is cast that follows laser's line renderer, Hit is from collision on ray
        if (Physics.Raycast(rightHandTransform.transform.position, rightHandTransform.forward, out hit))
        {
            //if laser hits the right layer then true
            if (hit.collider.gameObject.tag == "Grabbable")
            {
                return true;
            }
        }

        //ray is cast that follows laser's line renderer, Hit is from collision on ray
        if (Physics.Raycast(leftHandTransform.transform.position, leftHandTransform.forward, out hit))
        {
            //if laser hits the right layer then true
            if (hit.collider.gameObject.tag == "Grabbable")
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
