using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLevel3 : MonoBehaviour
{
    float dimX;
    float dimY;
    float dimZ;
    public GameObject[] enemy;
        //Set from GameManager
    public int proteinCount;

    private GameObject[] protein_List;
    private const string protein_Tag = "Ball";

    private GameManager GMScript;
    private Level3Manager lvl3Manager;
    private bool setupPhase = true;
    private bool setKinematic = true;

    private float resetScaleFactor;
    private int maxScore;
    public int maxWorth = 5;

    public float positiveX = 1f;
    public float negativeX = 1f;
    public float positiveY = 1f;
    public float negativeY = 1f;
    public float positiveZ = 1f;
    public float negativeZ = 1f;
    void Start()
    {
        GMScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            //Number of game objects to spawn (based on game manager)
        lvl3Manager = GameObject.FindGameObjectWithTag("Level4Manager").GetComponent<Level3Manager>();

        maxScore = lvl3Manager.score;
        //calc remainder
        proteinCount = maxScore % maxWorth;
        proteinCount += (maxScore - proteinCount) / maxWorth;
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
        protein_List = GameObject.FindGameObjectsWithTag(protein_Tag);

        if (protein_List.Length == proteinCount)
            setupPhase = false;

        if (setupPhase)
        {   //Only spawn objects once
            generateCells();
        }
        /*else if (setKinematic)
        {
            foreach (GameObject g in b_Cell_List)
                g.GetComponent<Rigidbody>().isKinematic = true;
            setKinematic = false;
        }*/
        else
            this.transform.DetachChildren();
        
    }
    
    private void generateCells()
    {
        //Populate if not enough
        while (protein_List.Length < proteinCount)
        {
            SpawnInside(enemy[0]);
            protein_List = GameObject.FindGameObjectsWithTag(protein_Tag);
        }
    }

    public void SpawnInside(GameObject spawnObject)
    {
        Vector3 randpos = Vector3.zero;

        randpos.x = Random.Range(0, dimX);//assume mesh of the plane is centered, view mesh.bounds.min.x and mesh.bounds.max.x if not centered
        randpos.z = Random.Range(0, dimZ); //"level" how much up to the plane spawn the objects
        randpos.y = Random.Range(0, dimY); //"level" how much up to the plane spawn the objects

        /*Debug.Log("DX: " + randpos.x);
        Debug.Log("DY: " + randpos.y);
        Debug.Log("DZ: " + randpos.z);*/
        Transform instance = Instantiate(spawnObject).transform;

        instance.transform.position = transform.position;
        //Allow for object to spawn worth less than others
        Debug.Log(maxScore - maxWorth);
        if(maxScore - maxWorth >= 0)
            spawnObject.GetComponent<BallWorth>().score = maxWorth;
        else
            spawnObject.GetComponent<BallWorth>().score = maxScore;

        maxScore -= maxWorth;
        
            //Position object in random position with spawn plane
        instance.position = randpos;
    }
}
