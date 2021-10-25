using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoyStickMove : MonoBehaviour
{
    public Transform player;
    public float speed = 1.5f;

    public Transform circle;
    public Transform outerCircle;

    private Vector2 startingPoint;
    private int leftTouch = 99;
    private int i = 0;

    private Vector2 screenBounds;
    private float minX, maxX, minY, maxY;
    public bool manualYmin = true;

    // Start is called before the first frame update
    void Start()
    {
        //Orient screen in landscape
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        // If you want the min max values to update if the resolution changes 
        // set them in update else set them in Start
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        minX = bottomCorner.x;
        maxX = topCorner.x;
        if (!manualYmin)
            minY = bottomCorner.y;
        else
            minY = -1;
        maxY = topCorner.y;

        //Debug.Log("minX: " + minX + " maxX: " + maxX + " minY: " + minY + " maxY: " + maxY);
    }

    // Update is called once per frame
    void Update()
    {
        i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            Vector2 touchPos = getTouchPosition(t.position) * -1;

            Debug.Log(touchPos);
            if (t.phase == TouchPhase.Began)
            {
                leftTouch = t.fingerId;
                startingPoint = touchPos;
                if (t.position.y > Screen.height / 3)
                {
                    //Top 2 thirds of screen are not interactable
                }
                else
                {
                   
                }
            }
            else if (t.phase == TouchPhase.Moved && leftTouch == t.fingerId)
            {
                Vector2 offset = touchPos - startingPoint;
                Vector2 direction = Vector2.ClampMagnitude(offset, 100.0f);
                moveCharacter(direction);

                circle.transform.position = new Vector2(outerCircle.position.x + direction.x, outerCircle.position.y + direction.y);
            }
            else if (t.phase == TouchPhase.Ended && leftTouch == t.fingerId)
            {
                leftTouch = 99;
                circle.transform.position = new Vector2(outerCircle.position.x, outerCircle.position.y);
            }
            ++i;
        }
    }

    Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
    }

    void moveCharacter(Vector2 direction)
    {
        Debug.Log("dir: " + direction);
        //Move player
        player.Translate(direction * speed * Time.deltaTime);

        Vector3 curr = player.position;
        //Move player object to position

        Debug.Log("curr: " + curr);
        player.position = curr;
    }

}
