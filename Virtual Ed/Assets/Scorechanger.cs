using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorechanger : MonoBehaviour
{
    public Level3Manager lvlManager;

    public int pointsBad = 1;
    // Start is called before the first frame update
    void Start()
    {
        lvlManager = GameObject.FindGameObjectsWithTag("Score");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("badGoal"))
            lvlManager.score -= pointsBad;

        //Prevent negative score
        if (lvlManager.score < 0)
            lvlManager.score = 0;

        lvlManager.currScoreTxt.text = "score: " + lvlManager.score;


        Destroy(collision.gameObject);
    }
}

