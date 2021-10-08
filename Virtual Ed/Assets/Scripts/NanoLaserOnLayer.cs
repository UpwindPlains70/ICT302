using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanoLaserOnLayer : MonoBehaviour
{

    public GameObject layer;
    public GameObject mRNA;
    public GameObject tRNA;
    public GameObject aminoAcid;
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
        layer = GameObject.FindGameObjectWithTag("Grabbable");
        mRNA = GameObject.FindGameObjectWithTag("mRNA");
        tRNA = GameObject.FindGameObjectWithTag("tRNA");
        aminoAcid = GameObject.FindGameObjectWithTag("aminoAcid");
        
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
