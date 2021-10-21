﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Transform target;
    //Make sure to add a value if set to zero in inspector
    public float speed = 10;
    public float stopRange = 1;
    public bool moveAllowed = true;
    public float timer = 0;
    float delay = 1.0f;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Target").transform;
    }void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").transform;
    }
     
    // Update is called once per frame
    void Update()
    {
        //Check distance
        float DistancetoDest = Vector3.Distance(transform.position, target.position);
        // Move our position a step closer to the target.
        if (DistancetoDest > stopRange && moveAllowed && target.gameObject.activeInHierarchy)
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.CompareTag("Floor") == false || timer > Time.time)
        {
           // moveAllowed = false;
            //timer = Time.time + delay;
        }
        else */if (collision.gameObject.CompareTag("Coin") == true)
            Destroy(gameObject);
        else
            moveAllowed = true;
        
    }
}