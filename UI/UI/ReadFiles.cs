using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UI
{
    class ReadFiles
    {
        List<string> lines = new List<string>();

        public void readKeyFile(ref apiInfo apiInformation, string path)
        {
            try
            {
            using (FileStream fsSource = new FileStream(path,
            FileMode.Open, FileAccess.Read)){
                    using (StreamReader sr = new StreamReader(fsSource))
                    {
                        string line = string.Empty;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line != string.Empty)
                            {
                                lines.Add(line);
                            }
                        }
                        apiInformation.apiKey = lines[0];
                        apiInformation.apiLoc = lines[1];
                        sr.Close();
                    }
                }
            }
            catch (FileNotFoundException ioEx)
            {
                    ErrorHandling.PrintError(ioEx);
            }
        }
    }
}
