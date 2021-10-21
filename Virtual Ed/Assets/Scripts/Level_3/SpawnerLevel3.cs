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

    void Start()
    {
        GMScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            //Number of game objects to spawn (based on game manager)
        lvl3Manager = GameObject.FindGameObjectWithTag("Level3Manager").GetComponent<Level3Manager>();

        maxScore = lvl3Manager.score;
        //calc remainder
        proteinCount = maxScore % maxWorth;
        proteinCount += (maxScore - proteinCount) / maxWorth;

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

        Transform instance = Instantiate(spawnObject, transform).transform;

        //Edit child scale to counter parents scale
        resetScaleFactor = instance.localScale.y;
        instance.localScale = new Vector3(instance.localScale.x / transform.localScale.x, instance.localScale.z / transform.localScale.z, instance.localScale.z / transform.localScale.z);
        instance.localScale *= resetScaleFactor;    //Increase scale

            //Position object in random position with spawn plane
        instance.localPosition = randpos;
    }
}
