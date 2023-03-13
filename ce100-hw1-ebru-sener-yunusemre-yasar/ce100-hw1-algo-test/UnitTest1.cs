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
    }


}


}




