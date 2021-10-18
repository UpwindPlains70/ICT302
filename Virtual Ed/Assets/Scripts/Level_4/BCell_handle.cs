using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCell_handle : MonoBehaviour
{
    private bool activated = false;
    private ParticleSystem ps;

    public float hSliderValueR = 0.0F;
    public float hSliderValueG = 0.0F;
    public float hSliderValueB = 0.0F;
    public float hSliderValueA = 1.0F;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    public bool isActive()
    { 
        return activated;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void changeParticleColor()
    {
        var subEmitter = ps.subEmitters;
        subEmitter.enabled = true;
        
        var col = ps.colorOverLifetime;
        col.enabled = true;

        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.white, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });

        col.color = grad;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            if (!activated)
            {
                    //50% chance of changing particle color
                if(Random.Range(0,2) == 1)
                    changeParticleColor();

                    //play particle system
                ps.Play();
                    //play burst animation
                this.GetComponent<Animation>().Play();
                    //Prevent object from being activated again
                activated = true;
            }
        }
    }
}
