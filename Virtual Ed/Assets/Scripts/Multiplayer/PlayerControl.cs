using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerControl : NetworkBehaviour
{
    public GameManager myGM;
    // Start is called before the first frame update
    void Start()
    {
        //myGM = GameObject.Find(NetworkIdentity.netID)
        DontDestroyOnLoad(gameObject);
    }

}
