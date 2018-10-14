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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UploadPhotoButton_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    ImageView.ImageLocation = imageLocation;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //Add button action
        private void AddButton_Click(object sender, EventArgs e)
        {
            string firstName = NameText.Text;
            string lastName = SurnameText.Text;
            string information = InformationText.Text;

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


            InsertRow(firstName, lastName, information, connection);


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
        public void InsertRow(string firstName, string lastName, string information, SqlConnection connection)
        {
            var commandString = "INSERT INTO dbo.PeopleFaceTable (First_Name, Last_Name ,Education, Photo) VALUES (@First_Name, @Last_Name, @Education, @Photo)";
            SqlCommand command = new SqlCommand(commandString, connection);

            command.Parameters.AddWithValue("@First_Name", firstName);
            command.Parameters.AddWithValue("@Last_Name", lastName);
            command.Parameters.AddWithValue("@Education", information);
            command.Parameters.AddWithValue("@Photo", "87d87e9wq777777d7w9f7889");

            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();

            // Check Error
            if (result < 0)
                MessageBox.Show("negerai");

        }


    }
}
