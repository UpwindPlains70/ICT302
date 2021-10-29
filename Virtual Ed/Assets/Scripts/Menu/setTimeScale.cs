using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setTimeScale : MonoBehaviour
{
    public DBInterface DBIScript;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        DBIScript = FindObjectOfType<DBInterface>();
        if (!string.IsNullOrEmpty(DBIScript.studentNumber) & !string.IsNullOrWhiteSpace(DBIScript.userName))
        {
            GameObject.FindGameObjectWithTag("TutorialBtn").GetComponent<Button>().interactable = true;
            GameObject tmp = GameObject.FindGameObjectWithTag("UI").transform.GetChild(1).gameObject;
            DBIScript.level2Btn = tmp.transform.GetChild(1).gameObject.transform.GetChild(3).GetComponent<Button>();
            DBIScript.level3Btn = tmp.transform.GetChild(1).gameObject.transform.GetChild(4).GetComponent<Button>();
            DBIScript.level4Btn = tmp.transform.GetChild(1).gameObject.transform.GetChild(5).GetComponent<Button>();
            DBIScript.SingleplayerBtn = GameObject.FindGameObjectWithTag("SingleplayerBtn").GetComponent<Button>();
            DBIScript.CheckTutorialProgress(DBIScript.studentNumber);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
