using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OVRHelper : MonoBehaviour
{
    public GameObject PlayerControl;
    public GameObject UIHelp;
    // Start is called before the first frame update
    public void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            PlayerControl.SetActive(true);
            UIHelp.SetActive(true);
        }
        else
        {
            PlayerControl.SetActive(false);
            UIHelp.SetActive(false);
        }
    }
}
