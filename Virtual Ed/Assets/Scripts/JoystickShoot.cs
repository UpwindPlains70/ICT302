using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickShoot : MonoBehaviour
{
    public Transform player;
    public Transform weapon;
    private float wsPosY;
    public Transform bulletSpawn;
    public float speed = 2;
    public GameObject bulletPrefab;
    public float bulletSpeed = 90;
    public int ammo = 10;

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
        wsPosY = weapon.position.y;
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
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
        if (ammo < 0)
            GameOver();

        i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            Vector2 touchPos = getTouchPosition(t.position) * -1;

            if (t.phase == TouchPhase.Began)
            {
                if (t.position.y > Screen.height / 4)
                {
                    shootBullet();
                }
                else
                {
                    leftTouch = t.fingerId;
                    startingPoint = touchPos;
                }
            }
            else if (t.phase == TouchPhase.Moved && leftTouch == t.fingerId)
            {
                Vector2 offset = touchPos - startingPoint;
                Vector2 direction = Vector2.ClampMagnitude(offset, 9.0f);
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

    private void GameOver()
    {
        throw new NotImplementedException();
    }

    Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
    }

    void moveCharacter(Vector2 direction)
    {
        Vector3 prevPos = player.position;

        player.Translate(direction * speed * Time.deltaTime);

        Vector3 curr = player.position;
        curr.x = Mathf.Clamp(curr.x, -9.2f, 8.9f);
        curr.y = Mathf.Clamp(curr.y, -1, 7);

        player.position = curr;
        //if not clamped
        if ((curr.x >= -9.2f && curr.x <= 8.9f) || (curr.y >= -1 && curr.y <= 7)) 
            moveWeapon(direction, prevPos);
    }

    private void moveWeapon(Vector2 direction, Vector3 curr)
    {
        if (player.position.y > curr.y)//moving up
            weapon.position -= new Vector3(0, direction.y * Time.deltaTime / 2f, 0);
        else if (player.position.y < curr.y) //move down
        {
            if (weapon.position.y < wsPosY) //stop moving when stat point hit
                weapon.position += new Vector3(0, -direction.y * Time.deltaTime / 2f, 0);
        }

        if (player.position.x > curr.x)
        {//moving left
            weapon.position -= new Vector3(direction.x * Time.deltaTime / 2.5f, 0, 0);
            //weapon.position -= new Vector3(0, direction.y * Time.deltaTime / 10f, 0);
        }
        else if (player.position.x < curr.x)
        {//move right
            weapon.position += new Vector3(-direction.x * Time.deltaTime / 2.5f, 0, 0);
            //weapon.position += new Vector3(0, -direction.y * Time.deltaTime / 10f, 0);
        }
    }

    void shootBullet()
    {
        //instantiate bullet
        Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
    }
}
