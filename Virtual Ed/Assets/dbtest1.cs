using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System;

public class dbtest1 : MonoBehaviour
{
    private MySqlConnectionStringBuilder stringBuilder;

    public string Server;
    public string Database;
    public string UserID;
    public string Password;

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


 
    static void Main(string[] args)
    {
        StudentNumberInsertionTest obj = new StudentNumberInsertionTest();
        obj.InsertStudentNumber("33745155");
    }












    //ScoreLvlOne value is passed into this from another script/person in da group, HOPEFULLY which updates the existing rows 'ScoreLvlOne' which has the correct game ID and student number
    public void ReceiveScoreLvlOne(string ScoreLvlOne, string GameId, string StudentNumber)
    {
        using (MySqlConnection connection = new MySqlConnection(stringBuilder.ConnectionString))
        {
            try
            {
                connection.Open();

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE scoring_details SET ScorelvlOne = '@ScoreLvlOne' WHERE GameId = '@GameId' AND StudentNumber = '@StudentNumber'";
                command.Parameters.AddWithValue("@ScoreLvlOne", ScoreLvlOne);
                command.Parameters.AddWithValue("@GameId", GameId);
                command.Parameters.AddWithValue("@StudentNumber", StudentNumber);
                
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (System.Exception ex)
            {
                Debug.LogError("dbtest1 error in public void ReceiveScoreLvlOne " + System.Environment.NewLine + ex.Message);
            }
        }
    }














    public List<System.Tuple<string, int>> RetrieveTopFiveHighscores()
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
}









public class StudentNumberInsertionTest
{
    private MySqlConnectionStringBuilder stringBuilder;

    public string Server = "127.0.0.1";
    public string Database = "ict302gametest1";
    public string UserID = "root";
    public string Password = "Apache77!";

    public StudentNumberInsertionTest()
    {
        stringBuilder = new MySqlConnectionStringBuilder();
        stringBuilder.Server = Server;
        stringBuilder.Database = Database;
        stringBuilder.UserID = UserID;
        stringBuilder.Password = Password;
    }


    //User enters student number which starts the row into the mysql database, assigning a sequential 'GameID' and the entered 'StudentNumber' values
    public void InsertStudentNumber(string StudentNumber)
    {
        using (MySqlConnection connection = new MySqlConnection(stringBuilder.ConnectionString))
        {
            try
            {
                connection.Open();

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO scoring_details (StudentNumber) VALUES (@StudentNumber) ;SELECT CAST(LAST_INSERT_ID() as int)";
                command.Parameters.AddWithValue("@StudentNumber", StudentNumber);

                int result = (int)command.ExecuteScalar();

                connection.Close();

                Console.WriteLine(result);


            }
            catch (System.Exception ex)
            {
                Debug.LogError("dbtest1 error in public void InsertStudentNumber " + System.Environment.NewLine + ex.Message);
            }
        }
    }





}











