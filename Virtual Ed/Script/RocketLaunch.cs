using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLaunch : MonoBehaviour
{
    //Create array of game objects
    public GameObject[] rocketParts;

    //Used to check if all parts has been added to the rocket
    private bool partAdded;

    //Flag to ensure the rocket only launches once
    private bool launched = false;

    // Update is called once per frame
    void Update()
    {
        //Check if all three parts have been snapped into place, and make sure we have't already launched
        if (rocketLaunch() == true && launched == false)
        {
            Debug.Log(rocketLaunch());
            //Add constant froce to the Rocket Object
            gameObject.AddComponent<ConstantForce>().force = new Vector3(0f, 1500f, 0f);
            //Confirm that the rocket has been launched
            launched = true;
        }
    }

    //Use a for loop to iterate through the array of rocket parts
    //Checks to see if isSnapped is set to true on each one
    //Return false if any one of the three is false
    //If all three return true, then set to true
    private bool rocketLaunch()
    {
        for (int i = 0; i < rocketParts.Length; i++)
        {
            partAdded = rocketParts[i].GetComponent<SnapObject>().isSnapped;
            if (partAdded == false)
            {
                return false;
            }
        }
        return true;
    }
}
