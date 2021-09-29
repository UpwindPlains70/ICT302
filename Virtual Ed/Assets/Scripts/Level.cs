using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    [SerializeField]
    [Tooltip("Name of scene")]
    private string _sceneName;

    [SerializeField]
    [Tooltip("Time to finish level")]
    private float timeLimit;

    [SerializeField]
    [Tooltip("Time taken to complete level")]
    private float completionTime;

    [SerializeField]
    [Tooltip("Number of protiens, nanoparticels, etc")]
    private int score;

    [SerializeField]
    [Tooltip("Player support 'free points'")]
    private int bonus;

    public string SceneName
    {
        get { return _sceneName; }
        set { _sceneName = value; }
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public int Bonus
    {
        get { return bonus; }
    }

    public float TimeLimit
    { 
        get { return timeLimit; } 
    }

    public float CompletionTime
    {
        get { return completionTime; }
        set { completionTime = value; }
    }
}
