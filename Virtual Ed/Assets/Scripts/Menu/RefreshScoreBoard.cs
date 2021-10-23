using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshScoreBoard : MonoBehaviour
{
    private DBUserInterface DB_UI;
    // Start is called before the first frame update
    void Start()
    {
        DB_UI = FindObjectOfType<DBUserInterface>();
        DB_UI.ReloadScoreBoard();
        DB_UI.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
