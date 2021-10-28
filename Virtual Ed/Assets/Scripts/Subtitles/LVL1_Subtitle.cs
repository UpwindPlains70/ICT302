using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LVL1_Subtitle
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
        FindObjectOfType<AudioManagerNarration>().Play("#1#1");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Welcome to the Level 1 Tutorial";
        yield return new WaitForSeconds(3);
        FindObjectOfType<AudioManagerNarration>().Play("#1#3");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Walking around is not ideal for this level, however you can if you please.";
        yield return new WaitForSeconds(5);
        FindObjectOfType<AudioManagerNarration>().Play("#1#2");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "This tutorial is designed to give you an understanding of the contents and objectives of Level 1 as well as a guide through the controls to help you achieve a high score in multiplayer mode.";
        yield return new WaitForSeconds(11);
        FindObjectOfType<AudioManagerNarration>().Play("#1#4");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Look around, what do you see?";
        yield return new WaitForSeconds(2);
        FindObjectOfType<AudioManagerNarration>().Play("#1#5");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Those are lipid nanoparticles floating around you";
        yield return new WaitForSeconds(3);
        FindObjectOfType<AudioManagerNarration>().Play("#1#6");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "The Moderna/Pfizer injection contains around 30 micrograms of these nanoparticles";
        yield return new WaitForSeconds(7);
        FindObjectOfType<AudioManagerNarration>().Play("#1#7");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Nanoparticles encase the mRNA of the Covid-19 spike protein";
        yield return new WaitForSeconds(5);
        FindObjectOfType<AudioManagerNarration>().Play("#1#8");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "You are playing from the perspective of a cell within the body after an injection of the Moderna/Pfizer vaccine.";
        yield return new WaitForSeconds(8);
        FindObjectOfType<AudioManagerNarration>().Play("#1#9");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "It is crucial for the you as the cell to maximise the amount of spike proteins the ribosomes can create";
        yield return new WaitForSeconds(7);
        FindObjectOfType<AudioManagerNarration>().Play("#1#10");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Which in this game, is directly dependant on the number of nanoparticles you absorb";
        yield return new WaitForSeconds(6);
        if (Android == true)
        {
            FindObjectOfType<AudioManagerNarration>().Play("#1#11.5");
            textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Absorbing nanoparticles is easy, just use the joystick on screen to aim the gun";
            yield return new WaitForSeconds(6);
        }
        else
        {
            FindObjectOfType<AudioManagerNarration>().Play("#1#11");
            textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Absorbing nanoparticles is easy, just point the controller towards the nanoparticles";
            yield return new WaitForSeconds(6);
        }
        FindObjectOfType<AudioManagerNarration>().Play("#1#13");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Give it a go, get comfortable absorbing the correct nanoparticles";
        yield return new WaitForSeconds(7);
        FindObjectOfType<AudioManagerNarration>().Play("#1#13.5");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "This tutorial level will finish when the timer reaches zero, or your score reaches 400";
        yield return new WaitForSeconds(7);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(60);
        FindObjectOfType<AudioManagerNarration>().Play("#1#14");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "See it’s not that hard";
        yield return new WaitForSeconds(2);
        FindObjectOfType<AudioManagerNarration>().Play("#1#15");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "The goal for you as a cell is to absorb as many of these nanoparticles as possible before the timer runs out";
        yield return new WaitForSeconds(7);
        FindObjectOfType<AudioManagerNarration>().Play("#1#16");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Absorbing the blue nanoparticles will give you points towards your score";
        yield return new WaitForSeconds(4);
        FindObjectOfType<AudioManagerNarration>().Play("#1#17");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "However, If you absorb the empty brown nanoparticles, you will lose points and waste time.";
        yield return new WaitForSeconds(7);
        FindObjectOfType<AudioManagerNarration>().Play("#1#18");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Remember, in multiplayer mode you will only get 1 minute and 30 seconds to absorb nanoparticles";
        yield return new WaitForSeconds(8);
        FindObjectOfType<AudioManagerNarration>().Play("#1#19");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Your score and time remaining can be seen in the background of the level you are playing";
        yield return new WaitForSeconds(7);
        FindObjectOfType<AudioManagerNarration>().Play("#1#20");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "You can also see a top 10 leader board – try and beat your friend’s scores!";
        yield return new WaitForSeconds(6);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "";



    }
}
