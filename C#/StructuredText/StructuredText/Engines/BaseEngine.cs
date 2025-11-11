using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuredText.Engines
{
    public abstract class BaseEngine
    {
        StreamReader reader;
        public List<String[]> lines = new List<String[]>();

        //gets file and parses it based on file type
        public virtual void Engine(Files file, string path)
        {
            StreamReader reader = new StreamReader(file.Path);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] words = line.Split(file.Delimiter);
                lines.Add(words);
            }

            if (File.Exists(path + "\\" + file.FileName + "_out.txt"))
            {
                File.Delete(path + "\\" + file.FileName + "_out.txt");
            }

            StreamWriter writer = new StreamWriter(path + "\\" + file.FileName + "_out.txt");
            for (int x = 0; x < lines.Count; x++)
            {
                writer.Write($"Line#{x + 1} :");
                for (int y = 0; y < lines[x].Length; y++)
                {
                    if (y != lines[x].Length - 1)
                    {
                        writer.Write($"Field#{y + 1}={lines[x][y]} ==> ");
                    }
                    else
                    {
                        writer.Write($"Field#{y + 1}={lines[x][y]}");
                    }
                }
                writer.Write('\n');
            }
            writer.Close();
        }
    }
}
