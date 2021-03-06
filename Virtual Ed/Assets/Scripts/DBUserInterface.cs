using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class DBUserInterface : MonoBehaviour
{
    public bool mobile = false;
    public TextMeshProUGUI StudentNumber;
    public TextMeshProUGUI UserName;
    public string StudentNumberDisplayText;
    public string UserNameDisplayText;
    //public InputField Highscore;

    public List<Text> PlayerNames = new List<Text>();
    public List<Text> UserNames = new List<Text>();

    public List<Text> GameIDs = new List<Text>();
    public List<Text> DateAndTimes = new List<Text>();
    //public List<Text> FinalScores = new List<Text>();
    //public List<Text> FinalTimeTakens = new List<Text>();

    public List<Text> HighScoreFinalScores = new List<Text>();
    public List<Text> HighScoreFinalTimeTakens = new List<Text>();
    public List<Text> HighScoreDateAndTimes = new List<Text>();

    public List<Text> GLOBALUserNames = new List<Text>();
    public List<Text> GLOBALFinalScores = new List<Text>();
    public List<Text> GLOBALFinalTimeTakens = new List<Text>();
    public List<Text> GLOBALDateAndTimes = new List<Text>();

    //public List<Text> Highscores = new List<Text>();
    DBInterface DBInterface;

    // Start is called before the first frame update
    void Start()
    {        
        DBInterface = FindObjectOfType<DBInterface>();
        StudentNumberDisplayText = DBInterface.studentNumber;
        UserNameDisplayText = DBInterface.userName;
        ReloadScoreBoard();
    }

    public void populateStudentNumLogin()
    {

        StudentNumber = GameObject.FindGameObjectWithTag("StudentNumber").GetComponent<TextMeshProUGUI>();
        StudentNumber.text = StudentNumberDisplayText;
    }

    public void populateUsernameLogin()
    {
        UserName = GameObject.FindGameObjectWithTag("UserName").GetComponent<TextMeshProUGUI>();
        UserName.text = UserNameDisplayText;
    }
    
    public void ReloadScoreBoard()
    {
        if (!string.IsNullOrEmpty(StudentNumberDisplayText) & !string.IsNullOrWhiteSpace(UserNameDisplayText))
        {
            DisplayGameDataFromDB();
            RetrieveTopFiveFinalScores();
            RetrieveTopGLOBALFinalScores();

            if (mobile == false)
            {
            //Display scoreboard canvas if player is logged in
            GameObject.FindGameObjectWithTag("UI").transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    public void InsertStudentNumber()
    {
        if (DBInterface == null)
        {
            Debug.LogError("DBUserInterface: Could not insert a highscore. DBIitefrace is not present.");
            return;
        }
        if (StudentNumber == null || UserName == null)
        {
            Debug.LogError("DBUserInterface: Could not insert a StudentNumber or UserName. StudentNumber or UserName is not set.");
            return;
        }
        if (string.IsNullOrEmpty(StudentNumber.text) || string.IsNullOrWhiteSpace(StudentNumber.text))
        {
            Debug.LogError("DBUserInterface: Could not insert a StudentNumber. StudentNumber is empty.");
            return;
        }
        if (string.IsNullOrEmpty(UserName.text) || string.IsNullOrWhiteSpace(UserName.text))
        {
            Debug.LogError("DBUserInterface: Could not insert a Username. UserName is empty.");
            return;
        }

        DBInterface.InsertStudentNumber(StudentNumber.text, UserName.text);
        StudentNumberDisplayText = StudentNumber.text;
        UserNameDisplayText = UserName.text;

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

        List<System.Tuple<ulong, string, DateTime, string>> highscores = DBInterface.DisplayGameDataFromDB();
        for (int i = 0; i < highscores.Count; i++)
        {

            GameIDs[i].text = highscores[i].Item1.ToString();
            PlayerNames[i].text = highscores[i].Item2;
            DateAndTimes[i].text = highscores[i].Item3.ToString();
            UserNames[i].text = highscores[i].Item4;
        }
    }



    /*
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
            Debug.Log("Final Score: " + i + "  |  "+highscores[i].Item1);
            FinalScores[i].text = highscores[i].Item1.ToString();
            FinalTimeTakens[i].text = highscores[i].Item2.ToString();
        }
    }

    */

    public void RetrieveTopFiveFinalScores()
    {
        if (DBInterface == null)
        {
            Debug.LogError("DBUserInterface: Could not retrieve data. DBIitefrace is not present.");
            return;
        }

        List<System.Tuple<int, int, DateTime>> highscores = DBInterface.RetrieveTopFiveFinalScores(StudentNumberDisplayText);

        for (int i = 0; i < highscores.Count; i++)
        {
            if (highscores[i].Item2 > 0)
            {
                HighScoreFinalScores[i].text = highscores[i].Item1.ToString();
                HighScoreFinalTimeTakens[i].text = highscores[i].Item2.ToString();
                HighScoreDateAndTimes[i].text = highscores[i].Item3.ToString();
            }
        }
    }

    public void RetrieveTopGLOBALFinalScores()
    {
        if (DBInterface == null)
        {
            Debug.LogError("DBUserInterface: Could not retrieve data. DBIitefrace is not present.");
            return;
        }

        List<System.Tuple<string, int, int, DateTime>> highscores = DBInterface.RetrieveTopGLOBALFinalScores(StudentNumberDisplayText);

        for (int i = 0; i < highscores.Count; i++)
        {
            if (highscores[i].Item2 > 0)
            {
                GLOBALUserNames[i].text = highscores[i].Item1.ToString();
                GLOBALFinalScores[i].text = highscores[i].Item2.ToString();
                GLOBALFinalTimeTakens[i].text = highscores[i].Item3.ToString();
                GLOBALDateAndTimes[i].text = highscores[i].Item4.ToString();
            }
        }

    }
}

    













