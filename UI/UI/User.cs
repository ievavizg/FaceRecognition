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
        public User(string firstName, string lastName, string information)
        {
            FirstName = firstName;
            LastName = lastName;
            Information = information;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Information { get; set; }
    }
}
