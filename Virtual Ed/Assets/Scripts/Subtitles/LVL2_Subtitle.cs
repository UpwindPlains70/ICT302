using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LVL2_Subtitle
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
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Welcome to the Level 2 Tutorial";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "This level is ideal to be played sitting down or standing still";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "You will be assembling as many spike proteins as you can from the mRNA strands that have been released from the lipid nanoparticles you collected in Level 1.";
        yield return new WaitForSeconds(6);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "You must identify the three key components required to create a spike protein";
        yield return new WaitForSeconds(6);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "You must grab an mRNA, a tRNA and some amino acids and place them into their designated sites designated by colour.";
        yield return new WaitForSeconds(8);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "To grab and release a particle, simply point at the object you want to grab and hold the button/trigger on the back of the controller, release the button when you want to release the object.";
        yield return new WaitForSeconds(7);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "You can place or throw the component to its corresponding site";
        yield return new WaitForSeconds(7);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Once all three components have been placed in their sites, your spike protein score will increase by 1";
        yield return new WaitForSeconds(8);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Be careful to grab the correct components, as these will not snap to an incorrect site which wastes your precious time";
        yield return new WaitForSeconds(6);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "As the clock winds down, your nanoparticles will decay";
        yield return new WaitForSeconds(6);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "The level will end when the timer reaches zero, or you create the maximum amount of spike proteins possible";
        yield return new WaitForSeconds(6);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "";



    }
}
