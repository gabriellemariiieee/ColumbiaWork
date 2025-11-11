namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("..\\..\\..\\Files\\info.txt");
            List<string[]> lines = new List<string[]>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                lines.Add(words);
            }

            //create map
            Console.WriteLine("Map implementation");
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            for (int x = 0; x < lines.Count; x++)
            {
                dictionary.Add(lines[x][0], lines[x][1]);
            }
            foreach (KeyValuePair<string, string> pair in dictionary)
            {
                Console.WriteLine(pair);
            }

            //creates array
            Console.WriteLine("\nArray implementation");
            string[] array = new string[lines.Count*2];
            int y = 0;
            for(int x = 0; x < lines.Count * 2; x+=2)
            {
                array[x] = lines[y][0];
                array[x+1] = lines[y][1];
                y++;
            }
            foreach (string word in array)
            {
                Console.WriteLine(word);
            }

            //create stack
            Console.WriteLine("\nStack implementation");
            LinkedList<string> stack = new LinkedList<string>();
            for (int x = 0; x < lines.Count; x++)
            {
                stack.AddFirst(lines[x][0]);
                stack.AddFirst(lines[x][1]);
            }

            foreach(string word in stack)
            {
                Console.WriteLine(word);
            }

            //create queue
            Console.WriteLine("\nQueue implementation");
            LinkedList<string> queue = new LinkedList<string>();
            for(int x = 0; x < lines.Count; x++)
            {
                queue.AddLast(lines[x][0]);
                queue.AddLast(lines[x][1]);
            }
            foreach (string word in queue)
            {
                Console.WriteLine(word);
            }
        }
    }
}