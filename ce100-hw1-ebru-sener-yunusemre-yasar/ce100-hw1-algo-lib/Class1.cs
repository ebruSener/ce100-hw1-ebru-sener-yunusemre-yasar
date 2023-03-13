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

        public static void QuickSort2(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = LomutoPartition(arr, left, right);
                QuickSort2(arr, left, pivotIndex - 1);
                QuickSort2(arr, pivotIndex + 1, right);
            }
        }

        private static int LomutoPartition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left;

            for (int j = left; j < right; j++)
            {
                if (arr[j] < pivot)
                {
                    if (i != j)
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                    i++;
                }
            }

            if (i != right)
            {
                arr[right] = arr[i];
                arr[i] = pivot;
            }

            return i;
        }

        public static int BinarySearchIterative(int[] inputArray, int key)
        {
            int l = 0, r = inputArray.Length - 1;
            while (l <= r)
            {
                int m = l + (r - l) / 2;

                // Check if x is present at mid
                if (inputArray[m] == key)
                    return m;

                // If x greater, ignore left half
                if (inputArray[m] < key)
                    l = m + 1;

                // If x is smaller, ignore right half
                else
                    r = m - 1;
            }

            // if we reach here, then element was
            // not present

            // Returns index of x if it is present in
            // arr[l..r], else return -1
            return -1;
        }


        /**
        *
        *	  @name   BinarySearchRecursive (Binary Search Recursive)
        *
        *	  @brief Binary Search Recursive
        *
        *	  Binary Search Recursive
        *
        *	  @param  [in] inputArray [\b int]  inputArray
        *	  
        *	  @param  [in] key [\b int]  key
        *	  
        *	  @param  [in] min [\b int]  min
        *	  
        *	  @param  [in] max [\b int]  max
        *	  
        *	  
        **/

        public static int BinarySearchRecursive(int[] inputArray, int key, int min, int max)
        {
            int mid = key + (min - key) / 2;

            // find the mid-value in the search space and
            // compares it with the target

            // Base condition (target value is found)
            if (max == inputArray[mid])
            {
                return mid;
            }

            // discard all elements in the right search space,
            // including the middle element
            else if (max < inputArray[mid])
            {
                return BinarySearchRecursive(inputArray, key, mid - 1, max);
            }

            // discard all elements in the left search space,
            // including the middle element
            else
            {
                return BinarySearchRecursive(inputArray, mid + 1, min, max);
            }
        }
    }
}
