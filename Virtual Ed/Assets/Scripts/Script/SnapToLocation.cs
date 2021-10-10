using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class SnapToLocation : MonoBehaviour
{
    //Returns true when the object is within the SnapZone radius
    private bool insideSnapZone;

    //Return true when the object has had it's location updated;
    public bool Snapped;

    //Set the specific part we want to snap to this location
    public string rocketTag;
    //Reference another Object we can use to set rotation
    public GameObject SnapRotationReference;
    private GameObject snappedObject;

    public event System.Action<SnapToLocation> OnSnapped;

    //Detects when the RocketPart game object has entered the snap zone radius
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("trigger enter: " + other.gameObject.name);
        if (other.gameObject.CompareTag(rocketTag))
        {
            insideSnapZone = true;
            snappedObject = other.gameObject;
        }
    }

    //Detects when the RocketPart game object has left the snap zone redius
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(rocketTag))
        {
            insideSnapZone = false;
            snappedObject = null;
        }
    }

    //Checks if the player has released the object AND if the object is within the SnapZone radius
    //If both are true, set the object location and rotation to the desired snap coordinates
    //Set the public boolean snapped to true for reference by SnapObject script
    void SnapObject()
    {
        if (insideSnapZone == true)
        {
            snappedObject.gameObject.transform.position = SnapRotationReference.transform.position;
            snappedObject.gameObject.transform.rotation = SnapRotationReference.transform.rotation;
            Snapped = true;
                //prevent snapped objects from moving
            snappedObject.GetComponent<Orbit>().enabled = false;
            //snappedObject.GetComponent<Collider>().enabled = false;

            //OnSnapped?.Invoke(this);
        }
    }

    public void DestroySnappedObject()
    {
        if (!Snapped)
            return;

        Destroy(snappedObject.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //Set grabbed to equal the boolean value "isGrabbed" from the OVRGrabble script
        //grabbed = snappedObject.GetComponent<DistanceGrabbable>().isGrabbed;
        //Call our snap object script
        SnapObject();
    }
}
