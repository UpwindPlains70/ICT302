using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructor : MonoBehaviour
{
    public bool level2 = false;
    public bool level4 = false;
    public string lvl4ExclusionTag;

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
        Debug.Log("Col");
            Destroy(collision.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (level2)
        {
            SnapObject snapScript = other.gameObject.GetComponent<SnapObject>();
            if (snapScript.grabbed == false && snapScript.isSnapped == false)
                Destroy(other.gameObject);
        }
        else if (level4)
        {
            if(!other.gameObject.CompareTag(lvl4ExclusionTag))
                Destroy(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
