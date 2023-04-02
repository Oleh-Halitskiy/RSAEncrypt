using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSAEncrypt
{
    internal class FileManager
    {
        private static void SaveFile(string content, string path)
        {
            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(content);
            }
        }
        private static string ReadFile(string path)
        {
            using(StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
