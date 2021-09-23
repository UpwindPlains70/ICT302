using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToLocation : MonoBehaviour
{
    //boolean variable used to determine if the object is currentl being held by the player
    private bool grabbed;

    //Returns true when the object is within the SnapZone radius
    private bool insideSnapZone;

    //Return true when the object has had it's location updated;
    public bool Snapped;

    //Set the specific part we want to snap to this location
    public GameObject RocketPart;
    //Reference another Object we can use to set rotation
    public GameObject SnapRotationReference;

    //Detects when the RocketPart game object has entered the snap zone radius
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == RocketPart.name)
        {
            insideSnapZone = true;
        }
    }

    //Detects when the RocketPart game object has left the snap zone redius
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == RocketPart.name)
        {
            insideSnapZone = false;
        }
    }

    //Checks if the player has released the object AND if the object is within the SnapZone radius
    //If both are true, set the object location and rotation to the desired snap coordinates
    //Set the public boolean snapped to true for reference by SnapObject script
    void SnapObject()
    {
        if (grabbed == false && insideSnapZone == true)
        {
            RocketPart.gameObject.transform.position = SnapRotationReference.transform.position;
            RocketPart.gameObject.transform.rotation = SnapRotationReference.transform.rotation;
            Snapped = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Set grabbed to equal the boolean value "isGrabbed" from the OVRGrabble script
        grabbed = RocketPart.GetComponent<OVRGrabbable>().isGrabbed;
        //Call our snap object script
        SnapObject();
    }
}
