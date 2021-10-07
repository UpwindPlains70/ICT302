using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class DBUserInterface : MonoBehaviour
{
    public TextMeshPro StudentNumber;
    public string StudentNumberDisplayText;
    //public InputField Highscore;

    public List<Text> PlayerNames = new List<Text>();
    public List<Text> GameIDs = new List<Text>();
    public List<Text> DateAndTimes = new List<Text>();
    public List<Text> FinalScores = new List<Text>();
    public List<Text> FinalTimeTakens = new List<Text>();
    //public List<Text> Highscores = new List<Text>();
    DBInterface DBInterface;

    // Start is called before the first frame update

    void Start()
    {
        DBInterface = FindObjectOfType<DBInterface>();
    }

    public void InsertStudentNumber()
    {
        if (DBInterface == null)
        {
            Debug.LogError("DBUserInterface: Could not insert a highscore. DBIitefrace is not present.");
            return;
        }
        if (StudentNumber == null)
        {
            Debug.LogError("DBUserInterface: Could not insert a highscore. StudentNumber or Highscore is not set.");
            return;
        }
        if (string.IsNullOrEmpty(StudentNumber.text) || string.IsNullOrWhiteSpace(StudentNumber.text))
        {
            Debug.LogError("DBUserInterface: Could not insert a highscore. StudentNumber is empty.");
            return;
        }

        DBInterface.InsertStudentNumber(StudentNumber.text);
        StudentNumberDisplayText = StudentNumber.text;
       // StudentNumber.text = "";

    }




    
    
    public void DisplayGameDataFromDB()
    {
        if (DBInterface == null)
        {
            Debug.LogError("DBUserInterface: Could not retrieve data. DBIitefrace is not present.");
            return;
        }
        if (PlayerNames.Count < 1)
        {
            Debug.LogError("DBUserInterface: Could not retrieve data. Not all StudentNumber labels are present.");
            return;
        }
        
        clearScoreboard();
        List<System.Tuple<ulong, string, DateTime>> highscores = DBInterface.DisplayGameDataFromDB();
        for (int i = 0; i < highscores.Count; i++)
        {

            GameIDs[i].text = highscores[i].Item1.ToString();
            PlayerNames[i].text = highscores[i].Item2;
            DateAndTimes[i].text = highscores[i].Item3.ToString();

        
        }
        
        
    }



    
    public void DisplayFinalScores()
    {
        if (DBInterface == null)
        {
            Debug.LogError("DBUserInterface: Could not retrieve data. DBIitefrace is not present.");
            return;
        }

        clearScoreboard();
        //Debug.Log("DisplayFinalScores StudentNumber is equal to " + StudentNumber.text);
        List<System.Tuple<int, int>> highscores = DBInterface.DisplayFinalScores(StudentNumberDisplayText);
        
        for (int i = 0; i < highscores.Count; i++)
        {

            FinalScores[i].text = highscores[i].Item1.ToString();
            FinalTimeTakens[i].text = highscores[i].Item2.ToString();


        }
        

    }

    



    private void clearScoreboard()
    {
        foreach (Text StudentNumber in PlayerNames)
        {
            StudentNumber.text = "";
        }
        /*
        foreach (Text highscore in Highscores)
        {
            highscore.text = "";
        }
        */

    }







}

    













