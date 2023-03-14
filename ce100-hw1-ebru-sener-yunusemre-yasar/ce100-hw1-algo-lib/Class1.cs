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
            // This method takes an integer array A and its length n as inputs.


            int tmp;
            int min;

            for (int i = 0; i < n - 1; i++)

            // This outer loop iterates over each element of the array A.
            {
                min = i;

                // Set the minimum value to the current index i.

                for (int j = i; j < n; j++)
                {
                    // This inner loop iterates over the remaining elements of the array A.


                    if (A[j] < A[min])
                    {
                        // If the value at index j is less than the minimum value so far,
                        // update the index of the minimum value to j.

                        min = j;
                    }
                }

                tmp = A[i];
                A[i] = A[min];
                A[min] = tmp;
            }
            // Swap the current element (at index i) with the minimum element
            // (at index min), effectively moving the minimum value to the front
            // of the remaining unsorted elements.



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

        public static int RecursiveBinarySearch(int[] array, int target, int low, int high)
        {
            if (low > high)
            {
                // Target not found
                return -1;
            }

            int mid = (low + high) / 2;

            if (array[mid] == target)
            {
                // Target found at index mid
                return mid;
            }
            else if (array[mid] > target)
            {
                // Target may be in the left half of the array
                return RecursiveBinarySearch(array, target, low, mid - 1);
            }
            else
            {
                // Target may be in the right half of the array
                return RecursiveBinarySearch(array, target, mid + 1, high);
            }
        }
        

public static class MasterTheorem
    {
        public static string GetTimeComplexity(int a, int b, int[] f)
        {
            int n = f.Length;

            // Case 1
            double epsilon = 0.0001;
            double case1 = Math.Log(a, b) - epsilon;
            if (Case1(f, case1))
            {
                return "O(n^" + case1 + ")";
            }

            // Case 2
            double case2 = Math.Log(a, b);
            if (Case2(f, case2))
            {
                return "O(n^" + case2 + " * log(n))";
            }

            // Case 3
            double case3 = Math.Log(a, b) + epsilon;
            if (Case3(f, case3))
            {
                return "O(" + f[n - 1] + ")";
            }

            // Unknown case
            return "Unknown time complexity";
        }

        private static bool Case1(int[] f, double exponent)
        {
            int n = f.Length;
            for (int i = 0; i < n; i++)
            {
                if (f[i] > Math.Pow(i + 1, exponent))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool Case2(int[] f, double exponent)
        {
            int n = f.Length;
            int logn = (int)Math.Ceiling(Math.Log(n, 2));
            int[] g = new int[logn];
            for (int i = 0; i < logn; i++)
            {
                int sum = 0;
                int power = (int)Math.Pow(n, i);
                for (int j = 0; j < n / power; j++)
                {
                    int index = j * power + power - 1;
                    if (index < n)
                    {
                        sum += f[index];
                    }
                }
                g[i] = sum;
            }
            return Case1(g, exponent);
        }

        private static bool Case3(int[] f, double exponent)
        {
            int n = f.Length;
            for (int i = 1; i < n; i++)
            {
                if (f[i] < Math.Pow(i + 1, exponent))
                {
                    return false;
                }
            }
            return true;
        }
    }
        public static int i = 0, j = 0, k = 0;


        public static void multiplyMatrixRec(int row1, int col1,
                                  int[,] A, int row2,
                                  int col2, int[,] B,
                                  int[,] C)
        {
            // If all rows traversed
            if (i >= row1)
                return;

            // If i < row1
            if (j < col2)
            {
                if (k < col1)
                {
                    C[i, j] += A[i, k] * B[k, j];
                    k++;

                    multiplyMatrixRec(row1, col1, A,
                                      row2, col2, B, C);
                }

                k = 0;
                j++;
                multiplyMatrixRec(row1, col1, A,
                                  row2, col2, B, C);
            }

            j = 0;
            i++;
            multiplyMatrixRec(row1, col1, A,
                              row2, col2, B, C);
        }
        static int N = 4;
        public static void multiply(int[,] mat1,
                         int[,] mat2, int[,] res)
        {
            int i, j, k;
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    res[i, j] = 0;
                    for (k = 0; k < N; k++)
                        res[i, j] += mat1[i, k]
                                     * mat2[k, j];
                }
            }
        }
        static void calculate(int n)
        {
            Random rng = new Random();
            float[,] m1 = new float[n, n];
            float[,] m2 = new float[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    m1[i, j] = (float)rng.NextDouble();
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    m2[i, j] = (float)rng.NextDouble();
                }
            }

            float[,] m3 = strassen(m1, m2, n);
        }

        public static float[,] strassen(float[,] a, float[,] b, int n)
        {
            if (n == 2)
            {
                var m1 = (a[0, 0] + a[1, 1]) * (b[0, 0] + b[1, 1]);
                var m2 = (a[1, 0] + a[1, 1]) * b[0, 0];
                var m3 = a[0, 0] * (b[0, 1] - b[1, 1]);
                var m4 = a[1, 1] * (b[1, 0] - b[0, 0]);
                var m5 = (a[0, 0] + a[0, 1]) * b[1, 1];
                var m6 = (a[1, 0] - a[0, 0]) * (b[0, 0] + b[0, 1]);
                var m7 = (a[0, 1] - a[1, 1]) * (b[1, 0] + b[1, 1]);
                a[0, 0] = m1 + m4 - m5 + m7;
                a[0, 1] = m3 + m5;
                a[1, 0] = m2 + m4;
                a[1, 1] = m1 - m2 + m3 + m6;
                return a;
            }
            else
            {
                float[,] a11 = matrixDivide(a, n, 11);
                float[,] a12 = matrixDivide(a, n, 12);
                float[,] a21 = matrixDivide(a, n, 21);
                float[,] a22 = matrixDivide(a, n, 22);

                float[,] b11 = matrixDivide(b, n, 11);
                float[,] b12 = matrixDivide(b, n, 12);
                float[,] b21 = matrixDivide(b, n, 21);
                float[,] b22 = matrixDivide(b, n, 22);

                float[,] p1 = strassen(a11, matrixDiff(b12, b22, n / 2), n / 2);
                float[,] p2 = strassen(matrixSum(a11, a12, n / 2), b22, n / 2);
                float[,] p3 = strassen(matrixSum(a21, a22, n / 2), b11, n / 2);
                float[,] p4 = strassen(a22, matrixDiff(b21, b11, n / 2), n / 2);
                float[,] p5 = strassen(matrixSum(a11, a22, n / 2), matrixSum(b11, b22, n / 2), n / 2);
                float[,] p6 = strassen(matrixDiff(a12, a22, n / 2), matrixSum(b21, b22, n / 2), n / 2);
                float[,] p7 = strassen(matrixDiff(a11, a21, n / 2), matrixSum(b11, b12, n / 2), n / 2);

                float[,] c11 = matrixDiff(matrixSum(p5, p4, n / 2), matrixDiff(p2, p6, n / 2), n / 2);
                float[,] c12 = matrixSum(p1, p2, n / 2);
                float[,] c21 = matrixSum(p3, p4, n / 2);
                float[,] c22 = matrixDiff(matrixSum(p1, p5, n / 2), matrixSum(p3, p7, n / 2), n / 2);

                for (int i = 0; i < n / 2; i++)
                {
                    for (int j = 0; j < n / 2; j++)
                    {
                        a[i, j] = c11[i, j];
                        a[i, j + n / 2] = c12[i, j];
                        a[i + n / 2, j] = c21[i, j];
                        a[i + n / 2, j + n / 2] = c22[i, j];
                    }
                }
                return a;
            }
        }

        static float[,] matrixSum(float[,] a, float[,] b, int n)
        {
            float[,] c = new float[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    c[i, j] = a[i, j] + b[i, j];
            return c;
        }


        static float[,] matrixDiff(float[,] a, float[,] b, int n)
        {
            float[,] c = new float[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    c[i, j] = a[i, j] - b[i, j];
            return c;
        }

        static float[,] matrixCombine(float[,] a11, float[,] a12, float[,] a21, float[,] a22, int n)
        {
            float[,] a = new float[n, n];
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    a[i, j] = a11[i, j];
                    a[i, j + n / 2] = a12[i, j];
                    a[i + n / 2, j] = a21[i, j];
                    a[i + n / 2, j + n / 2] = a22[i, j];
                }
            }
            return a;
        }

        static float[,] matrixDivide(float[,] a, int n, int region)
        {
            float[,] c = new float[n / 2, n / 2];
            if (region == 11)
            {
                for (int i = 0, x = 0; x < n / 2; i++, x++)
                {
                    for (int j = 0, y = 0; y < n / 2; j++, y++)
                    {
                        c[i, j] = a[x, y];
                    }
                }
            }
            else if (region == 12)
            {
                for (int i = 0, x = 0; x < n / 2; i++, x++)
                {
                    for (int j = 0, y = n / 2; y < n; j++, y++)
                    {
                        c[i, j] = a[x, y];
                    }
                }
            }
            else if (region == 21)
            {
                for (int i = 0, x = n / 2; x < n; i++, x++)
                {
                    for (int j = 0, y = 0; y < n / 2; j++, y++)
                    {
                        c[i, j] = a[x, y];
                    }
                }
            }
            else if (region == 22)
            {
                for (int i = 0, x = n / 2; x < n; i++, x++)
                {
                    for (int j = 0, y = n / 2; y < n; j++, y++)
                    {
                        c[i, j] = a[x, y];
                    }
                }
            }
            return c;
        }



        public static void enableDebug(bool v)
        {
            throw new NotImplementedException();
        }
    }

}

