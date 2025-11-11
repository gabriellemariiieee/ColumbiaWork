namespace Trees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //gets input from external file
            List<string> files = new List<string>();
            List<string> lines = new List<string>();
            string path = "..\\..\\..\\Files";
            StreamReader reader;
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

            //converts list from string to int and makes it an array
            List<int> points = new List<int>();
            points = lines.Select(int.Parse).ToList();
            int[] scores = new int[points.Count];
            for (int x = 0; x < points.Count; x++)
            {
                scores[x] = points[x];
            }

            //sorts data using bubble sort
            bool notSorted = true;
            while (notSorted)
            {
                notSorted = false;
                for (int i = 1; i < scores.Length; i++)
                {
                    if (scores[i] < scores[i - 1])
                    {
                        int temp = scores[i];
                        scores[i] = scores[i - 1];
                        scores[i - 1] = temp;

                        notSorted = true;
                    }
                    else
                    {
                        continue;
                    }
                    continue;
                }
            }

            //turns ints in list to TreeNodes
            TreeNodeRoot tree = new TreeNodeRoot();
            for (int x = 0; x < scores.Length; x++)
            {
                tree.AddScore(scores[x]);
            }
        }


    }
}