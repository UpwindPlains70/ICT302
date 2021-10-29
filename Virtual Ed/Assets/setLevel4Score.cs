using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setLevel4Score : MonoBehaviour
{
    private GameManager GMScript;
    private Button myButton;
    // Start is called before the first frame update
    void Start()
    {
        GMScript = FindObjectOfType<GameManager>();
        myButton.onClick.AddListener(() => level4Setup());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void level2Setup()
    {
        GMScript.setLevel1Score();
    }
    public void level3Setup()
    {
        GMScript.setLevel2Score();
    }
    public void level4Setup()
    {
        GMScript.setLevel3Score();
    }
}
