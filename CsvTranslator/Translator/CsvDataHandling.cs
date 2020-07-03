using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Translator
{
    /// <summary>
    /// This class is designed to handle.csv files
    /// </summary>

    public class CsvDataHandling
    {
        /// <summary>
        ///  HaHAHA
        /// </summary>
        /// <param name="dataGridView">gsg</param>
        /// <param name="ignoreHideColumns"></param>
        /// <returns></returns>
        public DataTable GetDataTableFromDataGrid(DataGridView dataGridView, bool ignoreHideColumns = false)
        {
            try
            {
                if (dataGridView.ColumnCount == 0) return null;
                DataTable dataTable = new DataTable();
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    if (ignoreHideColumns & !column.Visible) continue;
                    if (column.Name == string.Empty) continue;
                    dataTable.Columns.Add(column.Name, column.ValueType);
                    dataTable.Columns[column.Name].Caption = column.HeaderText;
                }
                if (dataTable.Columns.Count == 0) return null;
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    DataRow newRow = dataTable.NewRow();
                    foreach (DataColumn newColumn in dataTable.Columns)
                    {
                        newRow[newColumn.ColumnName] = row.Cells[newColumn.ColumnName].Value;
                    }
                    dataTable.Rows.Add(newRow);
                }
                return dataTable;
            }
            catch { return null; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public DataTable GetDataTableFromCsvFile(string filePath)
        {
            DataTable csvData = new DataTable();
            bool firstRow = false;
            if (File.Exists(filePath))
            {
                try
                {
                    if (filePath.ToUpper().EndsWith(".CSV"))
                    {
                        for (int i = 0; i < 11; i++)
                        {
                            DataColumn emptyColumn = new DataColumn();
                            emptyColumn.AllowDBNull = true;
                            csvData.Columns.Add(emptyColumn);
                        }
                        using (TextFieldParser csvReader = new TextFieldParser(filePath))
                        {
                            csvReader.SetDelimiters(new string[] { "," });

                            while (!csvReader.EndOfData)
                            {
                                //read column  
                                string[] fieldColumns = csvReader.ReadFields();
                                if (firstRow == false)
                                {
                                    foreach (string column in fieldColumns)
                                    {
                                        if (column.Equals("Language"))
                                        {
                                            firstRow = true;
                                            csvData.Rows.Add(fieldColumns);
                                        }
                                    }
                                }
                                else
                                {
                                    csvData.Rows.Add(fieldColumns);
                                    string[] fieldData = csvReader.ReadFields();
                                    if (fieldData != null)
                                    {
                                        for (int i = 0; i < fieldData.Length; i++)
                                        {
                                            if (fieldData[i] == "")
                                            {
                                                fieldData[i] = null;
                                            }
                                        }
                                        csvData.Rows.Add(fieldData);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception " + ex);
                }
            }
            else
            {
                MessageBox.Show("Destination file is not valid. Deleted or used by another application. Check directory: " + filePath);
            }
            return csvData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="listText"></param>
        public void PutTextListToCsvFile(string filePath, List<TextModel> listText)
        {
            if (File.Exists(filePath))
            {
                string[] newLines = new string[listText.Count];
                int rowNumber = 0;
                int languageNumber = 0;

                foreach (TextModel text in listText)
                {
                    ///Count number of conigurated language
                    if (text.RowNum == 0 && languageNumber == 0)
                    {
                        if (text.ColumnName != null && text.ColumnName != "")
                            languageNumber = 1;
                        if (text.PrimaryLanguage != null && text.PrimaryLanguage != "")
                            languageNumber = 2;
                        if (text.Language1 != null && text.Language1 != "")
                            languageNumber = 3;
                        if (text.Language2 != null && text.Language2 != "")
                            languageNumber = 4;
                        if (text.Language3 != null && text.Language3 != "")
                            languageNumber = 5;
                        if (text.Language4 != null && text.Language4 != "")
                            languageNumber = 6;
                        if (text.Language5 != null && text.Language5 != "")
                            languageNumber = 7;
                        if (text.Language6 != null && text.Language6 != "")
                            languageNumber = 8;
                        if (text.Language7 != null && text.Language7 != "")
                            languageNumber = 9;
                        if (text.Language8 != null && text.Language8 != "")
                            languageNumber = 10;
                        if (text.Language9 != null && text.Language9 != "")
                            languageNumber = 11;
                    }
                    if (text.RowNum > 0 && languageNumber != 0)
                    {
                        if (languageNumber >= 1)
                            newLines[rowNumber] = newLines[rowNumber] + text.ColumnName;
                        if (languageNumber >= 2)
                            newLines[rowNumber] = newLines[rowNumber] + "," + text.PrimaryLanguage;
                        if (languageNumber >= 3)
                            newLines[rowNumber] = newLines[rowNumber] + "," + text.Language1;
                        if (languageNumber >= 4)
                            newLines[rowNumber] = newLines[rowNumber] + "," + text.Language2;
                        if (languageNumber >= 5)
                            newLines[rowNumber] = newLines[rowNumber] + "," + text.Language3;
                        if (languageNumber >= 6)
                            newLines[rowNumber] = newLines[rowNumber] + "," + text.Language4;
                        if (languageNumber >= 7)
                            newLines[rowNumber] = newLines[rowNumber] + "," + text.Language5;
                        if (languageNumber >= 8)
                            newLines[rowNumber] = newLines[rowNumber] + "," + text.Language6;
                        if (languageNumber >= 9)
                            newLines[rowNumber] = newLines[rowNumber] + "," + text.Language7;
                        if (languageNumber >= 10)
                            newLines[rowNumber] = newLines[rowNumber] + "," + text.Language8;
                        if (languageNumber >= 11)
                            newLines[rowNumber] = newLines[rowNumber] + "," + text.Language9;
                    }
                    rowNumber++;
                }
                try
                {
                    // Read the old file
                    string[] linesReaded = File.ReadAllLines(filePath);

                    // Write the new file part into the old file
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        bool firstRow = false;
                        int currentRow = 0;
                        int currentLine = 1;
                        string lineToWrite = null;
                        foreach (string line in linesReaded)
                        {
                            if (firstRow)
                            {
                                lineToWrite = newLines[currentRow];

                                if (lineToWrite == null)
                                {
                                    throw new InvalidDataException("Line does not exist in database");
                                }

                                writer.WriteLine(lineToWrite);
                                currentRow++;
                            }
                            else
                            {
                                writer.WriteLine(linesReaded[currentLine - 1]);
                            }
                            if (firstRow == false && line.Contains("Language,") == true)
                            {
                                firstRow = true;
                                currentRow++;
                            }
                            ++currentLine;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception " + ex);
                }
            }
            else
            {
                MessageBox.Show("Destination file is not valid. Deleted or used by another application. Check directory: " + filePath);
            }
        }
    }
}
