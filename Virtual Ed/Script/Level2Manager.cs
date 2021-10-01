using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    [SerializeField]
    SnapToLocation redSnap;

    [SerializeField]
    SnapToLocation greenSnap;

    [SerializeField]
    SnapToLocation blueSnap;

    Level currLevel;

    float timeElapsed = 0;

    private void Awake()
    {
        currLevel = GameManager._Components.GetLevel(1);        
    }

    private void OnEnable()
    {
        redSnap.OnSnapped += OnSnapped;
        greenSnap.OnSnapped += OnSnapped;
        blueSnap.OnSnapped += OnSnapped;
    }

    private void OnDisable()
    {
        redSnap.OnSnapped -= OnSnapped;
        greenSnap.OnSnapped -= OnSnapped;
        blueSnap.OnSnapped -= OnSnapped;
    }

    private void OnSnapped(SnapToLocation obj)
    {
        if (redSnap.Snapped && greenSnap.Snapped && blueSnap.Snapped)
        {
            currLevel.Score++;

            redSnap.DestroySnappedObject();
            greenSnap.DestroySnappedObject();
            blueSnap.DestroySnappedObject();
        }
    }

    private void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= currLevel.TimeLimit)
        {
            GoToNextLevel();
        }
    }

    void GoToNextLevel()
    {
        currLevel.CompletionTime = currLevel.TimeLimit;
        //change level here
    }
}
