using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ce100_hw1_algo_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            public void SelectionSort1()
            {
                // Arrange
                int arrayLength = 10000;
                int[] numArray = Enumerable.Range(1, arrayLength).ToArray();

                // Act
                int[] sortedArray = Class1.SelectionSort(numArray, arrayLength);

                // Assert
                for (int i = 0; i < arrayLength; i++)
                {
                    Assert.AreEqual(i + 1, sortedArray[i]);
                }
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                stopwatch.Stop();
                Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");

                long memoryUsed = GC.GetTotalMemory(true);
                Console.WriteLine($"Memory used: {memoryUsed}");
            }

            [TestMethod]
            public void SelectionSort2()
            {
                // Arrange
                int[] inputArray = new int[10000];
                Random random = new Random();

                for (int i = 0; i < inputArray.Length; i++)
                {
                    inputArray[i] = random.Next();
                }

                int[] expectedArray = new int[inputArray.Length];
                Array.Copy(inputArray, expectedArray, inputArray.Length);
                Array.Sort(expectedArray);

                // Act
                int[] sortedArray = Class1.SelectionSort(inputArray, inputArray.Length);

                // Assert
                CollectionAssert.AreEqual(expectedArray, sortedArray);

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                stopwatch.Stop();
                Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");

                long memoryUsed = GC.GetTotalMemory(true);
                Console.WriteLine($"Memory used: {memoryUsed}");
            }

            public void SelectionSort_3()
            {
                //Arrange
                int[] numArray = new int[10000];
                for (int i = 0; i < numArray.Length; i++)
                {
                    numArray[i] = 10000 - i;
                }

                //Act
                var result = Class1.SelectionSort(numArray, numArray.Length);

                //Assert
                for (int i = 0; i < numArray.Length - 1; i++)
                {
                    Assert.IsTrue(result[i] <= result[i + 1]);
                }
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                stopwatch.Stop();
                Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");

                long memoryUsed = GC.GetTotalMemory(true);
                Console.WriteLine($"Memory used: {memoryUsed}");
            }

        }
    }
}
