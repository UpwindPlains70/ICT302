using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class GrabbedOrbiter : MonoBehaviour
{
    private Orbit myOrbit;
    private DistanceGrabbable myGrabbable;
    // Start is called before the first frame update
    void Start()
    {
        myOrbit = GetComponent<Orbit>();
        myGrabbable = GetComponent<DistanceGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myGrabbable.isGrabbed)
            myOrbit.enabled = false;
        else
            myOrbit.enabled = true;
    }
}
