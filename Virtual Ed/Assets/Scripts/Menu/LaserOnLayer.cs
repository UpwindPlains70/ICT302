using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LaserOnLayer : MonoBehaviour
{
    public GameObject layer;
    public GameObject Floor;

    float handRight;

    public GameObject post;
    // Start is called before the first frame update
    void Start()
    {
        layer = GameObject.FindGameObjectWithTag("Maze_Layer");
        Floor = GameObject.FindGameObjectWithTag("Floor");

    }

    // Update is called once per frame
    void Update()
    {
        handRight = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);

        if (handRight > 0.9)
        {
            if (CustomLaserPointer.instance.LaserHit())
            {
                StartCoroutine(pinpointLocation());
            }
        }
    }

    IEnumerator pinpointLocation()
    {
        yield return new WaitForSeconds(0.5f);

        RaycastHit hit = CustomLaserPointer.instance.getHit();

        GameObject pinFloor = Instantiate(Floor);
        pinFloor.transform.SetParent(layer.transform, false);
        pinFloor.transform.position = hit.point;

    }
}
