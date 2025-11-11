using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//help from https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/file-io-operation
namespace Week2FileIO
{
    internal class Main
    {
        static string path = @"..\\..\\..\\files";
        string[] dirs;
        List<Files> files = new List<Files>();
        List<string> lines = new List<string>();
        static Char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        int[] count = new int[alphabet.Length];
        Dictionary<Char, int> data = new Dictionary<Char, int>();

        public void Run()
        {
            getFilesToRead(path);
            createFiles(dirs);
            readFile(files);
            getCharacterCount(files);
        }

        private void addListItem(string value)
        {
            lines.Add(value);
        }

        //reads the story from the files and adds them to the content of the File
        void readFile(List<Files> f)
        {
            foreach(Files file in f)
            {
                StreamReader reader = new StreamReader(path + "\\" + file.Name);
                do
                {
                    addListItem(reader.ReadLine());
                }
                while(reader.Peek() != -1);   
                file.Content = lines.ToArray();
                lines.Clear();
            }
        }

        //gets files needed to read from specified path
        void getFilesToRead(string p)
        {
            dirs = Directory.GetFiles(p);
        }

        //turns files read from folder into Files
        void createFiles(string[] d)
        {
            foreach (string dir in dirs)
            {
                Files temp = new Files();
                //Path.GetFileName() from https://stackoverflow.com/questions/12524398/directory-getfiles-how-to-get-only-filename-not-full-path
                temp.Name = Path.GetFileName(dir);
                files.Add(temp);
            }
        }

        //gets number of charcters per file
        public void getCharacterCount(List<Files> f)
        {
            foreach(Files file in f)
            {
                Console.WriteLine("File: " + file.Name);
                foreach (string line in file.Content)
                {
                    foreach(char c in line)
                    {
                        for (int i = 0; i < alphabet.Length; i++)
                        {
                            if (alphabet[i] == c)
                            {
                                count[i] = count[i] + 1;
                            }
                        }
                    }
                }
                for (int i = 0; i < alphabet.Length; i++)
                {
                    data.Add(alphabet[i], count[i]);
                }

                foreach (KeyValuePair<Char, int> pair in data)
                {
                    Console.WriteLine(pair.Key + pair.Value.ToString());
                }
                
                for (int i = 0; i < count.Length; i++)
                {
                    count[i] = 0;
                }
                data.Clear();
                Console.WriteLine("\n");
            }
        }
    }
}
