using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshScoreBoard : MonoBehaviour
{
    private DBUserInterface DB_UI;
    private GameObject MainMenu_UI;
    // Start is called before the first frame update
    void Start()
    {
        MainMenu_UI = GameObject.FindGameObjectWithTag("UI");
        MainMenu_UI.SetActive(true);

        DB_UI = FindObjectOfType<DBUserInterface>();
        DB_UI.ReloadScoreBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
