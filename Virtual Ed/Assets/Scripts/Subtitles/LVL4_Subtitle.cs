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
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Welcome to the Level 4 Tutorial";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Finally, you can now begin to spike nearby neighbouring B cells which activates them to start producing Covid-19 antibodies";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Antibodies will either destroy surrounding Covid-19 cells, or coat them, making them unable to bind to a cell";
        yield return new WaitForSeconds(6);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Try and activate as many B cells as possible by shooting them";
        yield return new WaitForSeconds(6);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Point your controller to aim, and press the trigger button which is the same button for Level 2 on the controller to fire ";
        yield return new WaitForSeconds(8);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "If you hit anything other than a B cell it is a waste of spike proteins";
        yield return new WaitForSeconds(7);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Any spiking attempts that miss are a waste";
        yield return new WaitForSeconds(7);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Your ammo is scarce, use it wisely";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "";



    }
}
