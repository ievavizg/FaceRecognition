using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UI
{
    public class User
    {
        public User(string firstName, string lastName, string information, string text)
        {
            FirstName = firstName;
            LastName = lastName;
            Information = information;
            Text = text;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Information { get; set; }
        public string Text { get; set; }
    }
}
