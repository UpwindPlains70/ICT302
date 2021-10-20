using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Login : MonoBehaviour
{
    public TextMeshProUGUI inputField;
    public int sizeLimit = 10;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void add(string s)
    {
        if(inputField.text.Length < sizeLimit)
            inputField.text += s;
    }

    public void Remove()
    {
        inputField.text = inputField.text.Remove(inputField.text.Length - 1);
    }
}
