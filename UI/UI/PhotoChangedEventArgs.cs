using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class PhotoChangedEventArgs : EventArgs
    {
        public string ImageFileName;
        public PhotoChangedEventArgs(string imagefilename)
        {
            ImageFileName = imagefilename;
        }
    }
}
