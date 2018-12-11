using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Collections.Specialized;
using System.IO;
using System.Xml.Linq;
using MutualClasses;
using WebServer;

namespace UI.UserControls
{
    public partial class AddControl : UserControl
    {
        
        int errorcode1 = 1;
        int errorcode2 = 1;
        string ImageName = "";
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
                    ImageName = dialog.SafeFileName;
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
        public void AddButton_Click(object sender, EventArgs e)
        {    

            string firstName = NameText.Text;
            string lastName = SurnameText.Text;
            string information = InformationText.Text;
            string photo = "photo_url";
            string id = "12345";
            using (var w = new WebClient())
            {
                string clientID = "d4a165a802843b0";
                w.Headers.Add("Authorization", "Client-ID " + clientID);
                var values = new NameValueCollection
                {
                     { "image", Convert.ToBase64String(File.ReadAllBytes(ImageName)) }
                };

                byte[] response = w.UploadValues("https://api.imgur.com/3/upload.xml", values);
                var xx= XDocument.Load(new MemoryStream(response)).ToString();
                var link = getBetween(xx, "<link>", "</link>");
                photo = link;
                //var xx = XDocument.Load(new MemoryStream(response));

            }

            if (errorcode1 == 0 || errorcode2 == 0 || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(information))
            {
                ErrorHandling.Show_Inserting_Error();
            }
            else
            {

                User user = new User(id, firstName, lastName, information, photo);
                WebServer.WebService service = new WebServer.WebService();
                service.Inserting(user);
                NameText.Text = String.Empty;
                SurnameText.Text = String.Empty;
                InformationText.Text = String.Empty;
                icon1.Image = null;
                icon2.Image = null;
                /*
                var Users = new List<User> { };
                data.GetDataFromDatabase(Users, connection);// Read information to Collection
                UsersInfo userPhoto = new UsersInfo(firstName, lastName, text);
                var UsersPhotos = new List<UsersInfo> { };
                data.GetDataFromDatabase(Users, connection);// Read photo information to Collection 
                var OrderedUsers = Users.OrderBy(p => p.FirstName);// Linq ordering by name ascending
                NameText.Text = String.Empty;
                SurnameText.Text = String.Empty;
                InformationText.Text = String.Empty;
                icon1.Image = null;
                icon2.Image = null;
                //var JoinedUsers = data.GroupJoinCollections(Users, UsersPhotos);
                var JoinedUsers = from p in OrderedUsers
                                  join c in UsersPhotos
                                  on p.FirstName equals c.FirstName
                                  select new
                                  {
                                      PersonName = p.FirstName,
                                      PersonSurname = c.LastName,
                                      PersonInfo = p.Information,
                                      PersonPhoto = c.Text
                                  };*/
            }




        }


        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }

        private void NameText_Leave(object sender, EventArgs e)
        {
            if (RegexClass.Ragex_Check(NameText) == 1 && !string.IsNullOrWhiteSpace(NameText.Text))
            {
                icon1.Image = Properties.Resources.rsz_tick;
                errorcode1 = 1;
                
            }
            else{
                icon1.Image = Properties.Resources.cross;
                errorcode1 = 0;
            }
                  
        }

        private void SurnameText_Leave(object sender, EventArgs e)
        {
            
            if (RegexClass.Ragex_Check(SurnameText) == 1 && !string.IsNullOrWhiteSpace(SurnameText.Text))
            {
                icon2.Image = Properties.Resources.rsz_tick;
                errorcode2 = 1;
                    
            }
            else
            {
                errorcode2 = 0;
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
