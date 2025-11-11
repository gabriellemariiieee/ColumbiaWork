using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreDatabases
{
    internal class TableReader
    {
        static string path = "..\\..\\..\\Files";
        StreamReader reader;
        public List<string[]> info = new List<string[]>();

        //reads data from file and puts it into a list
        public void Read(string fileName)
        {
            reader = new StreamReader(path + "\\" + fileName);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains("Character"))
                {
                    continue;
                }
                string[] words = line.Split(',');
                info.Add(words);
            }
        }
    }
}
