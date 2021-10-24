using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LVL3_Subtitle
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
        FindObjectOfType<AudioManagerNarration>().Play("#3#1");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Welcome to the Level 3 Tutorial";
        yield return new WaitForSeconds(3);
        FindObjectOfType<AudioManagerNarration>().Play("#3#2");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "This level is ideal to be played sitting down or standing still";
        yield return new WaitForSeconds(4);
        FindObjectOfType<AudioManagerNarration>().Play("#3#3");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "This tutorial is designed to give you an understanding of your goals for Level 3, and how you can achieve these goals to best prepare you for multiplayer competition";
        yield return new WaitForSeconds(10);
        FindObjectOfType<AudioManagerNarration>().Play("#3#4");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "You are now responsible to deliver the spike proteins you created in Level 2, that are traversing the Golgi Complex through a maze to the cell membrane";
        yield return new WaitForSeconds(10);
        FindObjectOfType<AudioManagerNarration>().Play("#3#5");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "You control a single spike protein that cumulatively represents all the spike proteins you created in Level 2";
        yield return new WaitForSeconds(8);
        FindObjectOfType<AudioManagerNarration>().Play("#3#6");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "The spike proteins will follow where you aim your pointer on the maze";
        yield return new WaitForSeconds(5);
        FindObjectOfType<AudioManagerNarration>().Play("#3#7");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Just point your controller where you want the spike proteins to move towards";
        yield return new WaitForSeconds(5);
        FindObjectOfType<AudioManagerNarration>().Play("#3#8");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "A hint: to change your view of the maze, you can walk around by moving the left joystick in the direction you want to walk";
        yield return new WaitForSeconds(8);
        FindObjectOfType<AudioManagerNarration>().Play("#3#9");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Additionally, you can snap your view to a direction by moving the right joystick in that direction";
        yield return new WaitForSeconds(6);
        FindObjectOfType<AudioManagerNarration>().Play("#3#10");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Give it a go, get comfortable leading the spike proteins through the maze for a minute ";
        yield return new WaitForSeconds(70);
        FindObjectOfType<AudioManagerNarration>().Play("#3#11");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        yield return new WaitForSeconds(8);
        FindObjectOfType<AudioManagerNarration>().Play("#3#12");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Be careful, there are holes in the maze that when hit by a spike protein, will cause your score to decrease by 1";
        yield return new WaitForSeconds(7);
        FindObjectOfType<AudioManagerNarration>().Play("#3#13");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "The goal is to get as many spike proteins as possible through the maze and deliver them to the cell membrane";
        yield return new WaitForSeconds(6);
        FindObjectOfType<AudioManagerNarration>().Play("#3#");
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "";



    }
}
