using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace MutualClasses
{
    public class DatabaseInfo
    {
        //Getting information from app.config
        public SqlConnection GetConfigInfo()
        {
            var connection = new SqlConnection();
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    var name = cs.Name;
                    var provider = cs.ProviderName;
                    connection = new SqlConnection(cs.ConnectionString);
                }
            }
            return connection;
        }

        // Get data with photo from database    GetDataFromDatabase(connection);
        public void GetDataWithPhotoFromDatabase(List<UsersInfo> Users, SqlConnection connection)
        {
            //var user = new User
            var commandString = "Select * From dbo.PeopleFaceTable";
            using (SqlCommand command = new SqlCommand(commandString, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new UsersInfo(
                            reader["First_Name"].ToString(),
                            reader["Last_Name"].ToString(),
                            reader["Photo"].ToString());

                        Users.Add(user);
                    }
                }
                connection.Close();
            }
        }


        // Create table to database   CreateTable(connection);
        public void CreateTable(SqlConnection connection)
        {
            try
            {
                connection.Open();
                var commandString = "If not exists (select name from sysobjects where name = 'PeopleFaceTable') CREATE TABLE PeopleFaceTable(First_Name char(50),Last_Name char(50),Education char(50), Photo text)";
                using (SqlCommand command = new SqlCommand(commandString, connection))
                    command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                ErrorHandling.Show_Connection_Error();
            }
        }

        // Insert row to table   InsertRow(user, connection);
        public void InsertRow(User user, SqlConnection connection)
        {
            var commandString = "INSERT INTO dbo.PeopleFaceRecognitionTable (ID, First_Name, Last_Name ,Education, Photo) VALUES (@ID, @First_Name, @Last_Name, @Education, @Photo)";
            SqlCommand command = new SqlCommand(commandString, connection);

            command.Parameters.AddWithValue("@ID", user.ID);
            command.Parameters.AddWithValue("@First_Name", user.FirstName);
            command.Parameters.AddWithValue("@Last_Name", user.LastName);
            command.Parameters.AddWithValue("@Education", user.Information);
            command.Parameters.AddWithValue("@Photo", user.Photo);

            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();

            // Check Error
            if (result < 0)
                ErrorHandling.Show_Inserting_Error();

        }


        // Get data from database    GetDataFromDatabase(connection);
        public void GetDataFromDatabase(List<User> Users, SqlConnection connection)
        {
            //var user = new User
            var commandString = "Select * From dbo.PeopleFaceRecognitionTable";
            using (SqlCommand command = new SqlCommand(commandString, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new User(
                            reader["ID"].ToString(),
                            reader["First_Name"].ToString(),
                            reader["Last_Name"].ToString(),
                            reader["Education"].ToString(),
                            reader["Photo"].ToString());

                        Users.Add(user);
                    }
                }
                connection.Close();
            }
        }
        }
}
