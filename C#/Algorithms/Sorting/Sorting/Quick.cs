using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Sorting
{
    public class Quick
    {
        public int[] Run(int[] list) 
        {
            int[] result = list;
            quickSort(result, 0, result.Length - 1);
            for (int x = 0; x < result.Length; x++)
            {
                Console.Write(result[x] + " ");
            }
            return result;
        }

        private void quickSort(int[] list, int low, int high)
        {
            if (low < high)
            {
                int dividend = Dividor(list, low, high);

                quickSort(list, low, dividend - 1);
                quickSort(list, dividend + 1, high);
            }
        }

        private int Dividor(int[] list, int low, int high)
        {
            int dividend = list[high];
            int i = low - 1;
            for(int j = low; j <= high; j++)
            {
                if (list[j] < dividend)
                {
                    i++;
                    int temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }

            int t = list[i + 1];
            list[i + 1] = list[high];
            list[high] = t;
            return i+1;
        }
    }
}
