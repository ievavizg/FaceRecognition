using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
public struct apiInfo
{
    public String apiKey, apiLoc;

    public apiInfo(String s1, String s2)
    {
        apiKey = s1;
        apiLoc = s2;
    }
}
namespace UI
{
    class FaceRecognition
    {
        apiInfo apiInformation = new apiInfo();
        ReadFiles nReader = new ReadFiles();
        public void getInformation()
        {
             String file = @"..\Debug\key.txt";
            String path = Path.GetFullPath(file);
            nReader.readKeyFile(ref apiInformation, path);
        }
    }
}
