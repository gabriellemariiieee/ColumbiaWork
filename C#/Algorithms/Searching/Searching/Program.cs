namespace Searching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Binary b = new Binary();
            Interpolation i = new Interpolation();
            Linear l = new Linear();

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

            l.Run(scores, 74);
            Console.WriteLine("Linear search sequentially checks each element of a data set.");
            Console.WriteLine("Linearsearch\n   1)set i = 0\n   2)if L[i] = T then go to line 4\n   3)increase i by 1 and go to line 2\n   4)if i < n then return i\nend");
            Console.WriteLine("Worst-case: O(n)\r\nBest-case: O(1)\r\nAverage: O(n/2)");

            b.Run(scores, 28);
            Console.WriteLine("Binary search requires a sorted data set. It compares the value in the middle of the data set to the value being searched for. if the values are equal, it's done, if not, the algorithm determines which half of the data set contains the target. This repeats recursively with the remaining half until the target value is found.");
            Console.WriteLine("Binarysearch(A, n, T)\n   left = 0\n   right = n - 1\n   while(left <= right)\n   m = floor((left + right)/2)\n   if A[m] < T then\n       left = m + 1\n   else if A[m] > T then\n      right = m - 1\n   else\n      return m\n   return unsuccessful");
            Console.WriteLine("Worst-case: O(n/2) + 1\r\nBest-case: O(log n)");

            i.Run(scores, 100);
            Console.WriteLine("Interpolation search requires a sorted data set. It compares the value of the search keys to the value being searched for. if the values are equal, it's done, if not, the algorithm determines which half of the data set contains the target. This repeats recursively with the remaining half until the target value is found.");
            Console.WriteLine("Interpolaitonsearch(A, lo, hi, T)\nwhile lo <= hi and A[lo] <= T <= A[hi]\n   if lo = hi then\n      if A[low] = T then\n         return low\n       else\n         return -1\n      end\n   else\n      pos = lo + [(T-A[lo])(hi-lo)/A[hi]-A[lo]]\n      if pos < lo or pos > hi then\n         return -1\n      end\n      if A[pos] = T then\n         return pos\n      else if A[pos] < T then\n         lo = pos + 1\n      else\n         hi = pos + 1\n      end\n   end\nend\nreturn -1");
            Console.WriteLine("Worst-case: O(n) + 1\r\nBest-case: O(log log n)");
        }
    }
}