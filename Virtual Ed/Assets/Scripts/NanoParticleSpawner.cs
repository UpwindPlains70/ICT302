using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanoParticleSpawner : MonoBehaviour
{
    float dimX;
    float dimY;
    float dimZ;
        //Tag of enemy in enemy[] with same index
    public string[] enemyTags;
    public GameObject[] enemy;
    public int maxEnemyCount = 10;
    //Reduce covid cell count
    public float positivePenalty = 0.5f;
    //Increase covid cell count
    public float negativePenalty = 1f;

    //Assigned by function (increase/decrease percetage for covid cells)
    private float latePenalty = 1f;

        //General array containing number of enemies on screen
    private int[] enemyCounter;

    private GameManager GMScript;
    private bool setupPhase = true;
    //private bool setKinematic = true;

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

            //Set size of counter
        enemyCounter = new int[enemy.Length];

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
        for (int i = 0; i < enemy.Length; ++i)
            enemyCounter[i] = GameObject.FindGameObjectsWithTag(enemyTags[i]).Length;

        //if (NP1_List.Length == NanoParticle_Count && NP2_List.Length == NanoParticle_Count)
        //    setupPhase = false;

        //if (setupPhase)
            generateCells();
        //else
            this.transform.DetachChildren();

    }

    private void generateCells()
    {
        //Populate if not enough
        for (int i = 0; i < enemyCounter.Length; ++i)
        {
            while(enemyCounter[i] < maxEnemyCount)
            {
                SpawnInside(enemy[i]);
                enemyCounter[i] = GameObject.FindGameObjectsWithTag(enemyTags[i]).Length;
            }
        }
    }

    public void SpawnInside(GameObject spawnObject)
    {
        Vector3 randpos = Vector3.zero;

        randpos.x = Random.Range(-dimX / negativeX, dimX / positiveX);//assume mesh of the plane is centered, view mesh.bounds.min.x and mesh.bounds.max.x if not centered
        randpos.z = Random.Range(-dimZ / negativeY, dimZ / positiveY); //"level" how much up to the plane spawn the objects


        if (dimension3)
            randpos.y = Random.Range(-dimY / negativeY, dimY / positiveY); //0f;//"level" how much up to the plane spawn the objects
        else
            randpos.y = Random.Range(0, dimY / positiveZ);
        
        Transform instance = Instantiate(spawnObject, transform).transform;

        //Edit child scale to counter parents scale
        resetScaleFactor = instance.localScale.y;
        instance.localScale = new Vector3(instance.localScale.x / transform.localScale.x, instance.localScale.z / transform.localScale.z, instance.localScale.z / transform.localScale.z);
        instance.localScale *= resetScaleFactor;    //Increase scale

        //Position object in random position with spawn plane
        instance.localPosition = randpos;
    }
}
