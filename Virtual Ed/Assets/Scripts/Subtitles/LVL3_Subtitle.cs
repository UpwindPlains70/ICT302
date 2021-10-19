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
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Welcome to the Level 3 Tutorial";
        yield return new WaitForSeconds(5);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "You are now responsible to deliver the spike proteins you created in Level 2, from the Golgi Complex through a maze to the cell membrane?";
        yield return new WaitForSeconds(7);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "You control a single spike protein that represents all the spike proteins you created in Level 2";
        yield return new WaitForSeconds(6);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "The spike proteins will follow where you aim your pointer on the maze";
        yield return new WaitForSeconds(6);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Just point your controller where you want the spike proteins to move towards";
        yield return new WaitForSeconds(8);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Give it a go ";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "Be careful, there are holes in the maze that when hit will cause your overall spike protein score to decrease by 1";
        yield return new WaitForSeconds(7);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "The goal is to get as many spike proteins as possible through the maze and deliver them to the cell membrane";
        yield return new WaitForSeconds(6);
        textBox.GetComponent<TMPro.TextMeshProUGUI>().text = "";



    }
}
