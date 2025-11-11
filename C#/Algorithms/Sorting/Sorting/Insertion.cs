using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class Insertion
    {
        public int[] Run(int[] list)
        {
            int[] result = list;
            for (int i = 0; i < result.Length - 1; i++)
            {
                for (int j = i+ 1; j > 0; j--)
                {
                    if (result[j] < result[j - 1])
                    {
                        int temp = result[j];
                        result[j] = result[j - 1];
                        result[j - 1] = temp;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (int x = 0; x < result.Length; x++)
            {
                Console.Write(result[x] + " ");
            }  
            return result;
        }
    }
}
