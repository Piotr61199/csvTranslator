using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Translator;

namespace TranslatorTest2
{
    /// <summary>
    /// Unit test of the FindFirstRow method. The purpose of the test is to determine the correctness of the method. 
    /// The method aims to find the keyword in the data. The data is in the form of an array string.
    /// </summary>
    [TestClass]
    public class UnitTestCountConfigLanguages
    {
        private CsvDataHandling csvDataHandling = new CsvDataHandling();
        [TestMethod]
        public void CounConfigLanguagesTest()
        {
            // arrange
            TextModel text = new TextModel();
            int expected = 6;
            text.IdFile = 151;
            text.IdText = 16555;
            text.RowNum = 0;
            text.ColumnName = "Column 1-1";
            text.PrimaryLanguage = "1033";
            text.Language1 = "1045";
            text.Language2 = "2060";
            text.Language3 = "1032";
            text.Language4 = "4521";
            text.Language5 = "";
            text.Language6 = "";
            text.Language7 = "";
            text.Language8 = "";
            text.Language9 = "";

            // act
            int rowFound = csvDataHandling.CounConfigLanguages(text);

            // assert
            Assert.AreEqual(expected, rowFound, "Languages not counted correctly");

        }
    }
}
