using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    [SerializeField]
    [Tooltip("time to finish level")]
    private float timeLimit;

    [SerializeField]
    [Tooltip("time taken to complete level")]
    private float completionTime;

    [SerializeField]
    [Tooltip("Number of protiens, nanoparticels, etc")]
    private int score;

    [SerializeField]
    [Tooltip("Player support free 'points'")]
    private int bonus;




}
