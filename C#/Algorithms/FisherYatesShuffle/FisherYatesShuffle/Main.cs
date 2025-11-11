using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherYatesShuffle
{
    internal class Main
    {
        List<string> files = new List<string>();
        List<string> lines = new List<string>();
        string path = "..\\..\\..\\Files";
        StreamReader reader;
        Random rand = new Random();

        public Main()
        {
            files = Directory.GetFiles(path).ToList();
            for (int x = 0; x < files.Count; x++)
            {
                reader = new StreamReader(files[x]);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            Shuffle(lines);
            lines.ForEach(a => Console.WriteLine(a));

        }

        //randomly rearranges the lines from the file
        //help from https://www.dotnetperls.com/fisher-yates-shuffle
        void Shuffle(List<string> strings)
        {
            int n = strings.Count();
            for (int i = 0; i < n; i++)
            {
                int random = i + rand.Next(n - i);
                string s = strings[random];
                strings[random] = strings[i];
                strings[i] = s;
            }
        }
    }
}
