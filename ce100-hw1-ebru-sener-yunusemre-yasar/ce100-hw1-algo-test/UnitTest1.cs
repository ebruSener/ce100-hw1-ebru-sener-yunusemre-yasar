using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
        public void Sort_SortsReverseSortedArrayInAscendingOrder()
        {
            // Arrange
            int[] unsortedArray = GenerateReverseSortedArray(10000);
            int[] expectedArray = GenerateSortedArray(10000);

            // Act
            SelectionSort(unsortedArray);

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
            public void Sort_SortsArrayOf10000DescendingIntegers()
            {
                // Arrange
                int[] unsortedArray = GenerateDescendingArray(10000);
                int[] expectedArray = (int[])unsortedArray.Clone();
                Array.Sort(expectedArray);

                // Act
                MergeSort(unsortedArray);

                // Assert
                CollectionAssert.AreEqual(expectedArray, unsortedArray);
            }

            private int[] GenerateDescendingArray(int size)
            {
                int[] array = new int[size];
                for (int i = 0; i < size; i++)
                {
                    array[i] = size - i;
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

    }
}





