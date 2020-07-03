using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Translator;

namespace TranslatorTest1
{
    /// <summary>
    /// Unit test of the FindFirstRow method. The purpose of the test is to determine the correctness of the method. 
    /// The method aims to find the keyword in the data. The data is in the form of an array string.
    /// 
    /// The row addition function is one of the system functions, therefore it was suspended during testing.
    /// </summary>
    [TestClass]
    public class UnitTestFindFirstRow
    {
        private CsvDataHandling csvDataHandling = new CsvDataHandling();
        [TestMethod]
        public void FindFirstRowTest()
        {
            // arrange
            string[] columns = new string[10];
            bool expected = false;
            columns[0] = "powinny";
            columns[1] = "All";
            columns[2] = "1";
            columns[3] = "testów";
            columns[4] = "jaki";
            columns[5] = "Langu_ge";
            columns[6] = "repo";
            columns[7] = "unit";
            columns[8] = "Data base";
            columns[9] = "!";

            // act
            bool rowFound = csvDataHandling.FindFirstRowTest(columns);

            // assert
            Assert.AreEqual(expected, rowFound, "First valid row not find correctly");

        }

    }
}
