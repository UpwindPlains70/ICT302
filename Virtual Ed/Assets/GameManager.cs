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

    internal int totalTimeTaken()
    {
        throw new NotImplementedException();
    }

    internal int totalGivenTime()
    {
        throw new NotImplementedException();
    }
}
