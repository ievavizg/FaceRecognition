using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseConnect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = @"Data Source=HARMONY\DATABASE9;
            Initial Catalog=FaceRecognitionDatabase;
            User ID=sa;
            Password=akademines";
            cnn = new SqlConnection(connetionString);


            ReadDataFromDatabase(cnn);

            InsertDataToDatabase(cnn, 4, "Andrius", "Voitovas");

            UpdateDataInDatabase(cnn);

            DeleteRowFromDatabase(cnn);


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
        
        // Insert data to database
        public void InsertDataToDatabase(SqlConnection cnn, int number, string vardas, string pavarde)
        {
            cnn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sqlInsert = "";

            sqlInsert = "Insert into FaceRecognitionTable (ID,Vardas,Pavarde) values('" + number + "','" + vardas + "','" + pavarde + "')";
            command = new SqlCommand(sqlInsert, cnn);
            adapter.InsertCommand = new SqlCommand(sqlInsert, cnn);
            adapter.InsertCommand.ExecuteNonQuery();

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

            sqlUpdate = "Update FaceRecognitionTable set Pavarde = '"+"Rupšys"+"' where Vardas = '"+"Andrius"+"'";
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
    }
}
