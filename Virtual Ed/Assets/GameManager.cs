using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager comp;
    [SerializeField]
    private List<Level> levels = new List<Level>();

    public static GameManager _Components
    {
        get
        {
            return comp;
        }
    }

    private bool gameOver = false;

    public bool GameOver { 
        get { return gameOver; }
        set { gameOver = value; }
    }

    private void Awake()
    {
        Debug.Log("manager started");
        if (comp == null)
        {
            comp = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (comp != this)
                Destroy(gameObject);
        }
    }

    private void Update()
    {
        
    }

    public void addToServer()
    {
        //add all level information to server
        Debug.Log("Level data Saved");
    }

    public float totalTimeTaken()
    {
        float totalTime = 0;
        foreach (Level lvl in levels)
            totalTime += lvl.CompletionTime;

        return totalTime;
    }

    public float totalGivenTime()
    {
        float totalTime = 0;
        foreach (Level lvl in levels)
            totalTime += lvl.TimeLimit;

        return totalTime;
    }

    public Level GetLevel(int n)
    {
        return levels[n];
    }
}
