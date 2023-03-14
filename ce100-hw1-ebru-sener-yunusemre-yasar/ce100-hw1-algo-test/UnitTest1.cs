using ce100_hw1_algo_lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using static ce100_hw1_algo_lib.Class1;

namespace ce100_hw1_algo_test
{
    [TestClass]
    public class UnitTest1
    {


        [TestClass]
        public class SelectionSortTests
        {




            [TestMethod]
            public void Sort_SortsLargeArrayInAscendingOrder()
            {
                // Arrange
                int[] unsortedArray = GenerateRandomArray(10000);
                int[] expectedArray = (int[])unsortedArray.Clone();
                Array.Sort(expectedArray);

                // Act
                SelectionSort(unsortedArray);

                // Assert
                CollectionAssert.AreEqual(expectedArray, unsortedArray);
            }

            private int[] GenerateRandomArray(int size)
            {
                int[] array = new int[size];
                Random random = new Random();
                for (int i = 0; i < size; i++)
                {
                    array[i] = random.Next();
                }
                return array;
            }

            private void SelectionSort(int[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    int minIndex = i;
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[j] < array[minIndex])
                        {
                            minIndex = j;
                        }
                    }
                    int temp = array[minIndex];
                    array[minIndex] = array[i];
                    array[i] = temp;
                }
            }
        }

    }


    [TestClass]
    public class SelectionSortTests
    {
        [TestMethod]
        public void Sort_ReturnsSortedArray_ForBestCase()
        {
            // Arrange
            int[] array = GenerateBestCaseArray(10000);
            int[] expectedArray = array.OrderBy(x => x).ToArray();

            // Act
            SelectionSort(array);

            // Assert
            CollectionAssert.AreEqual(expectedArray, array);
        }

        private int[] GenerateBestCaseArray(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = i;
            }
            return array;
        }

        private void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    int temp = array[minIndex];
                    array[minIndex] = array[i];
                    array[i] = temp;
                }
            }
        }





        [TestClass]
        public class SelectionSortTests2
        {
            [TestMethod]
            public void Sort_SortsArrayWithNearlySortedElementsInAscendingOrder()
            {
                // Arrange
                int[] unsortedArray = GenerateNearlySortedArray(10000, 10);
                int[] expectedArray = GenerateSortedArray(10000);

                // Act
                SelectionSort(unsortedArray);

                // Assert
                CollectionAssert.AreEqual(expectedArray, unsortedArray);
            }

            private int[] GenerateNearlySortedArray(int size, int swaps)
            {
                int[] array = GenerateSortedArray(size);
                Random random = new Random();
                for (int i = 0; i < swaps; i++)
                {
                    int index1 = random.Next(size);
                    int index2 = random.Next(size);
                    int temp = array[index1];
                    array[index1] = array[index2];
                    array[index2] = temp;
                }
                return array;
            }

            private int[] GenerateSortedArray(int size)
            {
                int[] array = new int[size];
                for (int i = 0; i < size; i++)
                {
                    array[i] = i + 1;
                }
                return array;
            }

            private void SelectionSort(int[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    int minIndex = i;
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[j] < array[minIndex])
                        {
                            minIndex = j;
                        }
                    }
                    int temp = array[minIndex];
                    array[minIndex] = array[i];
                    array[i] = temp;
                }
            }




            [TestClass]
            public class MergeSortTests
            {
                [TestMethod]
                public void Sort_SortsArrayOf10000RandomIntegers()
                {
                    // Arrange
                    int[] unsortedArray = GenerateRandomArray(10000);
                    int[] expectedArray = (int[])unsortedArray.Clone();
                    Array.Sort(expectedArray);

                    // Act
                    MergeSort(unsortedArray);

                    // Assert
                    CollectionAssert.AreEqual(expectedArray, unsortedArray);
                }

                private int[] GenerateRandomArray(int size)
                {
                    int[] array = new int[size];
                    Random random = new Random();
                    for (int i = 0; i < size; i++)
                    {
                        array[i] = random.Next();
                    }
                    return array;
                }

                private void MergeSort(int[] array)
                {
                    if (array.Length > 1)
                    {
                        int mid = array.Length / 2;
                        int[] leftArray = new int[mid];
                        int[] rightArray = new int[array.Length - mid];
                        Array.Copy(array, 0, leftArray, 0, leftArray.Length);
                        Array.Copy(array, mid, rightArray, 0, rightArray.Length);
                        MergeSort(leftArray);
                        MergeSort(rightArray);
                        Merge(array, leftArray, rightArray);
                    }
                }

                private void Merge(int[] array, int[] leftArray, int[] rightArray)
                {
                    int i = 0;
                    int j = 0;
                    int k = 0;
                    while (i < leftArray.Length && j < rightArray.Length)
                    {
                        if (leftArray[i] <= rightArray[j])
                        {
                            array[k] = leftArray[i];
                            i++;
                        }
                        else
                        {
                            array[k] = rightArray[j];
                            j++;
                        }
                        k++;
                    }
                    while (i < leftArray.Length)
                    {
                        array[k] = leftArray[i];
                        i++;
                        k++;
                    }
                    while (j < rightArray.Length)
                    {
                        array[k] = rightArray[j];
                        j++;
                        k++;
                    }
                }
            }

        }



        [TestClass]
        public class MergeSortTests
        {
            [TestMethod]
            public void Sort_ReturnsSortedArray_ForBestCase()
            {
                // Arrange
                int[] array = GenerateBestCaseArray(10000);
                int[] expectedArray = (int[])array.Clone();
                Array.Sort(expectedArray);

                // Act
                MergeSort(array, 0, array.Length - 1);

                // Assert
                CollectionAssert.AreEqual(expectedArray, array);
            }

            private int[] GenerateBestCaseArray(int size)
            {
                int[] array = new int[size];
                for (int i = 0; i < size; i++)
                {
                    array[i] = i;
                }
                return array;
            }

            private void MergeSort(int[] array, int left, int right)
            {
                if (left < right)
                {
                    int mid = (left + right) / 2;
                    MergeSort(array, left, mid);
                    MergeSort(array, mid + 1, right);
                    Merge(array, left, mid, right);
                }
            }

            private void Merge(int[] array, int left, int mid, int right)
            {
                int[] temp = new int[array.Length];
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

                for (int x = left; x <= right; x++)
                {
                    array[x] = temp[x];
                }
            }
        }



        [TestClass]
        public class MergeSortTests2
        {
            [TestMethod]
            public void Sort_SortsArrayOf10000EqualIntegers()
            {
                // Arrange
                int[] unsortedArray = GenerateEqualArray(10000);
                int[] expectedArray = (int[])unsortedArray.Clone();
                Array.Sort(expectedArray);

                // Act
                MergeSort(unsortedArray);

                // Assert
                CollectionAssert.AreEqual(expectedArray, unsortedArray);
            }

            private int[] GenerateEqualArray(int size)
            {
                int[] array = new int[size];
                for (int i = 0; i < size; i++)
                {
                    array[i] = 1;
                }
                return array;
            }

            private void MergeSort(int[] array)
            {
                if (array.Length > 1)
                {
                    int mid = array.Length / 2;
                    int[] leftArray = new int[mid];
                    int[] rightArray = new int[array.Length - mid];
                    Array.Copy(array, 0, leftArray, 0, leftArray.Length);
                    Array.Copy(array, mid, rightArray, 0, rightArray.Length);
                    MergeSort(leftArray);
                    MergeSort(rightArray);
                    Merge(array, leftArray, rightArray);
                }
            }

            private void Merge(int[] array, int[] leftArray, int[] rightArray)
            {
                int i = 0;
                int j = 0;
                int k = 0;
                while (i < leftArray.Length && j < rightArray.Length)
                {
                    if (leftArray[i] <= rightArray[j])
                    {
                        array[k] = leftArray[i];
                        i++;
                    }
                    else
                    {
                        array[k] = rightArray[j];
                        j++;
                    }
                    k++;
                }
                while (i < leftArray.Length)
                {
                    array[k] = leftArray[i];
                    i++;
                    k++;
                }
                while (j < rightArray.Length)
                {
                    array[k] = rightArray[j];
                    j++;
                    k++;
                }
            }
        }


        [TestClass]
        public class QuickSortTests
        {
            [TestMethod]
            public void Sort_SortsArrayOf10000RandomIntegers()
            {
                // Arrange
                int[] unsortedArray = GenerateRandomArray(10000);
                int[] expectedArray = (int[])unsortedArray.Clone();
                Array.Sort(expectedArray);

                // Act
                QuickSort(unsortedArray, 0, unsortedArray.Length - 1);

                // Assert
                CollectionAssert.AreEqual(expectedArray, unsortedArray);
            }

            private int[] GenerateRandomArray(int size)
            {
                int[] array = new int[size];
                Random random = new Random();
                for (int i = 0; i < size; i++)
                {
                    array[i] = random.Next();
                }
                return array;
            }

            private void QuickSort(int[] array, int low, int high)
            {
                if (low < high)
                {
                    int pivotIndex = RandomizedPartition(array, low, high);
                    QuickSort(array, low, pivotIndex);
                    QuickSort(array, pivotIndex + 1, high);
                }
            }

            private int RandomizedPartition(int[] array, int low, int high)
            {
                int pivotIndex = new Random().Next(low, high);
                int pivotValue = array[pivotIndex];
                int i = low - 1;
                int j = high + 1;
                while (true)
                {
                    do
                    {
                        i++;
                    } while (array[i] < pivotValue);
                    do
                    {
                        j--;
                    } while (array[j] > pivotValue);
                    if (i >= j)
                    {
                        return j;
                    }
                    Swap(array, i, j);
                }
            }

            private void Swap(int[] array, int i, int j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }


        [TestClass]
        public class RandomizedQuicksortTests
        {
            [TestMethod]
            public void Sort_ReturnsSortedArray_ForBestCase()
            {
                // Arrange
                int[] expectedArray = GenerateBestCaseArray(10000);
                int[] actualArray = (int[])expectedArray.Clone();

                // Act
                RandomizedQuicksort(actualArray, 0, actualArray.Length - 1);

                // Assert
                CollectionAssert.AreEqual(expectedArray, actualArray);
            }

            private int[] GenerateBestCaseArray(int size)
            {
                int[] array = new int[size];
                for (int i = 0; i < size; i++)
                {
                    array[i] = i;
                }
                return array;
            }

            private void RandomizedQuicksort(int[] array, int left, int right)
            {
                if (left < right)
                {
                    int pivotIndex = Partition(array, left, right);
                    RandomizedQuicksort(array, left, pivotIndex - 1);
                    RandomizedQuicksort(array, pivotIndex + 1, right);
                }
            }

            private int Partition(int[] array, int left, int right)
            {
                int pivotIndex = new Random().Next(left, right + 1);
                int pivotValue = array[pivotIndex];

                int i = left - 1;
                int j = right + 1;

                while (true)
                {
                    do
                    {
                        i++;
                    } while (array[i] < pivotValue);

                    do
                    {
                        j--;
                    } while (array[j] > pivotValue);

                    if (i >= j)
                    {
                        return j;
                    }

                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }



        [TestClass]
        public class QuickSortTests3
        {
            [TestMethod]
            public void Sort_SortsArrayOf10000EqualIntegers()
            {
                // Arrange
                int[] unsortedArray = GenerateEqualArray(10000);
                int[] expectedArray = (int[])unsortedArray.Clone();

                // Act
                QuickSort(unsortedArray, 0, unsortedArray.Length - 1);

                // Assert
                CollectionAssert.AreEqual(expectedArray, unsortedArray);
            }

            private int[] GenerateEqualArray(int size)
            {
                int[] array = new int[size];
                for (int i = 0; i < size; i++)
                {
                    array[i] = 1;
                }
                return array;
            }

            private void QuickSort(int[] array, int low, int high)
            {
                if (low < high)
                {
                    int pivotIndex = RandomizedPartition(array, low, high);
                    QuickSort(array, low, pivotIndex);
                    QuickSort(array, pivotIndex + 1, high);
                }
            }

            private int RandomizedPartition(int[] array, int low, int high)
            {
                int pivotIndex = new Random().Next(low, high);
                int pivotValue = array[pivotIndex];
                int i = low - 1;
                int j = high + 1;
                while (true)
                {
                    do
                    {
                        i++;
                    } while (array[i] < pivotValue);
                    do
                    {
                        j--;
                    } while (array[j] > pivotValue);
                    if (i >= j)
                    {
                        return j;
                    }
                    Swap(array, i, j);
                }
            }

            private void Swap(int[] array, int i, int j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }


        [TestClass]
        public class QuickSortTestsx
        {
            [TestMethod]
            public void Sort_SortsArrayOf10000RandomIntegers()
            {
                // Arrange
                int[] unsortedArray = GenerateRandomArray(10000);
                int[] expectedArray = (int[])unsortedArray.Clone();
                Array.Sort(expectedArray);

                // Act
                QuickSort(unsortedArray, 0, unsortedArray.Length - 1);

                // Assert
                CollectionAssert.AreEqual(expectedArray, unsortedArray);
            }

            private int[] GenerateRandomArray(int size)
            {
                int[] array = new int[size];
                Random random = new Random();
                for (int i = 0; i < size; i++)
                {
                    array[i] = random.Next();
                }
                return array;
            }

            private void QuickSort(int[] array, int low, int high)
            {
                if (low < high)
                {
                    int pivotIndex = RandomizedPartition(array, low, high);
                    QuickSort(array, low, pivotIndex - 1);
                    QuickSort(array, pivotIndex + 1, high);
                }
            }

            private int RandomizedPartition(int[] array, int low, int high)
            {
                int pivotIndex = new Random().Next(low, high);
                int pivotValue = array[pivotIndex];
                Swap(array, pivotIndex, high);
                int i = low - 1;
                for (int j = low; j < high; j++)
                {
                    if (array[j] < pivotValue)
                    {
                        i++;
                        Swap(array, i, j);
                    }
                }
                Swap(array, i + 1, high);
                return i + 1;
            }

            private void Swap(int[] array, int i, int j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }


        [TestClass]
        public class QuickSortTests2
        {
            [TestMethod]
            public void Sort_ReturnsSortedArray_ForBestCase()
            {
                // Arrange
                int[] array = GenerateBestCaseArray(10000);
                int[] expectedArray = GenerateSortedArray(10000);

                // Act
                QuickSort(array, 0, array.Length - 1);

                // Assert
                CollectionAssert.AreEqual(expectedArray, array);
            }

            private int[] GenerateBestCaseArray(int size)
            {
                int[] array = new int[size];
                for (int i = 0; i < size; i++)
                {
                    array[i] = i;
                }
                return array;
            }

            private int[] GenerateSortedArray(int size)
            {
                int[] array = new int[size];
                for (int i = 0; i < size; i++)
                {
                    array[i] = i;
                }
                return array;
            }

            private void QuickSort(int[] array, int low, int high)
            {
                if (low < high)
                {
                    int pivotIndex = LomutoPartition(array, low, high);
                    QuickSort(array, low, pivotIndex - 1);
                    QuickSort(array, pivotIndex + 1, high);
                }
            }

            private int LomutoPartition(int[] array, int low, int high)
            {
                int pivot = array[high];
                int i = low - 1;

                for (int j = low; j <= high - 1; j++)
                {
                    if (array[j] < pivot)
                    {
                        i++;
                        Swap(array, i, j);
                    }
                }

                Swap(array, i + 1, high);

                return i + 1;
            }

            private void Swap(int[] array, int i, int j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

    }


    [TestClass]
    public class QuickSortTestsz
    {
        [TestMethod]
        public void Sort_SortsArrayOf10000ReverseSortedIntegers()
        {
            // Arrange
            int[] unsortedArray = GenerateReverseSortedArray(10000);
            int[] expectedArray = (int[])unsortedArray.Clone();
            Array.Sort(expectedArray);

            // Act
            QuickSort(unsortedArray, 0, unsortedArray.Length - 1);

            // Assert
            CollectionAssert.AreEqual(expectedArray, unsortedArray);
        }

        private int[] GenerateReverseSortedArray(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = size - i;
            }
            return array;
        }

        private void QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = RandomizedPartition(array, low, high);
                QuickSort(array, low, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, high);
            }
        }

        private int RandomizedPartition(int[] array, int low, int high)
        {
            int pivotIndex = new Random().Next(low, high);
            int pivotValue = array[pivotIndex];
            Swap(array, pivotIndex, high);
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (array[j] < pivotValue)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, high);
            return i + 1;
        }

        private void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }


    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        public void Search_ReturnsCorrectIndex_ForAverageCase()
        {
            // Arrange
            int[] array = GenerateSortedArray(10000);
            int target = array[new Random().Next(array.Length)];
            int expectedIndex = Array.IndexOf(array, target);

            // Act
            int actualIndex = BinarySearch(array, target);

            // Assert
            Assert.AreEqual(expectedIndex, actualIndex);
        }

        private int[] GenerateSortedArray(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = i;
            }
            return array;
        }

        private int BinarySearch(int[] array, int target)
        {
            int low = 0;
            int high = array.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (array[mid] == target)
                {
                    return mid;
                }
                else if (array[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return -1;
        }
    }


    [TestClass]
    public class BinarySearchTests2
    {
        [TestMethod]
        public void Search_ReturnsNegativeOne_ForBadCase()
        {
            // Arrange
            int[] array = GenerateBadCaseArray(10000);
            int target = -1;

            // Act
            int actualIndex = BinarySearch(array, target);

            // Assert
            Assert.AreEqual(-1, actualIndex);
        }

        private int[] GenerateBadCaseArray(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = size - i;
            }
            return array;
        }

        private int BinarySearch(int[] array, int target)
        {
            int low = 0;
            int high = array.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (array[mid] == target)
                {
                    return mid;
                }
                else if (array[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return -1;
        }
    }


    [TestClass]
    public class BinarySearchTests3
    {
        [TestMethod]
        public void Search_ReturnsIndexOfLastElement_ForWorstCase()
        {
            // Arrange
            int[] array = GenerateWorstCaseArray(10000);
            int target = array[array.Length - 1];

            // Act
            int actualIndex = BinarySearch(array, target);

            // Assert
            Assert.AreEqual(array.Length - 1, actualIndex);
        }

        private int[] GenerateWorstCaseArray(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = i;
            }
            return array;
        }

        private int BinarySearch(int[] array, int target)
        {
            int low = 0;
            int high = array.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (array[mid] == target)
                {
                    return mid;
                }
                else if (array[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return -1;
        }
    }


    [TestClass]
    public class RecursiveBinarySearchTests6
    {
        [TestMethod]
        public void Search_ReturnsCorrectIndex_ForAverageCase()
        {
            // Arrange
            int[] array = GenerateAverageCaseArray(10000);
            int target = array[5000];

            // Act
            int actualIndex = RecursiveBinarySearch(array, target, 0, array.Length - 1);

            // Assert
            Assert.AreEqual(5000, actualIndex);
        }

        private int[] GenerateAverageCaseArray(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = i * 2;
            }
            return array;
        }

        private int RecursiveBinarySearch(int[] array, int target, int low, int high)
        {
            if (low > high)
            {
                return -1;
            }

            int mid = (low + high) / 2;

            if (array[mid] == target)
            {
                return mid;
            }
            else if (array[mid] > target)
            {
                return RecursiveBinarySearch(array, target, low, mid - 1);
            }
            else
            {
                return RecursiveBinarySearch(array, target, mid + 1, high);
            }
        }
    }



    [TestClass]
    public class RecursiveBinarySearchTests2
    {
        [TestMethod]
        public void Search_ReturnsIndex_ForWorstCase()
        {
            // Arrange
            int[] array = GenerateWorstCaseArray(10000);
            int target = array[array.Length - 1];

            // Act
            int actualIndex = RecursiveBinarySearch(array, target, 0, array.Length - 1);

            // Assert
            Assert.AreEqual(array.Length - 1, actualIndex);
        }

        private int[] GenerateWorstCaseArray(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = i;
            }
            return array;
        }

        private int RecursiveBinarySearch(int[] array, int target, int low, int high)
        {
            if (low > high)
            {
                return -1;
            }

            int mid = (low + high) / 2;

            if (array[mid] == target)
            {
                return mid;
            }
            else if (array[mid] > target)
            {
                return RecursiveBinarySearch(array, target, low, mid - 1);
            }
            else
            {
                return RecursiveBinarySearch(array, target, mid + 1, high);
            }
        }
    }


    [TestClass]
    public class RecursiveBinarySearchTests5
    {
        [TestMethod]
        public void Search_ReturnsNegativeOne_ForBadCase()
        {
            // Arrange
            int[] array = GenerateBadCaseArray(10000);
            int target = 10001;

            // Act
            int actualIndex = RecursiveBinarySearch(array, target, 0, array.Length - 1);

            // Assert
            Assert.AreEqual(-1, actualIndex);
        }

        private int[] GenerateBadCaseArray(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = i;
            }
            return array;
        }

        private int RecursiveBinarySearch(int[] array, int target, int low, int high)
        {
            if (low > high)
            {
                return -1;
            }

            int mid = (low + high) / 2;

            if (array[mid] == target)
            {
                return mid;
            }
            else if (array[mid] > target)
            {
                return RecursiveBinarySearch(array, target, low, mid - 1);
            }
            else
            {
                return RecursiveBinarySearch(array, target, mid + 1, high);
            }
        }
    }




    public class MasterTheoremTests
    {

        public void TestCase1()
        {
            int[] f = new int[] { 1, 2, 3, 4, 5 };
            string complexity = MasterTheorem.GetTimeComplexity(2, 2, f);
            Assert.AreEqual("O(n^1.9999)", complexity);
        }


        public void TestCase2()
        {
            int[] f = new int[] { 1, 2, 4, 8, 16 };
            string complexity = MasterTheorem.GetTimeComplexity(2, 2, f);
            Assert.AreEqual("O(n^2 * log(n))", complexity);
        }


        public void TestCase3()
        {
            int[] f = new int[] { 16, 8, 4, 2, 1 };
            string complexity = MasterTheorem.GetTimeComplexity(2, 2, f);
            Assert.AreEqual("O(1)", complexity);
        }


        public void TestUnknownCase()
        {
            int[] f = new int[] { 1, 2, 3, 4 };
            string complexity = MasterTheorem.GetTimeComplexity(3, 2, f);
            Assert.AreEqual("Unknown time complexity", complexity);
        }


        // matrix's tests


        [TestMethod]
        public void multiplyMatrixRecTestMethod1()
        {
            int row1 = 3, col1 = 3,
            row2 = 3, col2 = 3;
            int[,] A = {{1, 2, 3},
                    {4, 5, 6},
                    {7, 8, 9}};

            int[,] B = {{1, 2, 3},
                    {4, 5, 6},
                    {7, 8, 9}};

            int[,] C = new int[row1, col2];
            Class1.enableDebug(true);
            int[,] expected = { { 30, 36, 42 }, { 66, 81, 96 }, { 102, 126, 150 } };
            Class1.multiplyMatrixRec(row1, col1, A, row2, col2, B, C);
            Class1.enableDebug(false);
            CollectionAssert.AreEqual(expected, C);
        }



        [TestMethod]
        public void multiplyMatrixRecTestMethod2()
        {
            int row1 = 3, col1 = 3,
            row2 = 3, col2 = 3;
            int[,] A = {{10, 11, 12},
                       {13, 14, 15},
                       {16, 17, 18}};
            Class1.i = 0; Class1.j = 0; Class1.k = 0;
            int[,] B = {{10, 11, 12},
                       {13, 14, 15},
                       {16, 17, 18}};

            int[,] C = new int[row1, col2];
            Class1.enableDebug(true);
            int[,] expected = { { 435, 468, 501 }, { 552, 594, 636 }, { 669, 720, 771 } };
            Class1.multiplyMatrixRec(row1, col1, A, row2, col2, B, C);
            Class1.enableDebug(false);
            CollectionAssert.AreEqual(expected, C);
        }


        [TestMethod]
        public void multiplyMatrixRecTestMethod3()
        {
            int row1 = 2, col1 = 2,
            row2 = 2, col2 = 2;
            int[,] A = {{12,32},
                    {41, 3}};
            Class1.i = 0; Class1.j = 0; Class1.k = 0;

            int[,] B = {{23,41},
                    {9,12}};

            int[,] C = new int[row1, col2];
            Class1.enableDebug(true);
            int[,] expected = { { 564, 876 }, { 970, 1717 } };
            Class1.multiplyMatrixRec(row1, col1, A, row2, col2, B, C);
            Class1.enableDebug(false);
            CollectionAssert.AreEqual(expected, C);
        }



        [TestMethod]
        public void multiplyMatrixIterativeTestMethod1()
        {

            int[,] A = {{ 1, 1, 1, 1 },
                         { 2, 2, 2, 2 },
                         { 3, 3, 3, 3 },
                         { 4, 4, 4, 4 }};
            Class1.i = 0; Class1.j = 0; Class1.k = 0;
            int N = 4;
            int[,] B = { {1, 1, 1, 1 },
                         { 2, 2, 2, 2 },
                         { 3, 3, 3, 3 },
                         { 4, 4, 4, 4 }};

            int[,] C = new int[N, N];

            int[,] expected = { { 10,10,10,10 },
                                { 20,20,20,20},
                                { 30,30,30,30},
                                { 40,40,40,40} };
            Class1.enableDebug(true);
            Class1.iterativematrixMultiplication(A, B, C);
            Class1.enableDebug(false);
            CollectionAssert.AreEqual(expected, C);
        }



        [TestMethod]
        public void multiplyMatrixIterativeTestMethod2()
        {

            int[,] A = {{ 1, 2, 3, 4 },
                         { 5, 6, 7, 8 },
                         { 1, 2, 3, 4 },
                         { 5, 6, 7, 8 }};
            Class1.i = 0; Class1.j = 0; Class1.k = 0;
            int N = 4;
            int[,] B = { { 1, 2, 3, 4 },
                         { 5, 6, 7, 8 },
                         { 1, 2, 3, 4 },
                         { 5, 6, 7, 8 }};

            int[,] C = new int[N, N];

            int[,] expected = { { 34,44,54,64 },
                                { 82,108,134,160},
                                { 34,44,54,64 },
                                { 82,108,134,160} };
            Class1.enableDebug(true);
            Class1.iterativematrixMultiplication(A, B, C);
            Class1.enableDebug(false);
            CollectionAssert.AreEqual(expected, C);
        }



        [TestMethod]
        public void multiplyMatrixIterativeTestMethod3()
        {

            int[,] A = {{ 10,11,12,13},
                         { 13,14,15,16},
                         { 16,17,18,19},
                         { 20,21,22,23} };
            Class1.i = 0; Class1.j = 0; Class1.k = 0;
            int N = 4;
            int[,] B = { { 10,11,12,13},
                         { 13,14,15,16},
                         { 16,17,18,19},
                         {20,21,22,23 } };

            int[,] C = new int[N, N];

            int[,] expected = { { 695,741,787,833 },
                                { 872,930,988,1046},
                                { 1049,1119,1189,1259 },
                                { 1285,1371,1457,1543} };
            Class1.enableDebug(true);
            Class1.iterativematrixMultiplication(A, B, C);
            Class1.enableDebug(false);
            CollectionAssert.AreEqual(expected, C);
        }






        [TestMethod]
        public void MatrixMulStrTest2()
        {
            float[,] array = { { 4, 3 },
                           { 1, 5 } };


            float[,] array2 = { { 6, 2 },
                            { 7, 0 } };

            float[,] result = { { 45, 8 },
                            { 41, 2 } };

            Class1.enableDebug(true);
            float[,] exp = Class1.strassen(array, array2, 2);
            Class1.enableDebug(false);
            CollectionAssert.AreEqual(exp, result);
        }

        [TestMethod]
        public void MatrixMulStrTest3()
        {
            float[,] array = { { 5, 3 },
                           { 9, 6 } };


            float[,] array2 = { { 1, 0 },
                            { 5, 7 } };

            float[,] result = { { 20, 21 },
                            { 39, 42 } };

            Class1.enableDebug(true);
            float[,] exp = Class1.strassen(array, array2, 2);
            Class1.enableDebug(false);
            CollectionAssert.AreEqual(exp, result);
        }

    }
}







