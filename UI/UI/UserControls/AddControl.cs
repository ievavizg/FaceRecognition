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
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    ImageView.ImageLocation = imageLocation;
                }
            }
            catch (Exception)
            {
                ErrorHandling.Show_Uploading_Error();
            }
        }

        //Add button action
        private void AddButton_Click(object sender, EventArgs e)
        {

            string firstName = NameText.Text;
            string lastName = SurnameText.Text;
            string information = InformationText.Text;

            DatabaseInfo data = new DatabaseInfo();
            var connection = data.GetConfigInfo();
            User user = new User(firstName, lastName, information);
            data.InsertRow(user, connection);

        }

    }
}
