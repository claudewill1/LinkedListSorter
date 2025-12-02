using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedListSorter.App.Utilities;

namespace LinkedListSorter.Tests
{
    [TestClass]
    public class InputUtilityTests
    {
        private TextReader _originalIn;
        private TextWriter _originalOut;

        [TestInitialize]
        public void Setup()
        {
            _originalIn = Console.In;
            _originalOut = Console.Out;
        }

        [TestCleanup]
        public void Cleanup()
        {
            Console.SetIn(_originalIn);
            Console.SetOut(_originalOut);
        }

        // ---------------------------------------------------------
        // ReadInt
        // ---------------------------------------------------------

        [TestMethod]
        public void ReadInt_ValidInteger_ReturnsParsedValue()
        {
            Console.SetIn(new StringReader("42\n"));

            int result = InputUtility.ReadInt();

            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void ReadInt_InvalidThenValidInput_ReturnsValidValue()
        {
            // First input is invalid, second is valid
            Console.SetIn(new StringReader("abc\n100\n"));

            int result = InputUtility.ReadInt();

            Assert.AreEqual(100, result);
        }

        // ---------------------------------------------------------
        // ReadIntList
        // ---------------------------------------------------------

        [TestMethod]
        public void ReadIntList_SpaceSeparatedValues_ReturnsParsedList()
        {
            Console.SetIn(new StringReader("1 2 3 4 5\n"));

            List<int> result = InputUtility.ReadIntList();

            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5 }, result);
        }

        [TestMethod]
        public void ReadIntList_CommaSeparatedValues_ReturnsParsedList()
        {
            Console.SetIn(new StringReader("10,20,30\n"));

            List<int> result = InputUtility.ReadIntList();

            CollectionAssert.AreEqual(new List<int> { 10, 20, 30 }, result);
        }

        [TestMethod]
        public void ReadIntList_MixedSeparators_IgnoresInvalidTokens()
        {
            Console.SetIn(new StringReader("1, 2 three 4\n"));

            List<int> result = InputUtility.ReadIntList();

            CollectionAssert.AreEqual(new List<int> { 1, 2, 4 }, result);
        }

        // ---------------------------------------------------------
        // ReadMenuChoice
        // ---------------------------------------------------------

        [TestMethod]
        public void ReadMenuChoice_ValidChoiceFirstTime_ReturnsChoice()
        {
            var validOptions = new HashSet<char> { 'a', 'b', 'c' };
            Console.SetIn(new StringReader("b\n"));

            char choice = InputUtility.ReadMenuChoice(validOptions);

            Assert.AreEqual('b', choice);
        }

        [TestMethod]
        public void ReadMenuChoice_InvalidThenValidChoice_ReturnsValidChoice()
        {
            var validOptions = new HashSet<char> { 'x', 'y', 'z' };
            Console.SetIn(new StringReader("q\nz\n"));

            char choice = InputUtility.ReadMenuChoice(validOptions);

            Assert.AreEqual('z', choice);
        }

        // ---------------------------------------------------------
        // ReadYesNo
        // ---------------------------------------------------------

        [TestMethod]
        public void ReadYesNo_Y_ReturnsTrue()
        {
            Console.SetIn(new StringReader("y\n"));

            bool result = InputUtility.ReadYesNo();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ReadYesNo_N_ReturnsFalse()
        {
            Console.SetIn(new StringReader("n\n"));

            bool result = InputUtility.ReadYesNo();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReadYesNo_InvalidThenY_ReturnsTrue()
        {
            Console.SetIn(new StringReader("maybe\nY\n"));

            bool result = InputUtility.ReadYesNo();

            Assert.IsTrue(result);
        }

        // ---------------------------------------------------------
        // PrintBanner
        // ---------------------------------------------------------

        [TestMethod]
        public void PrintBanner_WritesTitleToOutput()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);

            InputUtility.PrintBanner("LinkedList Sorter");

            string output = writer.ToString();

            StringAssert.Contains(output, "LinkedList Sorter");
        }

        // ---------------------------------------------------------
        // PromptInt
        // ---------------------------------------------------------

        [TestMethod]
        public void PromptInt_DisplaysPromptAndReadsInt()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            Console.SetIn(new StringReader("123\n"));

            int result = InputUtility.PromptInt("Enter a number:");

            string output = writer.ToString();

            StringAssert.Contains(output, "Enter a number:");
            Assert.AreEqual(123, result);
        }

        // ---------------------------------------------------------
        // PromptMenuChoice
        // ---------------------------------------------------------

        [TestMethod]
        public void PromptMenuChoice_DisplaysPromptAndReadsChoice()
        {
            var validOptions = new HashSet<char> { 'a', 'b' };
            var writer = new StringWriter();
            Console.SetOut(writer);
            Console.SetIn(new StringReader("b\n"));

            char choice = InputUtility.PromptMenuChoice("Choose option:", validOptions);

            string output = writer.ToString();

            StringAssert.Contains(output, "Choose option:");
            Assert.AreEqual('b', choice);
        }

        // ---------------------------------------------------------
        // PromptIntList
        // ---------------------------------------------------------

        [TestMethod]
        public void PromptIntList_DisplaysPromptAndReadsList()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            Console.SetIn(new StringReader("1 2 3\n"));

            List<int> result = InputUtility.PromptIntList("Enter values:");

            string output = writer.ToString();

            StringAssert.Contains(output, "Enter values:");
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3 }, result);
        }
    }
}
