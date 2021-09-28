using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapObject : MonoBehaviour
{
    //Reference the snap zone collider we'll be using
    public GameObject SnapLocation;

    //Referemce the game object that the snapped objects will become a part of
    public GameObject rocket;

    //Create a variable that will be used by the RocketLaunch script to determine if all three pieces are in place.
    public bool isSnapped;

    //boolean variable used to reference the "Snapped" boolean from the SnapToLocation script
    private bool objectSnapped;

    //boolean variable used to determine if the object is currently being held by the player
    private bool grabbed;

    //Update is called once per frame
    void Update()
    {
        //Set grabbed to equal the boolean value "isGrabbed" from the OVRGrabbable script
        grabbed = GetComponent<OVRGrabbable>().isGrabbed;

        //Set objectSnapped equal to the Snapped boolean from SnapToLocation
        objectSnapped = SnapLocation.GetComponent<SnapToLocation>().Snapped;

        //Set object Rigibody to be Kinematic after it has been snapped into position
        //Set object to be a parent of the Rocket object after it has been snapped
        //Set isSnapped variable to true to alert the RocketLaunch script
        if (objectSnapped == true)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.SetParent(rocket.transform);
            isSnapped = true;
        }

        //Makes sure that the object can still be grabbed by the OVRGrabber script. We get bugs without this.
        if (objectSnapped == false && grabbed == false)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
