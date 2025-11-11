using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuredText
{
    internal class Main
    {
        static string path = "..\\..\\..\\files";
        public List<string> files = new List<string>();
        ParsingEngine engine;
        List<string[]> csvContent = new List<string[]>();
        List<string[]> pipeContent = new List<string[]>();
        Dictionary<string, List<string[]>> output = new Dictionary<string, List<string[]>>();

        public void Run()
        {
            //GetFiles method from https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getfiles?view=net-7.0
            files = Directory.GetFiles(path).ToList();
            engine = new ParsingEngine(files);
            csvContent = engine.csvLines; 
            pipeContent = engine.pipeLines;
            output.Add("SampleCSV", csvContent);
            output.Add("SamplePipe", pipeContent);
            writeFileContent(output);
        }

        //writes files with given content
        void writeFileContent(Dictionary<string, List<string[]>> content)
        {
            foreach (KeyValuePair<string, List<string[]>> pair in content)
            {
                StreamWriter writer = new StreamWriter(path + "\\" + pair.Key + "_out.txt");
                for (int x = 0; x < pair.Value.Count; x++)
                {
                    writer.Write($"Line#{x + 1} :");
                    for (int y = 0; y < pair.Value[x].Length; y++)
                    {
                        if (y != pair.Value[x].Length - 1)
                        {
                            writer.Write($"Field#{y + 1}={pair.Value[x][y]} ==> ");
                        }
                        else
                        {
                            writer.Write($"Field#{y + 1}={pair.Value[x][y]}");
                        }
                    }
                    writer.Write('\n');
                }
                writer.Close();
            }
            
        }
    }
}
