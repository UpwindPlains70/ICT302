using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Transform target;
    //Make sure to add a value if set to zero in inspector
    public float speed = 10;
    public float stopRange = 1;
    public bool moveAllowed = true;

    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Target").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Check distance
        float DistancetoDest = Vector3.Distance(transform.position, target.position);
        // Move our position a step closer to the target.
        if (DistancetoDest > stopRange && moveAllowed)
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") == false)
        {
            moveAllowed = false;
        }
        else
            moveAllowed = true;
        
    }
}