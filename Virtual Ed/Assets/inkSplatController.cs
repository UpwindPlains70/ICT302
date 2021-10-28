using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inkSplatController : MonoBehaviour
{
    private GameManager GMScript;
    public AnimationClip animIn;
    public AnimationClip animOut;
    public Animation myAnim;
    public Transform image;

    private float delay;
    public float duration = 3;
    private bool active;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animation>();
        GMScript = FindObjectOfType<GameManager>();
        delay = GMScript.getFullCompletionTime() / GMScript.timeLimitToReachLevel(GMScript.currLevelIndex) * Random.Range(3, 5f); 
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(delay);
        //Debug.Log(time);
        if(time > delay && !active)
        {
            active = true;
            myAnim.clip = animIn;
            myAnim.Play();
        }

        if(active && time > delay + duration)
        {
            active = false;
            myAnim.clip = animOut;
            myAnim.Play();
            delay *= Random.Range(2, 3.5f);
            duration = Random.Range(2, 5f);
        }

        time += Time.deltaTime;
    }
}
