using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace UI
{
    class DatabaseInfo
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
            catch (Exception ex)
            {
                MessageBox.Show("negerai");
            }
        }


        // Insert row to table   InsertRow(firstName, lastName, information, connection);
        public void InsertRow(User user, SqlConnection connection)
        {
            var commandString = "INSERT INTO dbo.PeopleFaceTable (First_Name, Last_Name ,Education, Photo) VALUES (@First_Name, @Last_Name, @Education, @Photo)";
            SqlCommand command = new SqlCommand(commandString, connection);

            command.Parameters.AddWithValue("@First_Name", user.FirstName);
            command.Parameters.AddWithValue("@Last_Name", user.LastName);
            command.Parameters.AddWithValue("@Education", user.Information);
            command.Parameters.AddWithValue("@Photo", "87d87e9wq7888d7w9f7889");

            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();

            // Check Error
            if (result < 0)
                MessageBox.Show("negerai");

        }
    }
}
