using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;

public class DBInterface : MonoBehaviour
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






    public void InsertHighscore(string StudentNumber, int FinalScore)
    {
        using (MySqlConnection connection = new MySqlConnection(stringBuilder.ConnectionString))
        {
            try
            {
                connection.Open();

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO scoring_details (StudentNumber, FinalScore) VALUES (@StudentNumber, @FinalScore)";
                command.Parameters.AddWithValue("@StudentNumber", StudentNumber);
                command.Parameters.AddWithValue("@FinalScore", FinalScore);

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (System.Exception ex)
            {
                Debug.LogError("DBInterface: Could not insert the highscore! " + System.Environment.NewLine + ex.Message);
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