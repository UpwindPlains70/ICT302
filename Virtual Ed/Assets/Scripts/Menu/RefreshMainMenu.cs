using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshMainMenu : MonoBehaviour
{
    public GameObject mainMenuParent;
    public DBUserInterface DB_UI;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuParent = GameObject.FindGameObjectWithTag("UI");
            //OVRPlayercontrol
        mainMenuParent.transform.GetChild(1).gameObject.SetActive(true);
            //UI Helper
        mainMenuParent.transform.GetChild(2).gameObject.SetActive(true);
            //UI parent - MenuSystem
        mainMenuParent.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.SetActive(true);

        DB_UI = mainMenuParent.GetComponent<DBUserInterface>();
        DB_UI.ReloadScoreBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
