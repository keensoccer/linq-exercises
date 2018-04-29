using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LINQ.Exercises
{
    /// <summary>
    /// These tests require the combination of various linq methods to arrive at a solution.
    /// Hints as to what these methods are will not be given. The student is required to think 
    /// critically above the problem in hand, and to utilise the full gamut of all the methods
    /// available to him or her.
    /// </summary>

    [TestClass]
    public class CombinedOperations
    {
        // we have a list of people
        // we have their first names
        // i need you to find out which letters are common
        // to all the first names

        // Hint: try to use set operations.
        // There are many ways to solve this.
        [TestMethod]
        [TestCategory("900-CombinedOperations")]
        public void GetCharactersCommonToEveryonesFirstNamesUsingSetElements_ReturnCharEnumerable()
        {
            var peoples = TestData.People2;

            var commonCharacters = peoples[0].FirstName.ToCharArray(); 

            for (int i = 1; i < peoples.Count; i++)
            {
                var charArray = peoples[i].FirstName.ToCharArray();
                commonCharacters = charArray.Intersect(commonCharacters).ToArray();
            }

            Assert.IsTrue(commonCharacters.OrderBy(x => x).SequenceEqual(new[] { 'a', 'i', 'J' }.OrderBy(x => x)));
        }

        // Bonus Question
        // we have a list of people
        // we have their first names
        // i need you to find out which letters are common
        // to all the first names names
        // But you are not allowed to use set operations.
        [TestMethod]
        [TestCategory("900-CombinedOperations")]
        public void GetCharactersCommonToEveryonesFirstNamesNotUsingSetOperations_ReturnCharEnumerable()
        {
            var peoples = TestData.People2;

            var commonCharacters = peoples[0].FirstName.ToCharArray().ToList();

            for (int i = 1; i < peoples.Count; i++)
            {
                var charArray = peoples[i].FirstName.ToCharArray().ToList();
                var doRemove = true;
                var removingList = new List<char>();

                foreach (var letter in commonCharacters)
                {
                    foreach (var characters in charArray)
                    {
                        if (letter == characters) { doRemove = false; break; }
                    }
                    if(doRemove)
                    {
                        removingList.Add(letter);
                    }
                    doRemove = true;
                }
                foreach (var letter in removingList)
                {
                    commonCharacters.Remove(letter);
                }
            }

            Assert.IsTrue(commonCharacters.OrderBy(x => x).SequenceEqual(new[] { 'a', 'i', 'J' }.OrderBy(x => x)));
        }

    }
}
