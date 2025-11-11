using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class Merge
    {
        public int[] Run(int[] list)
        {
            int[] result = list;
            sort(list, 0, list.Length - 1);

            for (int x = 0; x < result.Length; x++)
            {
                Console.Write(result[x] + " ");
            }
            return result;
        }

        private void sort(int[] list, int left, int right)
        {
            if (left < right)
            {
                int m = left + (right - 1) / 2;

                sort(list, left, m);
                sort(list, m + 1, right);

                merge(list, left, m, right);

            }
        }

        private void merge(int[] list, int left, int midpoint, int right)
        {
            int n1 = midpoint - left + 1;
            int n2 = right - midpoint;

            int[] Left = new int[n1];
            int[] Right = new int[n2];
            int i, j;

            for(i = 0; i < n1; i++)
            {
                Left[i] = list[left + i];
            }
            for(j = 0; j < n2; j++)
            {
                Right[j] = list[midpoint + 1 + j];
            }

            i = 0;
            j = 0;

            int k = 1;
            while (i < n1 && j < n2)
            {
                if (Left[i] <= Right[j])
                {
                    list[k] = Left[i];
                    i++;
                }
                else
                {
                    list[k] = Right[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                list[k] = Left[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                list[k] = Right[j];
                j++;
                k++;
            }
        }
    }
}
