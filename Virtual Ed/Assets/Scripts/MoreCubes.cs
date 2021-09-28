using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreCubes : MonoBehaviour
{
    public GameObject cubePrefab;

    // Start is called before the first frame update
    public void Cube()
    {
        Instantiate(cubePrefab);
    }

    
}
