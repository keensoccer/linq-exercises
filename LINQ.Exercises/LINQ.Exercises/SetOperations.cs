using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.Exercises
{
    /// <summary>
    /// Your task is to apply LINQ `Distinct/Union/Intersect/Except/OrderBy` methods,
    /// so all tests will be passed.
    /// Make sure to preview test data located in TestData.cs file.
    /// Don't modify assertions or test data, all you need to do is to apply LINQ method so `result`
    /// variable will have expected value(s).
    /// Errata: please post an issue on github.
    /// Look here for a primer: https://code.msdn.microsoft.com/LINQ-Set-Operators-374f34fe
    /// But even better is to start at the MSDN pages for the above methods
    /// </summary>

    [TestClass]
    public class SetOperations
    {
        // I want to see an enumerable which contains only the unique numbers in the
        // above array

        [TestMethod]
        [TestCategory("160-SetOperations")]
        public void GetDistinctNumbers_ReturnIEnumerable()
        {
            int[] randomNumbers = { 2, 2, 3, 5, 5, 2, 3, 4, 6, 4, 3, 8, 7, 5, 9, 4, 6, 3, 6, 34, 2, 2, 5, 7, 5, 4, 2, 6, 67, 5 };

            #region nonLinqSolution
            /*
            var result = new List<int>();

            foreach (var num in randomNumbers)
            {
                if (result.Contains(num)){}
                else
                {
                    result.Add(num);
                }
            }
            */
            #endregion 

            IEnumerable<int> result = randomNumbers.Distinct();

            Assert.IsTrue(result.SequenceEqual(new[] { 2, 3, 5, 4, 6, 8, 7, 9, 34, 67 }));
        }

        // get the unique numbers
        // from both arrays combined
        // in ascending order from 1...9
        [TestMethod]
        [TestCategory("160-SetOperations")]
        public void GetUniqueNumbersFromTwoArraysInAscendingOrder_ReturnEnumerable()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            // ReSharper disable UnusedVariable
            int[] numbersB = { 1, 3, 5, 7, 8 };
            // ReSharper restore UnusedVariable

            #region nonLinqSolution
            /*
            var combNumList = new List<int>();

            foreach (var num in numbersA)
            {
                if (combNumList.Contains(num)) { }
                else combNumList.Add(num);
            }

            foreach (var num in numbersB)
            {
                if (combNumList.Contains(num)) { }
                else combNumList.Add(num); 
            }

            var result = combNumList.OrderBy(n => n);
            */
            #endregion

            IEnumerable<int> result = numbersA.Union(numbersB).OrderBy(n => n);

            Assert.IsTrue(result.SequenceEqual(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
        }

        [TestMethod]
        [TestCategory("160-SetOperations")]
        public void GetCommonValuesSharedByBothArrays_ReturnEnumerable()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            // ReSharper disable UnusedVariable
            int[] numbersB = { 1, 3, 5, 7, 8 };
            // ReSharper restore UnusedVariable

            IEnumerable<int> result = numbersA.Intersect(numbersB);

            Assert.IsTrue(result.SequenceEqual(new[] { 5, 8 }));
        }

        [TestMethod]
        [TestCategory("160-SetOperations")]
        public void GetNumbersInFirstArrayThatAreNotAlsoInSecondArray_ReturnIenumerableInt()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            // ReSharper disable UnusedVariable
            int[] numbersB = { 1, 3, 5, 7, 8 };
            // ReSharper restore UnusedVariable

            IEnumerable<int> result = numbersA.Except(numbersB);

            Assert.IsTrue(result.OrderBy(x => x).SequenceEqual(new[] { 0, 2, 4, 6, 9 }.OrderBy(x => x)));
        }

        [TestMethod]
        [TestCategory("160-SetOperations")]
        public void GetStringsInFirstArrayThatAreNotAlsoInSecondArray_ReturnIenumerableString()
        {
            string[] lettersA = { "a", "b", "c", "d", "e" };
            // ReSharper disable UnusedVariable
            string[] lettersB = { "a", "c", "e" };
            // ReSharper restore UnusedVariable

            IEnumerable<string> result = lettersA.Except(lettersB);

            Assert.IsTrue(result.OrderBy(x => x).SequenceEqual(new[] { "b", "d" }));
        }
    }
}