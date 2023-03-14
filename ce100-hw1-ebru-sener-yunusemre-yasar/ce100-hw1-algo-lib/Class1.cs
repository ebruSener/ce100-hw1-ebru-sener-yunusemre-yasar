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

        public static void RecursiveMergeSort1(int[] array)
        {
            // Check for base cases
            if (array == null || array.Length <= 1)
            {
                return;
            }
            // Create a temporary array to store the sorted values
            int[] temp = new int[array.Length];
            // Call the recursive sort method with the initial left and right indices
            RecursiveSort(array, temp, 0, array.Length - 1);
        }

        private static void RecursiveSort(int[] array, int[] temp, int left, int right)
        {
            // Check for base case
            if (left < right)
            {
                // Calculate the middle index
                int mid = left + (right - left) / 2;
                // Recursively sort the left and right halves
                RecursiveSort(array, temp, left, mid);
                RecursiveSort(array, temp, mid + 1, right);
                // Merge the sorted halves
                Merge(array, temp, left, mid, right);
            }
        }

        private static void Merge(int[] array, int[] temp, int left, int mid, int right)
        {
            // Initialize the indices for the left, right, and temporary arrays
            int i = left;
            int j = mid + 1;
            int k = left;
            // Merge the two halves by comparing elements and storing them in the temporary array
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
            // Copy any remaining elements in the left half to the temporary array
            while (i <= mid)
            {
                temp[k] = array[i];
                i++;
                k++;
            }
            // Copy any remaining elements in the right half to the temporary array
            while (j <= right)
            {
                temp[k] = array[j];
                j++;
                k++;
            }
            // Copy the sorted values from the temporary array back to the original array
            for (int l = left; l <= right; l++)
            {
                array[l] = temp[l];
            }
        }


        private static int RandomizedPartition(int[] arr, int left, int right)
        {
            // Create a new Random object to generate random numbers
            Random rand = new Random();

            // Generate a random index between left and right, inclusive
            int randomIndex = rand.Next(left, right + 1);

            // Choose the element at the random index as the pivot
            int pivot = arr[randomIndex];

            // Swap the pivot element with the last element in the partition
            Swap(arr, randomIndex, right);

            // Initialize two indices i and j
            int i = left - 1;
            int j = right;

            // Loop until i and j cross each other
            while (true)
            {
                // Increment i until arr[i] >= pivot
                do i++; while (arr[i] < pivot);

                // Decrement j until arr[j] <= pivot or j reaches the left index
                do j--; while (j > 0 && arr[j] > pivot);

                // If i and j have crossed each other, swap the pivot element with arr[i]
                if (i >= j)
                {
                    Swap(arr, i, right);
                    return i;
                }

                // Swap arr[i] and arr[j]
                Swap(arr, i, j);
            }
        }


        private static void Swap(int[] arr, int i, int j)
        {
            // Store the value of arr[i] in a temporary variable
            int temp = arr[i];

            // Assign the value of arr[j] to arr[i]
            arr[i] = arr[j];

            // Assign the value of the temporary variable to arr[j]
            arr[j] = temp;
        }


        public static void QuickSort2(int[] arr, int left, int right)
        {
            // Check if the array has more than one element
            if (left < right)
            {
                // Partition the array around a pivot element and get its index
                int pivotIndex = LomutoPartition(arr, left, right);

                // Sort the left subarray recursively
                QuickSort2(arr, left, pivotIndex - 1);

                // Sort the right subarray recursively
                QuickSort2(arr, pivotIndex + 1, right);
            }
        }


        private static int LomutoPartition(int[] arr, int left, int right)
        {
            // Choose the last element as the pivot
            int pivot = arr[right];
            // Initialize the partition index
            int i = left;

            // Iterate over the array elements
            for (int j = left; j < right; j++)
            {
                // If an element is smaller than the pivot
                if (arr[j] < pivot)
                {
                    // Swap it with the element at the partition index
                    if (i != j)
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                    // Increment the partition index
                    i++;
                }
            }

            // Swap the pivot element with the element at the partition index
            if (i != right)
            {
                arr[right] = arr[i];
                arr[i] = pivot;
            }

            // Return the partition index
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

                // Case 1: f(n) = O(n^(log_b(a) - ε)) for some ε > 0
                double epsilon = 0.0001;
                double case1 = Math.Log(a, b) - epsilon;
                if (Case1(f, case1))
                {
                    return "O(n^" + case1 + ")";
                }

                // Case 2: f(n) = O(n^(log_b(a)))
                double case2 = Math.Log(a, b);
                if (Case2(f, case2))
                {
                    return "O(n^" + case2 + " * log(n))";
                }

                // Case 3: f(n) = O(n^(log_b(a) + ε)) for some ε > 0 and f(n) is polynomially larger than n^(log_b(a))
                double case3 = Math.Log(a, b) + epsilon;
                if (Case3(f, case3))
                {
                    return "O(" + f[n - 1] + ")";
                }

                // Unknown case: f(n) is not one of the above
                return "Unknown time complexity";
            }

            private static bool Case1(int[] f, double exponent)
            {
                // Get the length of the input array
                int n = f.Length;

                // Loop through each element in the array
                for (int i = 0; i < n; i++)
                {
                    // Check if the value at index i is greater than n^exponent
                    if (f[i] > Math.Pow(i + 1, exponent))
                    {
                        // If so, the input does not satisfy case 1 of the Master Theorem
                        // and we can immediately return false
                        return false;
                    }
                }

                // If we have iterated through the entire array without returning false,
                // the input satisfies case 1 of the Master Theorem and we can return true
                return true;
            }


            private static bool Case2(int[] f, double exponent)
            {
                // Get the length of the input array.
                int n = f.Length;
                // Calculate the logarithm of n to base 2 and round up to the nearest integer.
                int logn = (int)Math.Ceiling(Math.Log(n, 2));
                // Create a new array to store the values of g.
                int[] g = new int[logn];
                // Loop through each value of i from 0 to logn-1.
                for (int i = 0; i < logn; i++)
                {
                    // Initialize a variable to store the sum of f values.
                    int sum = 0;
                    // Calculate the power of n to the ith power.
                    int power = (int)Math.Pow(n, i);
                    // Loop through each value of j from 0 to n/power-1.
                    for (int j = 0; j < n / power; j++)
                    {
                        // Calculate the index of the element in f that corresponds to the jth group of size n^i.
                        int index = j * power + power - 1;
                        // If the index is within the bounds of the array, add its value to the sum.
                        if (index < n)
                        {
                            sum += f[index];
                        }
                    }
                    // Store the sum of f values for the ith group in g[i].
                    g[i] = sum;
                }
                // Return true if Case1(g, exponent) is true, and false otherwise.
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

        static int N = 10;
        public static void iterativematrixMultiplication(int[,] mat1,
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


        // iterative matrix
        /*   static int N = 4;
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
           } */

        static void calculate(int n)
        {
            // Create a new random number generator
            Random rng = new Random();

            // Create two matrices m1 and m2, each with n rows and columns
            float[,] m1 = new float[n, n];
            float[,] m2 = new float[n, n];

            // Initialize the values of m1 and m2 with random float numbers between 0 and 1
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

            // Call the Strassen matrix multiplication algorithm with m1, m2, and n
            float[,] m3 = strassen(m1, m2, n);
        }


        public static float[,] strassen(float[,] a, float[,] b, int n)
        {
            // if matrix size is 2x2, use standard matrix multiplication
            if (n == 2)
            {
                // compute the 7 products needed for Strassen's algorithm

                var m1 = (a[0, 0] + a[1, 1]) * (b[0, 0] + b[1, 1]);
                var m2 = (a[1, 0] + a[1, 1]) * b[0, 0];
                var m3 = a[0, 0] * (b[0, 1] - b[1, 1]);
                var m4 = a[1, 1] * (b[1, 0] - b[0, 0]);
                var m5 = (a[0, 0] + a[0, 1]) * b[1, 1];
                var m6 = (a[1, 0] - a[0, 0]) * (b[0, 0] + b[0, 1]);
                var m7 = (a[0, 1] - a[1, 1]) * (b[1, 0] + b[1, 1]);

                // compute the resulting submatrix c
                a[0, 0] = m1 + m4 - m5 + m7;
                a[0, 1] = m3 + m5;
                a[1, 0] = m2 + m4;
                a[1, 1] = m1 - m2 + m3 + m6;

                // return the resulting submatrix c
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

                // compute 7 products recursively
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
                        // Assign the value of c11[i, j] to the corresponding element of a
                        a[i, j] = c11[i, j];

                        // Assign the value of c12[i, j] to the corresponding element of a,
                        // with an offset of n/2 in the j direction
                        a[i, j + n / 2] = c12[i, j];

                        // Assign the value of c21[i, j] to the corresponding element of a,
                        // with an offset of n/2 in the i direction
                        a[i + n / 2, j] = c21[i, j];

                        // Assign the value of c22[i, j] to the corresponding element of a,
                        // with offsets of n/2 in both the i and j directions
                        a[i + n / 2, j + n / 2] = c22[i, j];
                    }
                }
                // Return the resulting matrix a
                return a;

            }
        }

        static float[,] matrixSum(float[,] a, float[,] b, int n)
        {
            // Create a new matrix c of size n x n
            float[,] c = new float[n, n];

            // Loop through each row (i) and column (j) of the matrices a and b
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    // Add the corresponding elements of matrices a and b, and store the result in the corresponding cell of matrix c
                    c[i, j] = a[i, j] + b[i, j];

            // Return the resulting matrix c
            return c;
        }



        static float[,] matrixDiff(float[,] a, float[,] b, int n)
        {
            // Create a new 2D float array with dimensions n x n to store the result
            float[,] c = new float[n, n];

            // Loop through each row and column of the arrays a and b
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    // Subtract the values in the corresponding cells of a and b,
                    // and store the result in the corresponding cell of c
                    c[i, j] = a[i, j] - b[i, j];

            // Return the resulting 2D float array c
            return c;
        }


        static float[,] matrixCombine(float[,] a11, float[,] a12, float[,] a21, float[,] a22, int n)
        {
            // Create a new 2D array `a` of size `n` x `n`
            float[,] a = new float[n, n];

            // Iterate over the first `n/2` rows and columns of the `a` array
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    // Assign the values from the `a11`, `a12`, `a21`, and `a22` arrays to the appropriate positions in `a`
                    a[i, j] = a11[i, j];
                    a[i, j + n / 2] = a12[i, j];
                    a[i + n / 2, j] = a21[i, j];
                    a[i + n / 2, j + n / 2] = a22[i, j];
                }
            }

            // Return the combined `a` array
            return a;
        }


        static float[,] matrixDivide(float[,] a, int n, int region)
        {
            // create a new float array c with half the dimensions of a
            float[,] c = new float[n / 2, n / 2];
            // check the value of region to determine which quadrant to extract from a
            if (region == 11)
            {
                // extract quadrant 11 by iterating over the first half of each dimension in a
                for (int i = 0, x = 0; x < n / 2; i++, x++)
                {
                    for (int j = 0, y = 0; y < n / 2; j++, y++)
                    {
                        c[i, j] = a[x, y];  // set each element in c to the corresponding element in quadrant 11 of a
                    }
                }
            }
            else if (region == 12)
            {
                // extract quadrant 12 by iterating over the first half of the rows and the second half of the columns in a
                for (int i = 0, x = 0; x < n / 2; i++, x++)
                {
                    for (int j = 0, y = n / 2; y < n; j++, y++)
                    {
                        c[i, j] = a[x, y];  // set each element in c to the corresponding element in quadrant 12 of a
                    }
                }
            }
            else if (region == 21)
            {
                // extract quadrant 21 by iterating over the second half of the rows and the first half of the columns in a
                for (int i = 0, x = n / 2; x < n; i++, x++)
                {
                    for (int j = 0, y = 0; y < n / 2; j++, y++)
                    {
                        c[i, j] = a[x, y];  // set each element in c to the corresponding element in quadrant 21 of a
                    }
                }
            }
            else if (region == 22)
            {
                // extract quadrant 22 by iterating over the second half of each dimension in a
                for (int i = 0, x = n / 2; x < n; i++, x++)
                {
                    for (int j = 0, y = n / 2; y < n; j++, y++)
                    {
                        c[i, j] = a[x, y];  // set each element in c to the corresponding element in quadrant 22 of a
                    }
                }
            }
            // return the extracted quadrant as a new array
            return c;
        }




        public static void enableDebug(bool v)
        {
            throw new NotImplementedException();
        }
    }

}

