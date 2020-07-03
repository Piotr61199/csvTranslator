using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Translator
{
    /// <summary>
    /// SQL Lite connection class.
    /// The class contains all the necessary methods to communicate with the integrated database.
    /// </summary>
    public class SqliteDataAccess
    {
        /// <summary>
        /// A method that reads a pre-configured global database access path.
        /// </summary>
        /// <param name="id">ID numer of connection string.</param>
        /// <returns>Default connection path</returns>
        private string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        /// <summary>
        /// A method that reads the entire TextTable table from the database and converts it to a list of objects.
        /// </summary>
        /// <returns>List of all text in data base</returns>
        public List<TextModel> GetTextTableAll()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<TextModel>("select * from TextTable where (RowNum is not 0 and PrimaryLanguage is not null) " +
                    "group by PrimaryLanguage order by PrimaryLanguage", new DynamicParameters());
                return output.ToList();
            }
        }

        /// <summary>
        /// The method reads the TextTable table from a database for one document, converts the obtained data into a list of objects.
        /// </summary>
        /// <param name="IdFile">File ID for which texts are searched.</param>
        /// <returns>List containing all text rom one file</returns>
        public List<TextModel> GetTextTableByIdFile(int IdFile)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<TextModel>("select * from TextTable where IdFile = '" + IdFile + "' ORDER BY RowNum ASC", new DynamicParameters());
                return output.ToList();
            }
        }

        /// <summary>
        /// A method that reads the entire FileTable table from the database and converts it to a list of objects.
        /// </summary>
        /// <returns>List of all files in data base</returns>
        public List<FileModel> GetFileTableAll()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<FileModel>("select * from FileTable");
                return output.ToList();
            }
        }

        /// <summary>
        /// A method that returns IdFile based on the file name.
        /// </summary>
        /// <param name="name">The name of the file for which IdFile is searched.</param>
        /// <returns>Number ID of searched file.</returns>
        public int GetFileId(string name)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                List<FileModel> fileList = new List<FileModel>();
                FileModel file = new FileModel();
                var output = cnn.Query<FileModel>("select * from FileTable where Name = '" + name + "'");
                fileList = output.ToList();
                file = fileList.First();
                return file.IdFile;
            }
        }

        /// <summary>
        /// A method that returns language CODE from database. Compares existing columns with values in the database.
        /// </summary>
        /// <param name="columnName">Header of column to compare.</param>
        /// <returns>Code of language used in specific file.</returns>
        public int GetLanguageCode(string columnName)
        {
            if (columnName.Contains("Language"))
            {
                List<TextModel> listText = new List<TextModel>();
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<TextModel>("select * from TextTable where (RowNum is 0 and PrimaryLanguage is not null) ", new DynamicParameters());
                    listText = output.ToList();
                    foreach (TextModel text in listText)
                    {
                        //Find correlation with header
                        bool isNumber = false;
                        int code = 0;
                        isNumber = int.TryParse(text.PrimaryLanguage, out code);
                        if (columnName.Equals("PrimaryLanguage") && isNumber)
                        {
                            return Int32.Parse(text.PrimaryLanguage);
                        }
                        isNumber = int.TryParse(text.Language1, out code);
                        if (columnName.Equals("Language1") && isNumber)
                        {
                            return Int32.Parse(text.Language1);
                        }
                        isNumber = int.TryParse(text.Language2, out code);
                        if (columnName.Equals("Language2") && isNumber)
                        {
                            return Int32.Parse(text.Language2);
                        }
                        isNumber = int.TryParse(text.Language3, out code);
                        if (columnName.Equals("Language3") && isNumber)
                        {
                            return Int32.Parse(text.Language3);
                        }
                        isNumber = int.TryParse(text.Language4, out code);
                        if (columnName.Equals("Language4") && isNumber)
                        {
                            return Int32.Parse(text.Language4);
                        }
                        isNumber = int.TryParse(text.Language5, out code);
                        if (columnName.Equals("Language5") && isNumber)
                        {
                            return Int32.Parse(text.Language5);
                        }
                        isNumber = int.TryParse(text.Language7, out code);
                        if (columnName.Equals("Language6") && isNumber)
                        {
                            return Int32.Parse(text.Language6);
                        }
                        isNumber = int.TryParse(text.Language7, out code);
                        if (columnName.Equals("Language7") && isNumber)
                        {
                            return Int32.Parse(text.Language7);
                        }
                        isNumber = int.TryParse(text.Language8, out code);
                        if (columnName.Equals("Language8") && isNumber)
                        {
                            return Int32.Parse(text.Language8);
                        }
                        isNumber = int.TryParse(text.Language9, out code);
                        if (columnName.Equals("Language9") && isNumber)
                        {
                            return Int32.Parse(text.Language9);
                        }
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// A method that returns language name from database. The code is searched in the database in the LangTable table.
        /// </summary>
        /// <param name="code">Language code to be find.</param>
        /// <returns>Name of language in string format.</returns>
        public string GetLanguageName(int code)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                List<LanguageModel> languageList = new List<LanguageModel>();
                LanguageModel language = new LanguageModel();
                var output = cnn.Query<LanguageModel>("select * from LangTable where Code = '" + code + "'");
                languageList = output.ToList();
                language = languageList.First();

                return language.FullName;
            }
        }

        /// <summary>
        /// TextTable table cleanup method. Deletes the contents of the table in the database.
        /// </summary>
        public void ClearTextTable()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<TextModel>("delete from TextTable");
            }
        }

        /// <summary>
        /// FileTable table cleanup method. Deletes the contents of the table in the database.
        /// </summary>
        public void ClearFileTable()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<TextModel>("delete from FileTable");
            }
        }

        /// <summary>
        /// A method that adds a single record to the database. The record contains information about one .csv file.
        /// </summary>
        /// <param name="translation">Data model saved to the database.</param>
        public void PutSingleFile(FileModel translation)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into FileTable (Path, Name) values (@Path,@Name)", translation);
            }
        }

        /// <summary>
        /// A method that adds a single record to the database. The record contains information about the readed line from the .csv file.
        /// </summary>
        /// <param name="translation">Data model saved to the database.</param>
        public void PutSingleText(TextModel translation)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into TextTable (IdFile, RowNum, ColumnName, PrimaryLanguage, Language1, Language2, " +
                    "Language3, Language4, Language5, Language6, Language7, Language8, Language9) " +
                    "values (@IdFile,@RowNum, @ColumnName, @PrimaryLanguage, @Language1, @Language2, " +
                    "@Language3, @Language4, @Language5, @Language6, @Language7, @Language8, @Language9)", translation);
            }
        }

        /// <summary>
        /// The method saves the user's changes. Changes from the GUI table are saved record by record into the database. 
        /// New values overwrite old ones.
        /// </summary>
        /// <param name="table">Table content from GUI</param>
        public void UpdateSingleText(DataTable table)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                TextModel translation = new TextModel();
                foreach (DataRow row in table.Rows)
                {
                    translation.IdText = Convert.ToInt32(row.ItemArray[0]);
                    translation.PrimaryLanguage = row.ItemArray[4].ToString();
                    translation.Language1 = row.ItemArray[5].ToString();
                    translation.Language2 = row.ItemArray[6].ToString();
                    translation.Language3 = row.ItemArray[7].ToString();
                    translation.Language4 = row.ItemArray[8].ToString();
                    translation.Language5 = row.ItemArray[9].ToString();
                    translation.Language6 = row.ItemArray[10].ToString();
                    translation.Language7 = row.ItemArray[11].ToString();
                    translation.Language8 = row.ItemArray[12].ToString();
                    translation.Language9 = row.ItemArray[13].ToString();

                    if (translation.IdText != 0)
                    {
                        //First update primary language
                        cnn.Execute("update TextTable SET " +
                        "PrimaryLanguage= '" + translation.PrimaryLanguage +
                        "' WHERE IdText= '" + translation.IdText + "'");
                        //When primary language is updated, update rest of table
                        cnn.Execute("update TextTable SET " +
                        "PrimaryLanguage= '" + translation.PrimaryLanguage +
                        "', Language1= '" + translation.Language1 +
                        "', Language2= '" + translation.Language2 +
                        "', Language3= '" + translation.Language3 +
                        "', Language4= '" + translation.Language4 +
                        "', Language5= '" + translation.Language5 +
                        "', Language6= '" + translation.Language6 +
                        "', Language7= '" + translation.Language7 +
                        "', Language8= '" + translation.Language8 +
                        "', Language9= '" + translation.Language9 +
                        "' WHERE (PrimaryLanguage= '" + translation.PrimaryLanguage + "' and PrimaryLanguage is not null)");
                    }
                }
            }
        }
    }
}

