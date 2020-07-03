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
    internal class SqliteDataAccess
    {
        /// <summary>
        /// A method that reads a pre-configured global database access path.
        /// </summary>
        /// <param name="id">ID numer of connection string.</param>
        /// <returns></returns>
        private string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="IdFile"></param>
        /// <returns></returns>
        public List<TextModel> GetTextTableByIdFile(int IdFile)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<TextModel>("select * from TextTable where IdFile = '" + IdFile + "' ORDER BY RowNum ASC", new DynamicParameters());
                return output.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<FileModel> GetFileTableAll()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<FileModel>("select * from FileTable");
                return output.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetFileId(string path, string name)
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
        /// 
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
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
                        if (columnName.Equals("PrimaryLanguage") && text.PrimaryLanguage != null && text.PrimaryLanguage != "")
                        {
                            return Int32.Parse(text.PrimaryLanguage);
                        }
                        if (columnName.Equals("Language1") && text.Language1 != null && text.Language1 != "")
                        {
                            return Int32.Parse(text.Language1);
                        }
                        if (columnName.Equals("Language2") && text.Language2 != null && text.Language2 != "")
                        {
                            return Int32.Parse(text.Language2);
                        }
                        if (columnName.Equals("Language3") && text.Language3 != null && text.Language3 != "")
                        {
                            return Int32.Parse(text.Language3);
                        }
                        if (columnName.Equals("Language4") && text.Language4 != null && text.Language4 != "")
                        {
                            return Int32.Parse(text.Language4);
                        }
                        if (columnName.Equals("Language5") && text.Language5 != null && text.Language5 != "")
                        {
                            return Int32.Parse(text.Language5);
                        }
                        if (columnName.Equals("Language6") && text.Language6 != null && text.Language6 != "")
                        {
                            return Int32.Parse(text.Language6);
                        }
                        if (columnName.Equals("Language7") && text.Language7 != null && text.Language7 != "")
                        {
                            return Int32.Parse(text.Language7);
                        }
                        if (columnName.Equals("Language8") && text.Language8 != null && text.Language8 != "")
                        {
                            return Int32.Parse(text.Language8);
                        }
                        if (columnName.Equals("Language9") && text.Language2 != null && text.Language9 != "")
                        {
                            return Int32.Parse(text.Language9);
                        }
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        public void ClearTextTable()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<TextModel>("delete from TextTable");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearFileTable()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<TextModel>("delete from FileTable");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="translation"></param>
        public void PutSingleFile(FileModel translation)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into FileTable (Path, Name) values (@Path,@Name)", translation);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="translation"></param>
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
        /// 
        /// </summary>
        /// <param name="table"></param>
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
                        cnn.Execute("update TextTable SET " +
                        "PrimaryLanguage= '" + translation.PrimaryLanguage +
                        "' WHERE IdText= '" + translation.IdText + "'");

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

