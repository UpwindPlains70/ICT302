using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    private Rigidbody myRBody;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        myRBody = GetComponent<Rigidbody>();

        //myRBody.AddForce(new Vector3(0, 0, speed));
        myRBody.AddRelativeForce(Vector3.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
