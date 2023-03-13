using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce100_hw1_algo_lib
{
    public class Class1
    {
        public static int[] SelectionSort(int[] A, int n)
        {
            int tmp;
            int min;

            for (int i = 0; i < n - 1; i++)
            {
                min = i;

                for (int j = i; j < n; j++)
                {
                    if (A[j] < A[min])
                    {
                        min = j;
                    }
                }

                tmp = A[i];
                A[i] = A[min];
                A[min] = tmp;
            }

            return A;
        }



    }
}
