using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVacuum : MonoBehaviour
{
    private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            active = true;
        }
        else
            active = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Vacuum>().enabled = true;            
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Vacuum>().enabled = false;
    }
}

