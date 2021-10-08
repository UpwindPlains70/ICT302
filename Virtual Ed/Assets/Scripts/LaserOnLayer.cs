using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LaserOnLayer : MonoBehaviour
{
    public GameObject layer;
    public GameObject Floor;
    private Transform target;
    float handRight;
    public float speed;

    public GameObject post;
    // Start is called before the first frame update

    void Awake()
    {
        //move ball position
    
    }
    void Start()
    {
        //find objects in scene
        layer = GameObject.FindGameObjectWithTag("Maze_Layer");
        Floor = GameObject.FindGameObjectWithTag("Floor");
        target = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Get input from controller
        handRight = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);

        //if the trigger is pressed
        if (handRight > 0.9)
        {
              //if laser is on layer do
            if (CustomLaserPointer.instance.LaserHit())
            {
                //Get laser location on layer
                RaycastHit hit = CustomLaserPointer.instance.getHit();
                float step = speed * Time.deltaTime;
                //MOVE THE FUCKING BALLLLL CUUUNTT
                transform.position = Vector3.MoveTowards(transform.position, hit.point, step);

            }
        }
    }

    
}
