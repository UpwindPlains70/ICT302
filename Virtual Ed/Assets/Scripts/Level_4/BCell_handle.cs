using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCell_handle : MonoBehaviour
{
    private bool activated = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public bool isActive()
    { 
        return activated;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            if (!activated)
            {
                this.GetComponent<ParticleSystem>().Play();
                this.GetComponent<Animation>().Play();
                activated = true;
            }
        }
    }
}
