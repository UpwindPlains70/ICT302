using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshScoreBoard : MonoBehaviour
{
    public DBUserInterface DB_UI;
    // Start is called before the first frame update
    void Start()
    {
        DB_UI = FindObjectOfType<DBUserInterface>();
        DB_UI.ReloadScoreBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
