using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Login : MonoBehaviour
{
    public TextMeshProUGUI studentNumber;
    public int sizeLimit = 10;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void add(string s)
    {
        if(studentNumber.text.Length < 10)
            studentNumber.text += s;
    }

    public void Remove()
    {
        studentNumber.text = studentNumber.text.Remove(studentNumber.text.Length - 1);
    }
}
