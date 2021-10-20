﻿using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System;

public class DBInterface : MonoBehaviour
{
    private MySqlConnectionStringBuilder stringBuilder;

    public string Server = "13.73.103.131";
    public string Database= "sys";
    public string UserID = "Remote_ICT302";
    public string Password = "murdochuniversity";
    public ulong GameID;
    public string StudentNumber;
    public string UserName;
    public GameManager GMScript;
    //Place at top (replaces GameID -> GMScript.GameID & StudentNumber-> GMScript.StudentNumber)

    // Start is called before the first frame update
    void Start()
    {
        stringBuilder = new MySqlConnectionStringBuilder();
        stringBuilder.Server = Server;
        stringBuilder.Database = Database;
        stringBuilder.UserID = UserID;
        stringBuilder.Password = Password;
    }
    // everything needed to login into the MySQL database ^



    // User enters student number which starts a new row into the mysql database, assigning a sequential 'GameID' and the entered 'StudentNumber', both of these values get assigned as GLOBAL VARIABLES for other scenes to use, to ensure correct records are being updated
    public void InsertStudentNumber(string StudentNumber, string UserName)
    {
        using (MySqlConnection connection = new MySqlConnection(stringBuilder.ConnectionString))
        {
            try
            {
                connection.Open();

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO scoring_details (StudentNumber, UserName) VALUES (@StudentNumber, @UserName) ;SELECT LAST_INSERT_ID()";
                command.Parameters.AddWithValue("@StudentNumber", StudentNumber);
                command.Parameters.AddWithValue("@UserName", UserName);
                // StudentNumber will be assigned as a global variable



                ulong result = (ulong)command.ExecuteScalar();

                connection.Close();

                ulong GameID = result;
                // GameID will be assigned as a global variable


            }
            catch (System.Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Debug.LogError("DBInterface error in public void InsertStudentNumber " + System.Environment.NewLine + ex.Message);
            }
        }
    }

    // After student number is entered, the GameID, StudentNumber and DateAndTime is displayed with a welcome screen
    public List<System.Tuple<ulong, string, DateTime, string>> DisplayGameDataFromDB()
    {
        List<System.Tuple<ulong, string, DateTime, string>> topFive = new List<System.Tuple<ulong, string, DateTime, string>>();

        using (MySqlConnection connection = new MySqlConnection(stringBuilder.ConnectionString))
        {
            try
            {
                connection.Open();

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT GameID, StudentNumber, DateAndTime, UserName FROM scoring_details ORDER BY GameID DESC LIMIT 1";
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var ordinal = reader.GetOrdinal("GameID");
                    ulong GameID = reader.GetUInt64(ordinal);
                    ordinal = reader.GetOrdinal("StudentNumber");
                    string StudentNumber = reader.GetString(ordinal);
                    ordinal = reader.GetOrdinal("DateAndTime");
                    DateTime DateAndTime = reader.GetDateTime(ordinal);
                    ordinal = reader.GetOrdinal("UserName");
                    string UserName = reader.GetString(ordinal);
                    System.Tuple<ulong, string, DateTime, string> entry = new System.Tuple<ulong, string, DateTime, string>(GameID, StudentNumber, DateAndTime, UserName);
                    topFive.Add(entry);
                }

                connection.Close();
            }
            catch (System.Exception ex)
            {
                Debug.LogError("DBInterface: Could not retrieve values in public list DisplayGameDataFromDB " + System.Environment.NewLine + ex.Message);
            }
        }

        return topFive;
    }




    // FinalScore and FinalTimeTaken to be displayed at the main menu
    public List<System.Tuple<int, int>> DisplayFinalScores(string StudentNumber)
    {
        List<System.Tuple<int, int>> topFive = new List<System.Tuple<int, int>>();

        using (MySqlConnection connection = new MySqlConnection(stringBuilder.ConnectionString))
        {
            try
            {
                connection.Open();

                MySqlCommand command = connection.CreateCommand();
                //Debug.Log("before SELECT SQL StudentNumber is equal to " + StudentNumber);
                command.CommandText = "SELECT MAX(FinalScore) AS FinalScore, FinalTimeTaken FROM scoring_details WHERE StudentNumber = @StudentNumber";
                //Debug.Log("before addwithvalue StudentNumber is equal to " + StudentNumber);
                command.Parameters.AddWithValue("@StudentNumber", StudentNumber);
                //Debug.Log("after addwithvalue StudentNumber is equal to " + StudentNumber);
                var reader = command.ExecuteReader();

                //Debug.Log("AHHHHHHHHHHHHHHHHHHHHHHH");

                while (reader.Read())
                {
                    var ordinal = reader.GetOrdinal("FinalScore");
                    int FinalScore = reader.IsDBNull(ordinal) ? 0 : reader.GetInt32(ordinal);
                    ordinal = reader.GetOrdinal("FinalTimeTaken");
                    int FinalTimeTaken = reader.IsDBNull(ordinal) ? 0 : reader.GetInt32(ordinal);
                    System.Tuple<int, int> entry = new System.Tuple<int, int>(FinalScore, FinalTimeTaken);
                    //Debug.Log("FinalScore is equal to " + FinalScore);
                    //Debug.Log("FinalTimeTaken is equal to " + FinalTimeTaken);
                    topFive.Add(entry);
                }

                connection.Close();
            }
            catch (System.Exception ex)
            {
                Debug.LogError("DBInterface: Could not retrieve values in public list DisplayFinalScores " + System.Environment.NewLine + ex.Message);
            }
        }

        return topFive;
    }










    // ScoreLvlOne value is passed into this from another script/person in da group, HOPEFULLY which updates the existing rows 'ScoreLvlOne' which has the correct game ID and student number
    //UPDATE: Call this function in GameManagers addToServer()
    //UPDATE: add "private DBInterface DBScript;" to GameManager
    //UPDATE: add "DBScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DBInterface>(); to GameManager start()
    public void ReceiveScoreLvlOne()
    {
        using (MySqlConnection connection = new MySqlConnection(stringBuilder.ConnectionString))
        {
            try
            {
                connection.Open();

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE scoring_details SET ScorelvlOne = @ScoreLvlOne WHERE GameID = @GameID AND StudentNumber = @StudentNumber";
                command.Parameters.AddWithValue("@GameID", GameID);
                command.Parameters.AddWithValue("@StudentNumber", StudentNumber);

                //Set final score values (lvl 4 vals for now)
                command.Parameters.AddWithValue("@FinalScore", GMScript.GetLevel(3).Score);
                command.Parameters.AddWithValue("@FinalTimeTaken", GMScript.getFullCompletionTime());

                //Loop through all levels
                for (int i = 0; i < GMScript.getTotalLevels(); ++i)
                {
                    //Based on level assign values to database accordingly (level list is ZERO based)
                    switch (i)
                    {
                        case 0:
                            command.Parameters.AddWithValue("@ScoreLvlOne", GMScript.GetLevel(i).Score);
                            command.Parameters.AddWithValue("@TimeTakenLvlOne", GMScript.GetLevel(i).Score);
                            break;
                        case 1:
                            command.Parameters.AddWithValue("@ScoreLvlTwo", GMScript.GetLevel(i).Score);
                            command.Parameters.AddWithValue("@TimeTakenLvlTwo", GMScript.GetLevel(i).Score);
                            break;
                        case 2:
                            command.Parameters.AddWithValue("@ScoreLvlThree", GMScript.GetLevel(i).Score);
                            command.Parameters.AddWithValue("@TimeTakenLvlThree", GMScript.GetLevel(i).Score);
                            break;
                        case 3:
                            command.Parameters.AddWithValue("@ScoreLvlFour", GMScript.GetLevel(i).Score);
                            command.Parameters.AddWithValue("@TimeTakenLvlFour", GMScript.GetLevel(i).Score);
                            break;
                    }
                }

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (System.Exception ex)
            {
                Debug.LogError("DBInterface error in public void ReceiveScoreLvlOne " + System.Environment.NewLine + ex.Message);
            }
        }
    }





















        // not being used
        /*
        public List<System.Tuple<string, int>> RetrieveTopFiveFinalScores()
        {
            List<System.Tuple<string, int>> topFive = new List<System.Tuple<string, int>>();

            using (MySqlConnection connection = new MySqlConnection(stringBuilder.ConnectionString))
            {
                try
                {
                    connection.Open();

                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT StudentNumber, FinalScore FROM scoring_details ORDER BY FinalScore DESC LIMIT 5";
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var ordinal = reader.GetOrdinal("StudentNumber");
                        string StudentNumber = reader.GetString(ordinal);
                        ordinal = reader.GetOrdinal("FinalScore");
                        int FinalScore = reader.GetInt32(ordinal);
                        System.Tuple<string, int> entry = new System.Tuple<string, int>(StudentNumber, FinalScore);
                        topFive.Add(entry);
                    }

                    connection.Close();
                }
                catch (System.Exception ex)
                {
                    Debug.LogError("DBInterface: Could not retrieve the top five highscores! " + System.Environment.NewLine + ex.Message);
                }
            }

            return topFive;
        }
        */










    
}







