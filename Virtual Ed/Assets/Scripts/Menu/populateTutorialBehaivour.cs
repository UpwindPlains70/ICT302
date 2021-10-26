using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class populateTutorialBehaivour : MonoBehaviour
{
    private GameManager GMScript;
    public Button myButton;
    // Start is called before the first frame update
    void Start()
    {
        GMScript = FindObjectOfType<GameManager>();
            //Does not show on button onClick() section
        myButton.onClick.AddListener(delegate { GMScript.setLevelTimesForTutorial(); } );
        myButton.onClick.AddListener(delegate { GMScript.autoLoading = false; } );
        myButton.onClick.AddListener(delegate { GMScript.GameOver = true; } );
        //find online data board and disable
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
