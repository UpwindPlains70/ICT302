using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Covid_Handler : MonoBehaviour
{
    public Material newMaterialRef;
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
            //Only prevent clipping for initial spawning
        if (collision.gameObject.GetComponent<Rigidbody>().isKinematic == false)
        {
            Destroy(collision.gameObject); //destroy hit by object
            Destroy(this.gameObject); //destory hit object
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        //destroy hit object
        ParticleSystem ps = other.GetComponent<ParticleSystem>();

        if(ps.subEmitters.enabled)
            //Change material
            GetComponent<Renderer>().material = newMaterialRef;
        else
            //destroy object
            Destroy(gameObject);
    }
}
