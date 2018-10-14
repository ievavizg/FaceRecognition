using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    class ReadingFiles
    {
        public void readKeyFile(ref apiInfo apiInformation, string path)
        {
            string [] lines = System.IO.File.ReadAllLines(path);
            apiInformation.apiKey = lines[0];
            apiInformation.apiLoc = lines[1];
        }

    }
}
