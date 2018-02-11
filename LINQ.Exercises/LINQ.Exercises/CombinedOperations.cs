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
        [Ignore]
        public void GetCharactersCommonToEveryonesFirstNamesUsingSetElements_ReturnCharEnumerable()
        {
            // ReSharper disable CollectionNeverUpdated.Local
            var commonCharacters = new List<char>(); // please edit/complete so that the test passes
            // ReSharper restore CollectionNeverUpdated.Local

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
        [Ignore]
        public void GetCharactersCommonToEveryonesFirstNamesNotUsingSetOperations_ReturnCharEnumerable()
        {
            IEnumerable<char> result = new List<char>();

            Assert.IsTrue(result.OrderBy(x => x).SequenceEqual(new[] { 'a', 'i', 'J' }.OrderBy(x => x)));
        }

    }
}
