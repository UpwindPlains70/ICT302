using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Subtitle_Script_LVL_1 : MonoBehaviour
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
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Welcome to the Level 1 Tutorial";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Look around, what do you see?";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Those are lipid nanoparticles floating around you";
        yield return new WaitForSeconds(6);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Nanoparticles encase the mRNA of the Covid-19 spike protein";
        yield return new WaitForSeconds(6);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "You are playing from perspective of a cell within the body after an injection of the Moderna/Pfizer vaccine.";
        yield return new WaitForSeconds(8);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "It is crucial for the you as the cell to maximise the amount of spike proteins the ribosome can create";
        yield return new WaitForSeconds(7);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Which is directly dependant on the number of nanoparticles you absorb";
        yield return new WaitForSeconds(7);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Absorbing nanoparticles is easy, just point the vacuum gun towards the nanoparticles using the controller";
        yield return new WaitForSeconds(8);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Give it a go";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "See it’s not that hard";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "The goal for you as a cell is to absorb as many of these nanoparticles as possible before the timer runs out";
        yield return new WaitForSeconds(7);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Absorbing the purple nanoparticles will give you points towards your score";
        yield return new WaitForSeconds(6);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "If you absorb the empty grey nanoparticles, you will waste time and lose points.";
        yield return new WaitForSeconds(6);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "";



    }
}
