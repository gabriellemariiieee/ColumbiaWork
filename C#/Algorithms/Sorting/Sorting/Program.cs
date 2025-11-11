using System.Timers;

namespace Sorting
{
    internal class Program
    {
        private static System.Diagnostics.Stopwatch watch;
        static void Main(string[] args)
        {
            Bubble b = new Bubble();
            Heap h = new Heap();
            Insertion i = new Insertion();
            Merge m = new Merge();
            Quick q = new Quick();
            Selection s = new Selection();

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
            for(int x = 0;x < points.Count; x++)
            {
                scores[x] = points[x];
            }

            watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            b.Run(scores);
            watch.Stop();
            Console.WriteLine($"Bubble sort is an algorithm that compares the current value to the previous one and repeats until all values are sorted. It sorted the data in {watch.ElapsedMilliseconds} ms. Psuedocode for the alogrithm follows:");
            Console.WriteLine("Bubblesort(Data: values[])\n  Boolean: not_sorted = True\n  While(not_sorted)\n    not_sorted = False\n    For i = 0 To <length of values> - 1\n      If(values[i] < values[i-1]) Then\n        Data: temp = values[i]\n        values[i] = values[i-1]\n        values[i-1] = temp\n        not_sorted = True\n      End If\n    Next i\n  End While\nEnd Bubblesort");

            watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            i.Run(scores);
            watch.Stop();
            Console.WriteLine($"Insertion sort is an algorithm that takes the item in the array and searches through the part of the list that's been sorted to find the current item's new position. It sorted the data in {watch.ElapsedMilliseconds} ms. Psuedocode for the alogrithm follows:");
            Console.WriteLine("Insertionsort(Data: values[])\n  For i = 0 To <length of values> - 1\n      while j > 0 and A[j-1]>A[j]\n        swap values[j] and values[j-1]\n      end while\n      next i\nEnd Insertionsort");


            watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            s.Run(scores);
            watch.Stop();
            Console.WriteLine($"Selection sort is an algorithm that takes the largest item in the array and adds it to the end of the list. It sorted the data in {watch.ElapsedMilliseconds} ms. Psuedocode for the alogrithm follows:");
            Console.WriteLine("Selectionsort(Data: values[])\n  For i = 0 To <length of values> - 1\n      <Find the smallest item with index j >= i>\n        <swap values[i] and values[j]>\n      next i\nEnd Selectionsort");

            watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            h.Run(scores);
            watch.Stop();
            Console.WriteLine($"Heap sort is an algorithm that builds a heap and then repeatedly swaps the first and last items in the heap and rebuilds it excluding the last item. It sorted the data in {watch.ElapsedMilliseconds} ms. Psuedocode for the alogrithm follows:");
            Console.WriteLine("Heapsort(Data: values[])\n  <Turn the array into a heap.>\n  For i <length of values> - 1 To Step - 1\n      Data: temp = values[0]\n      values[0] = values[i]\n      values[i] = temp\n      <the item in position i to be removed from the heap. push the new root value down into the heap to restore the heap property>\n   next i\nEnd Heapsort");

            watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            q.Run(scores);
            watch.Stop();
            Console.WriteLine($"Quick sort is an algorithm that divides the input array into two smaller sub-arrays based on i,the values smaller then i and the values larger than i, and then recursively sorts the sub-arrays. It sorted the data in {watch.ElapsedMilliseconds} ms. Psuedocode for the alogrithm follows:");
            Console.WriteLine("Quicksort(A, lo, hi)\n  if lo < hi then\n    p = pivot(A, lo, hi)\n      left, right = partition(A, p, lo, hi)\n      quicksort(A, lo, left - 1)\n      quicksort(A, right + 1, hi)\nEnd Quicksort");

            watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            h.Run(scores);
            watch.Stop();
            Console.WriteLine($"Merge sort is an algorithm that splits the items into two halves holding an equal number of items and recursively recalls itself to sort the two halves. It sorted the data in {watch.ElapsedMilliseconds} ms. Psuedocode for the alogrithm follows:");
            Console.WriteLine("Mergesort(Data: values[], Data: scratch[], int start, int end)\nif(start == end) then return\n   int midpoint = (start+end)/2\n   Mergesort(values, scratch, start, midpoint)\n   Mergesort(values, scratch, midpoint+1, end)\n   int left_index = start\n   int right_index = midpoint + 1\n   int scratch_index = left_index\n   while((left_index <= midpoint) and (right_index <= end))\n      if(values[left_index] <= values[right_index]) then\n         scratch[scratch_index] = values[left_index]\n          left_index = left_index + 1\n      else\n         scratch[scratch_index] = values[right_index]\n          right_index = right_index + 1\n      end if\n   scratch_index = scratch_index + 1\n   end while\n   for i = left_index to midpoint\n      scratch[scratch_index] = values[i]\n      scratch_index = scratch_index + 1\n   next i\n   for i = right_index to end\n      scratch[scratch_index] = values[i]\n      scratch_index = scratch_index + 1\n   next i\n   for i = start to end\n      values[i] = scratch[i]\n   next i\nEnd Mergesort");

        }

    }
}