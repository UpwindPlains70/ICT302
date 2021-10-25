using UnityEngine;
using UnityEngine.UI;
public class HintImage : MonoBehaviour
{
    public Image hintimage;
    public float ShowForS;
    public float delay;
    private float timerr;
    // Use this for initialization
    void Start()
    {
        hintimage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timerr += Time.deltaTime;
        if (ShowForS > timerr && timerr > delay)
        {
            hintimage.gameObject.SetActive(true);
        }
        if (ShowForS < timerr)
        {

            hintimage.gameObject.SetActive(false);
        }
    }
}