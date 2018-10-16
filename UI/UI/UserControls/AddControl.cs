using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace UI.UserControls
{
    public partial class AddControl : UserControl
    {
        int errorcode;
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

            if (errorcode == 0 || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(information))
            {
                ErrorHandling.Show_Inserting_Error();
            }
            else
            {
                DatabaseInfo data = new DatabaseInfo();
                var connection = data.GetConfigInfo();
                User user = new User(firstName, lastName, information);
                data.InsertRow(user, connection);
                NameText.Text = String.Empty;
                SurnameText.Text = String.Empty;
                InformationText.Text = String.Empty;
            }


        }

        private void NameText_Leave(object sender, EventArgs e)
        {
            if (RegexClass.Ragex_Check(NameText) == 1)
            {
                icon1.Image = Properties.Resources.rsz_tick;
                if (errorcode != 0)
                    errorcode = 1;
                
            }
            else{
                icon1.Image = Properties.Resources.cross;
                errorcode = 0;
            }
                  
        }

        private void SurnameText_Leave(object sender, EventArgs e)
        {
            if (RegexClass.Ragex_Check(SurnameText) == 1)
            {
                icon2.Image = Properties.Resources.rsz_tick;
                if (errorcode != 0)
                    errorcode = 1;
                    
            }
            else
            {
                errorcode = 0;
                icon2.Image = Properties.Resources.cross;
            }
        }

        private void AddControl_VisibleChanged(object sender, EventArgs e)
        {
            if(!this.Visible)
            {
                icon1.Image = null;
                icon2.Image = null;
            }
        }
    }
}
