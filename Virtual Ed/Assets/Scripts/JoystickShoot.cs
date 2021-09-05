using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickShoot : MonoBehaviour
{
    public Transform player;
    public Transform bulletSpawn;
    public float speed = 2;
    public GameObject bulletPrefab;
    public float bulletSpeed = 90;

    public Transform circle;
    public Transform outerCircle;

    public bool Rotate = false;

    private Vector2 startingPoint;
    private int leftTouch = 99;
    private int i = 0;

    Rigidbody tmpRBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            Vector2 touchPos = getTouchPosition(t.position) * -1;

            if (t.phase == TouchPhase.Began)
            {
                if(t.position.y > Screen.height / 4)
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

                if (!Rotate)
                    moveCharacter(direction);
                else
                    rotateCharacter(direction);

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

    private void rotateCharacter(Vector2 direction)
    {
        throw new NotImplementedException();
    }

    Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
    }

    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }
    void shootBullet()
    {
        //instantiate bullet
        GameObject b = Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);

        //get rigidbody of bullet
        //tmpRBody = b.GetComponent<Rigidbody>();

        //tmpRBody.AddForce(transform.forward * bulletSpeed);

        //Clean up, remove bullet after 10 seconds
        //Destroy(tmpRBody, 10.0f);
    }
}
