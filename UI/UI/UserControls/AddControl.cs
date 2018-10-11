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

        private void button1_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All files(*.*)|*.*";
                if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    image1.ImageLocation = imageLocation;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string firstName = textBox1.Text;
            string lastName = textBox2.Text;
            string information = textBox3.Text;
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
                    MessageBox.Show("negerai");
            }


        }



        // Create table to database
        public void CreateTable (SqlConnection connection)
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



    }
}
