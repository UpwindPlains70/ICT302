using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRShooter : MonoBehaviour
{

    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpeed = 90;
    //private int ammo;

    public Text ammoTxt;

    private Level4Manager lvl4Manager;
    // Start is called before the first frame update
    void Start()
    {
        lvl4Manager = GameObject.FindGameObjectWithTag("Level4Manager").GetComponent<Level4Manager>();
        //ammo = ;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            if (lvl4Manager.ammo > 0)
            {
                shootBullet();
            }
        }
    }

    void shootBullet()
    {
        //instantiate bullet
        Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        --lvl4Manager.ammo;

        ammoTxt.text = "" + lvl4Manager.ammo;
    }
}
