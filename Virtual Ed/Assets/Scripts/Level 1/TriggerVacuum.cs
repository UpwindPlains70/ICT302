using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVacuum : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        collision.gameObject.GetComponent<Vacuum>().enabled = true;            
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.GetComponent<Vacuum>().enabled = false;
    }
}

