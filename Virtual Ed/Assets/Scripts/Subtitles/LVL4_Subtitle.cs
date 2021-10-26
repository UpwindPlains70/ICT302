using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LVL4_Subtitle
    : MonoBehaviour
{
    public GameObject textBox;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Sequence());
    }

    // Update is called once per frame
    IEnumerator Sequence()
    {
        yield return new WaitForSeconds(2);
        FindObjectOfType<AudioManagerNarration>().Play("#4#1");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Welcome to the Level 4 Tutorial";
        yield return new WaitForSeconds(3);
        FindObjectOfType<AudioManagerNarration>().Play("#4#2");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "This level is ideal to be played sitting down or standing still";
        yield return new WaitForSeconds(5);
        FindObjectOfType<AudioManagerNarration>().Play("#4#3");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "This tutorial is designed to give you an understanding of your goals for Level 4, and how you can achieve these goals to best prepare you for multiplayer competition";
        yield return new WaitForSeconds(11);
        FindObjectOfType<AudioManagerNarration>().Play("#4#4");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Finally, you can now begin to fire spikes at neighbouring B cells which, in this game will activate them to start producing anti-viral antibodies to the spike";
        yield return new WaitForSeconds(11);
        FindObjectOfType<AudioManagerNarration>().Play("#4#5");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "These antibodies will either destroy the COVID-19 virus, or coat the virus particles, making them unable to bind to a cell";
        yield return new WaitForSeconds(10);
        FindObjectOfType<AudioManagerNarration>().Play("#4#6");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Try and activate as many B cells as possible by shooting them";
        yield return new WaitForSeconds(4);
        FindObjectOfType<AudioManagerNarration>().Play("#4#9");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "If you hit anything other than a B cell it is a waste of spike proteins";
        yield return new WaitForSeconds(5);
        FindObjectOfType<AudioManagerNarration>().Play("#4#7");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Point your controller to aim, and press the trigger button which is the same button for Level 2 on the controller to fire ";
        yield return new WaitForSeconds(8);
        FindObjectOfType<AudioManagerNarration>().Play("#4#8");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Have a go, you have a minute to get comfortable shooting spikes at B cells";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(60);
        FindObjectOfType<AudioManagerNarration>().Play("#4#10");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Any spiking attempts that miss are also a waste of time";
        yield return new WaitForSeconds(4);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(60);
        FindObjectOfType<AudioManagerNarration>().Play("#4#11");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "You will only have 1 minute and 30 seconds to spike as many B cells as possible in multiplayer mode, so be quick!";
        yield return new WaitForSeconds(9);
        FindObjectOfType<AudioManagerNarration>().Play("#4#12");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Your ammo is scarce, use it wisely";
        yield return new WaitForSeconds(4);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "";



    }
}
