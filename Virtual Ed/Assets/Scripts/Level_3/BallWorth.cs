using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWorth : MonoBehaviour
{
    private Color myColor;
    public Renderer myRenderer;
    public float _score;
    private float originalScore;
    public List<Material> matList = new List<Material>();

    //Assigned on spawn
    public float score {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            myColor = new Color(0, 0, _score, 1);
        }
    }

    //Belongs in spawner
    private Level3Manager lvlManager;

    private void Awake()
    {
        //myRenderer = GetComponent<Renderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Belongs in spawner, score is assigned based on multiples of 5
        //spawner
        //work out total multiples of 5 or 10
        //add an extra one for remainder
        //create ball with max score and last is assigned remainder value
        lvlManager = GameObject.FindGameObjectWithTag("Level4Manager").GetComponent<Level3Manager>();
        //myRenderer = GetComponent<Renderer>();
        originalScore = 
        score = score;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        materialChangeSwitch();
        //materialChange();

        if (score <= 0)
            Destroy(gameObject);
    }

    void materialChange()
    {
        Debug.Log(score / originalScore);
        if(score / originalScore >= 0.8f)
            myRenderer.material = matList[0];
        else if (score / originalScore >= 0.6f) 
            myRenderer.material = matList[1];
        else if (score / originalScore >= 0.4f)
            myRenderer.material = matList[2];
        else if (score / originalScore >= 0.2f)
            myRenderer.material = matList[3];
        else
            myRenderer.material = matList[4];
         
    }

    void materialChangeSwitch()
    {
        switch(_score)
        {
            case 1:
                myRenderer.material = matList[4];
                break;
            case 2:
                myRenderer.material = matList[3];
                break;
            case 3:
                myRenderer.material = matList[2];
                break;
            case 4:
                myRenderer.material = matList[1];
                break;
            case 5:
                myRenderer.material = matList[0];
                break;
        }

    }
}
