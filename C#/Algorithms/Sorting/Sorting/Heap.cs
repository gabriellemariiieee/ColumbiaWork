using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    //help from https://www.geeksforgeeks.org/heap-sort/
    public class Heap
    {
        public int[] Run(int[] list)
        {
            int[] result = list;
            int N = result.Length;
            for (int i = N / 2 - 1; i >= 0; i--)
            {
                makeHeap(result, N, i);
            }
            
            for(int i = N - 1; i > 0; i--)
            {
                int temp = result[0];
                result[0] = result[i];
                result[i] = temp;

                makeHeap(result, i, 0);
            }

            for (int x = 0; x < result.Length; x++)
            {
                Console.Write(result[x] + " ");
            }
            return result;
        }

        private void makeHeap(int[] list, int N, int i)
        {
            int index = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < N && list[left] > list[index])
            {
                index = left;
            }
            if (right < N && list[right] > list[index])
            {
                index = right;
            }
            if (index != i)
            {
                int temp = list[i];
                list[i] = list[index];
                list[index] = temp;

                makeHeap(list, N, index);
            }
        }
    }
}
