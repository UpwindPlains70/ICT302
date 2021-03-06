using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDecrstuctor : MonoBehaviour
{
    public Level1Manager lvlManager;
    public AudioSource myAudio;

    public int pointsGood = 10;
    public int pointsBad = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (myAudio != null)
            myAudio.Play();

        if(collision.gameObject.CompareTag("NP1"))
            lvlManager.Score += pointsGood;
        else
            lvlManager.Score -= pointsBad;

            //Prevent negative score
        if (lvlManager.Score < 0)
            lvlManager.Score = 0;

        lvlManager.scoreTxt.text = "Score: " + lvlManager.Score;


        Destroy(collision.gameObject);
    }
}
