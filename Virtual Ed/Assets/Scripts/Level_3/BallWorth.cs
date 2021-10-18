using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWorth : MonoBehaviour
{
    private Color myColor;
    private Renderer myRenderer;

        //Assigned on spawn
    public int score { 
        get 
        {
            return score; 
        } 
        set 
        { 
            score = value;
            //myColor = new Color(0, 0, score, 1);
            //myRenderer.material.SetColor("_Color", myColor);
        } 
    }

    //Belongs in spawner
    private Level3Manager lvlManager;

    // Start is called before the first frame update
    void Start()
    {
        //Belongs in spawner, score is assigned based on multiples of 5
            //spawner
            //work out total multiples of 5 or 10
            //add an extra one for remainder
            //create ball with max score and last is assigned remainder value
        lvlManager = GameObject.FindGameObjectWithTag("Level4Mananger").GetComponent<Level3Manager>();
        score = lvlManager.score;

        myRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
