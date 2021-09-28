using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{
    public SphereCollider charactercollider;
    public SphereCollider blockercollider;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(charactercollider, blockercollider, true);
    }

}
