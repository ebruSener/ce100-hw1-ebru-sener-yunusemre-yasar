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

        public static void RecursiveMergeSort(int[] array)
        {
            if (array == null || array.Length <= 1)
            {
                return;
            }
            int[] temp = new int[array.Length];
            RecursiveSort(array, temp, 0, array.Length - 1);
        }

        private static void RecursiveSort(int[] array, int[] temp, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                RecursiveSort(array, temp, left, mid);
                RecursiveSort(array, temp, mid + 1, right);
                Merge(array, temp, left, mid, right);
            }
        }

        private static void Merge(int[] array, int[] temp, int left, int mid, int right)
        {
            int i = left;
            int j = mid + 1;
            int k = left;
            while (i <= mid && j <= right)
            {
                if (array[i] <= array[j])
                {
                    temp[k] = array[i];
                    i++;
                }
                else
                {
                    temp[k] = array[j];
                    j++;
                }
                k++;
            }
            while (i <= mid)
            {
                temp[k] = array[i];
                i++;
                k++;
            }
            while (j <= right)
            {
                temp[k] = array[j];
                j++;
                k++;
            }
            for (int l = left; l <= right; l++)
            {
                array[l] = temp[l];
            }
        }
        public static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pIndex = RandomizedPartition(arr, left, right);
                QuickSort(arr, left, pIndex - 1);
                QuickSort(arr, pIndex + 1, right);
            }
        }

        private static int RandomizedPartition(int[] arr, int left, int right)
        {
            Random rand = new Random();
            int randomIndex = rand.Next(left, right + 1);
            int pivot = arr[randomIndex];
            Swap(arr, randomIndex, right);

            int i = left - 1;
            int j = right;
            while (true)
            {
                do i++; while (arr[i] < pivot);
                do j--; while (j > 0 && arr[j] > pivot);

                if (i >= j)
                {
                    Swap(arr, i, right);
                    return i;
                }
                Swap(arr, i, j);
            }
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }


    }
}
