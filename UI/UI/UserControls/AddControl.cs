using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace UI.UserControls
{
    public partial class AddControl : UserControl
    {
        public AddControl()
        {
            InitializeComponent();
        }

        private void UploadPhotoButton_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All files(*.*)|*.*";
                if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    ImageView.ImageLocation = imageLocation;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //Add button action
        private void AddButton_Click(object sender, EventArgs e)
        {
            //string firstName = textBox1.Text;
            //string lastName = textBox2.Text;
            //string information = textBox3.Text;
            int count = 1;

            //Getting information from app.config
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


            // inserting
            var commandString = "INSERT INTO dbo.PeopleFaceTable (First_Name, Last_Name ,Education, Photo) VALUES (@First_Name, @Last_Name, @Education, @Photo)"; //1,'Einius','Staupas','Pasilai','Vilnius university'
            using (SqlCommand command = new SqlCommand(commandString, connection))
            {
                command.Parameters.AddWithValue("@First_Name", "Ieva");
                command.Parameters.AddWithValue("@Last_Name", "Vizgirdaite");
                command.Parameters.AddWithValue("@Education", "Vilnius university");
                command.Parameters.AddWithValue("@Photo", "87d87e9wq7d7w9f7889");


                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();

                // Check Error
                if (result < 0)
                    MessageBox.Show("negeraii");
            }

        }


        // Create table to database
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











        // Insert data to database
        public void InsertDataToDatabase(SqlConnection cnn, string vardas, string pavarde, string information)
        {
            cnn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sqlInsert = "";

            sqlInsert = "Insert into personInfoTable (Vardas,Pavarde,Informacija) values('" + vardas + "','" + pavarde + "','" + information + "')";
            command = new SqlCommand(sqlInsert, cnn);
            adapter.InsertCommand = new SqlCommand(sqlInsert, cnn);
            adapter.InsertCommand.ExecuteNonQuery();

            command.Dispose();

            cnn.Close();
        }

        // Read data from database
        public void ReadDataFromDatabase(SqlConnection cnn)
        {
            cnn.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sqlRead, Output = "";

            sqlRead = "SELECT Vardas, Pavarde FROM FaceRecognitionTable";
            command = new SqlCommand(sqlRead, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + " " + dataReader.GetValue(1) + "\n";
            }
            MessageBox.Show(Output);
            dataReader.Close();
            command.Dispose();

            cnn.Close();
        }

        // Update data in database
        public void UpdateDataInDatabase(SqlConnection cnn)
        {
            cnn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sqlUpdate = "";

            sqlUpdate = "Update FaceRecognitionTable set Pavarde = '" + "Rupšys" + "' where Vardas = '" + "Andrius" + "'";
            command = new SqlCommand(sqlUpdate, cnn);
            adapter.UpdateCommand = new SqlCommand(sqlUpdate, cnn);
            adapter.UpdateCommand.ExecuteNonQuery();

            command.Dispose();

            cnn.Close();
        }

        // Delete row from database
        public void DeleteRowFromDatabase(SqlConnection cnn)
        {
            cnn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sqlDelete = "";

            sqlDelete = "Delete FaceRecognitionTable where ID = 4";

            command = new SqlCommand(sqlDelete, cnn);
            adapter.DeleteCommand = new SqlCommand(sqlDelete, cnn);
            adapter.DeleteCommand.ExecuteNonQuery();

            command.Dispose();

            cnn.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        


        /*string provider = ConfigurationManager.AppSettings["provider"];
        string connectionString = ConfigurationManager.AppSettings["connectionString"];
        DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
            using (DbConnection connection = factory.CreateConnection())
            {
                if(connection == null)
                {
                    MessageBox.Show("conn error");
                    return;
                }
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = factory.CreateCommand();
                if (command == null)
                {
                    MessageBox.Show("comm error");
                    return;
                }
                command.Connection = connection;
                command.CommandText = "Select * from People";

                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        MessageBox.Show($"{dataReader["Id"]}" + $"{dataReader["Vardas"]}");
                    }
                }
                connection.Close();
            }*/


    }
}
