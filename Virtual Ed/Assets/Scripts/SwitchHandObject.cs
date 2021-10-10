using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//useful for levels that have an in hand game object and hide it when game is paused
public class SwitchHandObject : MonoBehaviour
{
    public GameObject handPrefab;
    public GameObject gameHandPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            handPrefab.SetActive(true);
            gameHandPrefab.SetActive(false);
        }
        else
        {
            handPrefab.SetActive(false);
            gameHandPrefab.SetActive(true);
        }
    }
}
