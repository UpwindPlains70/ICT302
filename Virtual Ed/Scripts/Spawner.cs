using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float dimX;
    float dimY;
    float dimZ;
    public GameObject[] enemy;
        //Set from GameManager
    private int B_Cell_Count;
        //Reduce covid cell count
    public float positivePenalty = 0.5f;
        //Increase covid cell count
    public float negativePenalty = 1f;

    //Assigned by function (increase/decrease percetage for covid cells)
    private float latePenalty = 1f;

    private GameObject[] b_Cell_List;
    private GameObject[] covid_Cell_List;
    private const string b_Cell_Tag = "B-Cell";
    private const string covid_Cell_Tag = "Covid-Cell";

    private GameManager GMScript;
    private Level4Manager lvl4Manager;
    private bool setupPhase = true;
    private bool setKinematic = true;

    public bool dimension3 = false;
    public float positiveX = 2f;
    public float negativeX = 2f;
    public float positiveY = 2f;
    public float negativeY = 2f;
    public float positiveZ = 2f;
    public float negativeZ = 2f;

    private float resetScaleFactor;

    void Start()
    {
        GMScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            //Number of game objects to spawn (based on game manager)
        lvl4Manager = GameObject.FindGameObjectWithTag("Level4Manager").GetComponent<Level4Manager>();
        B_Cell_Count = lvl4Manager.getAmmo();

        //latePenalty = calcLatePenalty();

        //Assign size of spawner plane
        Mesh _mesh = transform.GetComponent<MeshFilter>().mesh;
        dimX = _mesh.bounds.size.x;
        dimY = _mesh.bounds.size.y;
        dimZ = _mesh.bounds.size.z;
    }

    //to test purpose, attach to default plane and set a gameobject on spawntest variable
    void FixedUpdate()
    {        
            //Count cells on screen
        b_Cell_List = GameObject.FindGameObjectsWithTag(b_Cell_Tag);
        covid_Cell_List = GameObject.FindGameObjectsWithTag(covid_Cell_Tag);

        if (b_Cell_List.Length == B_Cell_Count && covid_Cell_List.Length == B_Cell_Count * latePenalty)
            setupPhase = false;

        if (setupPhase)
            generateCells();
        else if (setKinematic)
        {
            foreach (GameObject g in b_Cell_List)
                g.GetComponent<Rigidbody>().isKinematic = true;
            setKinematic = false;
        }
        else
          this.transform.DetachChildren();
        
    }

    private void generateCells()
    {
        //Populate if not enough
        while (b_Cell_List.Length < B_Cell_Count)
        {
            SpawnInside(enemy[0], false);
            b_Cell_List = GameObject.FindGameObjectsWithTag(b_Cell_Tag);
        }

        while (covid_Cell_List.Length < (B_Cell_Count * latePenalty))
        {
            SpawnInside(enemy[1], true);
            covid_Cell_List = GameObject.FindGameObjectsWithTag(covid_Cell_Tag);
        }

    }

    float calcLatePenalty()
    {
        float tmpPenalty = (GMScript.totalTimeTaken() / GMScript.totalGivenTime());
        
        return tmpPenalty > 0.25f ? tmpPenalty + negativePenalty : tmpPenalty + positivePenalty;
    }

    public void SpawnInside(GameObject spawnObject, bool offset)
    {
        Vector3 randpos = Vector3.zero;

        randpos.x = Random.Range(-dimX / negativeX, dimX / positiveX);//assume mesh of the plane is centered, view mesh.bounds.min.x and mesh.bounds.max.x if not centered
        randpos.z = Random.Range(-dimZ / negativeY, dimZ / positiveY); //"level" how much up to the plane spawn the objects
   
        if (dimension3 || offset)
        {
            if (dimension3)
                randpos.y = Random.Range(-dimY / negativeY, dimY / positiveY); //0f;//"level" how much up to the plane spawn the objects
            else
                randpos.y = Random.Range(0, dimY / positiveZ);
        }
        Transform instance = Instantiate(spawnObject, transform).transform;

        //Edit child scale to counter parents scale
        resetScaleFactor = instance.localScale.y;
        instance.localScale = new Vector3(instance.localScale.x / transform.localScale.x, instance.localScale.z / transform.localScale.z, instance.localScale.z / transform.localScale.z);
        instance.localScale *= resetScaleFactor;    //Increase scale

            //Position object in random position with spawn plane
        instance.localPosition = randpos;
    }
}
