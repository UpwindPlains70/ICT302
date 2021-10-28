using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LVL2_Subtitle
    : MonoBehaviour
{
    public GameObject textBox;
    public bool Android;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Sequence());
    }

    // Update is called once per frame
    IEnumerator Sequence()
    {
        yield return new WaitForSeconds(2);
        FindObjectOfType<AudioManagerNarration>().Play("#2#1");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Welcome to the Level 2 Tutorial";
        yield return new WaitForSeconds(3);
        FindObjectOfType<AudioManagerNarration>().Play("#2#2");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "This level is ideal to be played sitting down or standing still";
        yield return new WaitForSeconds(4);
        FindObjectOfType<AudioManagerNarration>().Play("#2#3");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "This tutorial is designed to best prepare you for multiplayer mode, by building your understanding of the goals for Level 2, and how you achieve these goals.";
        yield return new WaitForSeconds(10);
        FindObjectOfType<AudioManagerNarration>().Play("#2#4");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "You will be assembling as many spike proteins as you can from the translation of mRNA strands that have been released from the lipid nanoparticles that you collected in Level 1.";
        yield return new WaitForSeconds(11);
        FindObjectOfType<AudioManagerNarration>().Play("#2#5");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "In the game the mRNA strands will decay every half a second, however they decay approximately every 4.8 minutes in real life";
        yield return new WaitForSeconds(9);
        FindObjectOfType<AudioManagerNarration>().Play("#2#6");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Which means the maximum amount of spike proteins that you can make in this level will reduce over time, so be quick when you're playing multiplayer mode";
        yield return new WaitForSeconds(9);
        FindObjectOfType<AudioManagerNarration>().Play("#2#7");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "You must identify the three key components required to create a spike protein";
        yield return new WaitForSeconds(5);
        FindObjectOfType<AudioManagerNarration>().Play("#2#8");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "You must grab some mRNA strands, tRNA molecules and some amino acids and place them into their designated boxes designated by matching colours.";
        yield return new WaitForSeconds(11);
        if (Android == false)
        {
            FindObjectOfType<AudioManagerNarration>().Play("#2#9");
            textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "To grab and release a particle, simply point at the object you want to grab and hold the button/trigger on the back of the controller, release the button when you want to release the object.";
            yield return new WaitForSeconds(12);
        }
        else
        {
            FindObjectOfType<AudioManagerNarration>().Play("#2#9.5");
            textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "To grab and release a particle, simply touch, and hold the object on screen to move it around, when you want to release the object, just stop touching the screen.";
            yield return new WaitForSeconds(12);
        }
        FindObjectOfType<AudioManagerNarration>().Play("#2#10");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "You can place or throw the component to its corresponding box";
        yield return new WaitForSeconds(5);
        FindObjectOfType<AudioManagerNarration>().Play("#2#11");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Once all three components have been placed in their boxes, your spike protein score will increase by 1";
        yield return new WaitForSeconds(7);
        FindObjectOfType<AudioManagerNarration>().Play("#2#11.5");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "This tutorial level will finish when the timer reaches zero, or you create 10 spike proteins";
        yield return new WaitForSeconds(7);
        FindObjectOfType<AudioManagerNarration>().Play("#2#12");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Give it a go, get comfortable placing the spike protein components in their correct boxes to make maximum use of the 1 minute and 30 second multiplayer mode time limit";
        yield return new WaitForSeconds(8);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "You will now have a minute to yourself to get comfortable playing Level 2";
        yield return new WaitForSeconds(7);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(60);
        FindObjectOfType<AudioManagerNarration>().Play("#2#13");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Be careful to grab the correct components, as these will not snap to an incorrect box which wastes your precious time so use your time wisely when playing competitively";
        yield return new WaitForSeconds(11);
        FindObjectOfType<AudioManagerNarration>().Play("#2#14");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "The multiplayer mode level will end when the timer reaches zero, or you create the maximum amount of spike proteins possible";
        yield return new WaitForSeconds(7);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "";



    }
}
