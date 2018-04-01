using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.Exercises
{
    /// <summary>
    /// Your task is to apply LINQ `Where` method, so all tests will be passed.
    /// Make sure to preview test data located in TestData.cs file.
    /// Don't modify assertions or test data, all you need to do is to apply LINQ method so `result` variable will have expected value(s).
    /// </summary>
    [TestClass]
    public class Restriction
    {
        [TestMethod]
        [TestCategory("110-Restriction")]
        public void Where_n_is_greater_than_1_return_3_ints()
        {
            // First test is solved to show you how to use these exercises.
            var result = TestData.Numbers.Where(n => n > 1);

            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        [TestCategory("110-Restriction")]
        public void Where_n_is_less_than_or_equal_to_0_returns_expected_ints()
        {
            var result = TestData.Numbers.Where(n => n <= 0);

            // ReSharper disable PossibleMultipleEnumeration
            Assert.AreEqual(5, result.Count());
            Assert.IsTrue(new[] { -3, -1, -4, -1, -5 }.SequenceEqual(result));
            // ReSharper restore PossibleMultipleEnumeration
        }

        [TestMethod]
        [TestCategory("110-Restriction")]
        public void Where_n_multiplied_by_2_is_greater_than_5()
        {
            var result = TestData.Numbers.Where(n => n * 2 > 5);

            Assert.IsTrue(new[] { 3, 5 }.SequenceEqual(result));
        }

        [TestMethod]
        [TestCategory("110-Restriction")]
        public void Where_n_is_even()
        {
            var result = TestData.Numbers.Where(n => n % 2 == 0);

            Assert.IsTrue(new[] { 2, -4 }.SequenceEqual(result));
        }

        [TestMethod]
        [TestCategory("110-Restriction")]
        public void Where_index_of_n_is_odd()
        {
            var result = TestData.Numbers.Where(n => n >= 0 && n % 2 != 0);

            Assert.IsTrue(new[] { 1, 1, 3, 5 }.SequenceEqual(result));
        }

        [TestMethod]
        [TestCategory("110-Restriction")]
        public void Where_n_is_even_and_n_is_less_than_0()
        {
            var result = TestData.Numbers.Where(n => n < 0 && n % 2 == 0);

            Assert.IsTrue(new[] { -4 }.SequenceEqual(result));
        }

        [TestMethod]
        [TestCategory("110-Restriction")]
        public void Where_n_quare_minus_2_times_n_is_greater_than_n()
        {
            // n * n - 2 * n
            var result = TestData.Numbers.Where(n => n * n - 2 * n > n);

            Assert.IsTrue(new[] { -3, -1, -4, -1, 5, -5 }.SequenceEqual(result));
        }

        [TestMethod]
        [TestCategory("110-Restriction")]
        public void Where_string_length_is_shorter_than_5_letters_returns_1_string()
        {
            IEnumerable<string> result = TestData.Animals.Where(n => n.Length < 5);

            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        [TestCategory("110-Restriction")]
        public void Where_string_length_is_9_returns_expected_strings()
        {
            IEnumerable<string> result = TestData.Animals.Where(n => n.Length == 9);

            Assert.AreEqual(1, result.Count());
            Assert.IsTrue(new[] { "swordfish" }.SequenceEqual(result));
        }

        [TestMethod]
        [TestCategory("110-Restriction")]
        public void Where_string_starts_with_s()
        {
            IEnumerable<string> result = TestData.Animals.Where(n => n.StartsWith("s"));

            Assert.IsTrue(new[] { "swordfish", "shark" }.SequenceEqual(result));
        }

        [TestMethod]
        [TestCategory("110-Restriction")]
        public void Where_string_has_i_as_a_second_letter()
        {
            IEnumerable<string> result = TestData.Animals.Where(n => n.Length > 1 && n[1] == 'i'); 

            Assert.IsTrue(new[] { "tiger", "lion" }.SequenceEqual(result));
        }

        [TestMethod]
        [TestCategory("110-Restriction")]
        public void Where_string_contains_e()
        {
            IEnumerable<string> result = TestData.Animals.Where(n => n.Contains("e")); 

            Assert.IsTrue(new[] { "tiger", "penguin", "elephant" }.SequenceEqual(result));
        }

        [TestMethod]
        [TestCategory("110-Restriction")]
        public void Where_string_ends_with_uppercase_t()
        {
            IEnumerable<string> result = TestData.Animals.Where(n => n.EndsWith("t"));

            Assert.IsTrue(new[] { "elephant" }.SequenceEqual(result));
        }

        [TestMethod]
        [TestCategory("110-Restriction")]
        public void Where_substring_equals_to_io()
        {
            IEnumerable<string> result = TestData.Animals.Where(n => n.Substring(0).Contains("io"));

            Assert.IsTrue(new[] { "lion" }.SequenceEqual(result));
        }

        [TestMethod]
        [TestCategory("110-Restriction")]
        public void Where_person_firstname_and_lastname_starts_with_same_letter()
        {
            IEnumerable<TestData.Person> result = TestData.People.Where(n => n.FirstName.First() == n.LastName.First());

            Assert.IsTrue(new[] { TestData.People[3] }.SequenceEqual(result));
        }

        [TestMethod]
        [TestCategory("110-Restriction")]
        public void Where_person_was_born_before_1990()
        {
            IEnumerable<TestData.Person> result = TestData.People.Where(n => n.Born.Year < 1990);

            Assert.IsTrue(new[] { TestData.People[1], TestData.People[3] }.SequenceEqual(result));
        }

        [TestMethod]
        [TestCategory("110-Restriction")]
        public void Where_person_was_born_on_day_with_even_number()
        {
            IEnumerable<TestData.Person> result = TestData.People.Where(n => n.Born.Day % 2 == 0);

            Assert.IsTrue(new[] { TestData.People[0], TestData.People[3] }.SequenceEqual(result));
        }

        [TestMethod]
        [TestCategory("110-Restriction")]
        public void Where_person_was_born_on_monday_21st()
        {
            IEnumerable<TestData.Person> result = TestData.People.Where(n => n.Born.DayOfWeek == System.DayOfWeek.Monday && n.Born.Day == 21);

            Assert.IsTrue(new[] { TestData.People[2] }.SequenceEqual(result));
        }

        [TestMethod]
        [TestCategory("110-Restriction")]
        public void Where_person_had_18_years_or_more_in_2000()
        {
            IEnumerable<TestData.Person> result = TestData.People.Where(n => n.Born.AddYears(18).Year < 2000);

            Assert.IsTrue(new[] { TestData.People[1], TestData.People[3] }.SequenceEqual(result));
        }

        [TestMethod]
        [TestCategory("110-Restriction")]
        public void Where_person_lastname_contains_ll_and_sum_of_year_month_day_is_greater_than_2000()
        {
            IEnumerable<TestData.Person> result = TestData.People.Where(n => n.LastName.Contains("ll") && n.Born.Year + n.Born.Month + n.Born.Day > 2000);

            Assert.IsTrue(new[] { TestData.People[2] }.SequenceEqual(result));
        }
    }
}