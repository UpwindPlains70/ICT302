using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class populateSingleplayerBehaivour : MonoBehaviour
{
    private GameManager GMScript;
    public Button myButton;
    // Start is called before the first frame update
    void Start()
    {
        GMScript = FindObjectOfType<GameManager>();
            //Does not show on button onClick() section
        myButton.onClick.AddListener(delegate { GMScript.setLevelTimesForCompetitivePlay(); } );
        myButton.onClick.AddListener(delegate { GMScript.singleplayer = true; } );
        myButton.onClick.AddListener(delegate { GMScript.autoLoading = true; } );
        myButton.onClick.AddListener(delegate { GMScript.GameOver = false; } );
        myButton.onClick.AddListener(delegate { GMScript.LoadFirstLevel(); } );
        //find online data board and disable
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.P))
            myButton.onClick.Invoke();
    }
}
