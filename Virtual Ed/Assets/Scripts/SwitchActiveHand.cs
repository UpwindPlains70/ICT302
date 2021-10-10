using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActiveHand : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            leftHand.SetActive(true);
            rightHand.SetActive(false);
        }

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            leftHand.SetActive(false);
            rightHand.SetActive(true);
        }
    }
}
