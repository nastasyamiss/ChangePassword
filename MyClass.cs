using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    class MyClass
    {
        const string alf = "qwertyuiopasdfghjklzxcvbnm0123456789";
        const string fileway = "password.txt";
        
        private string res;
        private int k, x, z;

        private string CreateKey()
        {
            string key = "";
            var rnd = new Random();
            var s = new StringBuilder();
            for (int i = 0; i < 3; i++)
                s.Append((char)rnd.Next('a', 'z'));
            key = s.ToString();
            return key;
        }
        private string Encryption(string pass, string key)
        {

            res = string.Empty;
            while (key.Length < pass.Length)
            {
                key += key;
                if (key.Length > pass.Length) key = key.Remove(pass.Length);
            }
            for (int i = 0; i < pass.Length; i++)
            {
                for (int id = 0; id < alf.Length; id++)
                {
                    if (key[i] == alf[id]) k = id;
                    if (pass[i] == alf[id]) x = id;
                    z = (x + k) % alf.Length;
                }
                res += alf[z];
            }
            return res;
        }
        public bool ComparePass(string pass, string key)
        {
            if (Encryption(pass, key) == FileMyOpen()) return true;
            else return false;
        }

        public string FileMyOpen()
        {
            string line, str = "";
            var stream = File.OpenText(fileway);
            while ((line = stream.ReadLine()) != null)
            {
                str = line;
                var columns = line.Split(' ');
            }
            stream.Close();
            return str;
        }

        public string SaveInFile(string endpass)
        {
            string result, Key;
            Key = CreateKey();
            result = Encryption(endpass, Key);
            StreamWriter file1 = new StreamWriter(fileway);
            file1.WriteLine(result);
            file1.Close();
            return Key;
        }
    }
}
