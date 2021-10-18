using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorechanger : MonoBehaviour
{
    private Level3Manager lvlManager;

    public int pointsBad = 1;
    // Start is called before the first frame update
    void Start()
    {
        lvlManager = GameObject.FindGameObjectWithTag("Level4Manager").GetComponent<Level3Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
            //BallWorth currBallWorth = other.gameObject.GetComponent<BallWorth>();
        //Debug.Log(currBallWorth.score);
                //Reduce score and ball worth
            //currBallWorth.score -= pointsBad;
            lvlManager.score -= pointsBad;

            //Prevent negative score
            //if (currBallWorth.score < 0)
            //    Destroy(other.gameObject);

            lvlManager.currScoreTxt.text = "Score: " + lvlManager.score;
    }
}

