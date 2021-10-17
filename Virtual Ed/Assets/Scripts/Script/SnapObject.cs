using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class SnapObject : MonoBehaviour
{
    //Reference the snap zone collider we'll be using
    public string snapLocationTag;
    private GameObject SnapLocation;

    //Referemce the game object that the snapped objects will become a part of
    public GameObject rocket;

    //Create a variable that will be used by the RocketLaunch script to determine if all three pieces are in place.
    public bool isSnapped;

    //boolean variable used to reference the "Snapped" boolean from the SnapToLocation script
    private bool objectSnapped;

    //boolean variable used to determine if the object is currently being held by the player
    public bool grabbed { get; private set; }

    private DistanceGrabbable myDistGrabbable;
    private Rigidbody myRBody;
    private Orbit myOrbit;

    private SnapToLocation mySnapTo;
    private Vector3 currGrabPos;
    private void Awake()
    {
        grabbed = false;
        SnapLocation = GameObject.FindGameObjectWithTag(snapLocationTag);
        mySnapTo = SnapLocation.GetComponent<SnapToLocation>();
        myDistGrabbable = GetComponent<DistanceGrabbable>();
        myRBody = GetComponent<Rigidbody>();
        myOrbit = GetComponent<Orbit>();
    }

    //Update is called once per frame
    void Update()
    {
        //Set grabbed to equal the boolean value "isGrabbed" from the OVRGrabbable script
        if (!grabbed)
        {
            grabbed = myDistGrabbable.isGrabbed;
            myOrbit.enabled = !myDistGrabbable.isGrabbed;
        }
        else
            //Prevent stationary objects
            currGrabPos = transform.position;
        
        //Set objectSnapped equal to the Snapped boolean from SnapToLocation
        objectSnapped = mySnapTo.Snapped;

        //Set object Rigibody to be Kinematic after it has been snapped into position
        //Set object to be a parent of the Rocket object after it has been snapped
        //Set isSnapped variable to true to alert the RocketLaunch script
        if (objectSnapped == true)
        {
            isSnapped = true;
            myRBody.isKinematic = true;
            transform.SetParent(rocket.transform);
        }

        //Makes sure that the object can still be grabbed by the OVRGrabber script. We get bugs without this.
        if (objectSnapped == false)
        {
            myRBody.isKinematic = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (myRBody.velocity.magnitude < 0.2f)
        {
            if (grabbed && !myDistGrabbable.isGrabbed && !isSnapped)
                Destroy(gameObject);
            else
            {
                if (currGrabPos == transform.position)
                    Destroy(gameObject);
            }
        }
        else
        {
            grabbed = false;
        }
    }
}
