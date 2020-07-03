using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Translator
{
    /// <summary>
    /// 
    /// </summary>
    public class ModelFacade
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly SqliteDataAccess sqliteDataAccess = new SqliteDataAccess();
        private CsvDataHandling csvDataHandling = new CsvDataHandling();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
        public void InitDataGridView(DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                if (i < 4)
                {
                    dataGridView.Columns[i].Visible = false;
                }
                else
                {
                    dataGridView.Columns[i].Visible = true;
                }
            }
            dataGridView.Columns[4].HeaderCell.Value = "PrimaryLanguage";
            dataGridView.Columns[5].HeaderCell.Value = "Language1";
            dataGridView.Columns[6].HeaderCell.Value = "Language2";
            dataGridView.Columns[7].HeaderCell.Value = "Language3";
            dataGridView.Columns[8].HeaderCell.Value = "Language4";
            dataGridView.Columns[9].HeaderCell.Value = "Language5";
            dataGridView.Columns[10].HeaderCell.Value = "Language6";
            dataGridView.Columns[11].HeaderCell.Value = "Language7";
            dataGridView.Columns[12].HeaderCell.Value = "Language8";
            dataGridView.Columns[13].HeaderCell.Value = "Language9";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
        public void InitHeadersGridView(DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                int languageCode = sqliteDataAccess.GetLanguageCode(dataGridView.Columns[i].HeaderCell.Value.ToString());
                if (languageCode != 0)
                {
                    dataGridView.Columns[i].HeaderCell.Value = sqliteDataAccess.GetLanguageName(languageCode);
                }
                if (dataGridView.Columns[i].HeaderCell.Value.ToString().Contains("Language"))
                {
                    dataGridView.Columns[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
        public void InitializeDataGridView(DataGridView dataGridView)
        {
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = true;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView.EditMode = DataGridViewEditMode.EditOnKeystroke;
            dataGridView.ShowEditingIcon = false;
            dataGridView.TabIndex = 0;
            dataGridView.RowHeadersDefaultCellStyle.Padding = new Padding(3);
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dataGridView.RowHeadersDefaultCellStyle.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            dataGridView.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.RowHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dataGridView.AutoResizeColumns();
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.Gray;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public OpenFileDialog OpenFileDialogMultiselect()
        {
            var openFileDialog = new OpenFileDialog();
            // Set the file dialog to filter for csv files.
            openFileDialog.Filter =
                "Text (*.CSV)|*.CSV|" +
                "All files (*.*)|*.*";
            // Allow the user to select multiple files.
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Import .csv files";
            return openFileDialog;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="listText"></param>
        public void ShowTextListOnDGV(DataGridView dataGridView, List<TextModel> listText)
        {
            listText = sqliteDataAccess.GetTextTableAll();
            dataGridView.DataSource = listText;
            InitHeadersGridView(dataGridView);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
        public void SaveDGVToDB(DataGridView dataGridView)
        {
            DataTable dataTable = new CsvDataHandling().GetDataTableFromDataGrid(dataGridView);
            sqliteDataAccess.UpdateSingleText(dataTable);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
        public void ClearTextFromDB(DataGridView dataGridView)
        {
            sqliteDataAccess.ClearTextTable();
            InitDataGridView(dataGridView);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearFileFromDB()
        {
            sqliteDataAccess.ClearFileTable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="listText"></param>
        /// <param name="listFile"></param>
        public void SaveTextToDB(DataGridView dataGridView, List<TextModel> listText, List<FileModel> listFile)
        {
            listFile = sqliteDataAccess.GetFileTableAll();

            foreach (FileModel file in listFile)
            {
                int numRow = 0;
                DataTable dataTable = new DataTable();
                dataTable = new CsvDataHandling().GetDataTableFromCsvFile(file.FullPath);

                foreach (DataRow row in dataTable.Rows)
                {
                    TextModel text = new TextModel();
                    text.IdFile = sqliteDataAccess.GetFileId(file.Path, file.Name);
                    text.RowNum = numRow;
                    text.ColumnName = row.ItemArray[0].ToString();
                    text.PrimaryLanguage = row.ItemArray[1].ToString();
                    text.Language1 = row.ItemArray[2].ToString();
                    text.Language2 = row.ItemArray[3].ToString();
                    text.Language3 = row.ItemArray[4].ToString();
                    text.Language4 = row.ItemArray[5].ToString();
                    text.Language5 = row.ItemArray[6].ToString();
                    text.Language6 = row.ItemArray[7].ToString();
                    text.Language7 = row.ItemArray[8].ToString();
                    text.Language8 = row.ItemArray[9].ToString();
                    text.Language9 = row.ItemArray[10].ToString();
                    numRow++;

                    sqliteDataAccess.PutSingleText(text);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SaveTextToCsv()
        {
            List<FileModel> listFile = sqliteDataAccess.GetFileTableAll();
            List<TextModel> listText = new List<TextModel>();
            foreach (FileModel file in listFile)
            {
                listText = sqliteDataAccess.GetTextTableByIdFile(file.IdFile);
                csvDataHandling.PutTextListToCsvFile(file.FullPath, listText);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="openfileDialog"></param>
        public void SelectFiles(OpenFileDialog openfileDialog)
        {
            FileModel fileModel = new FileModel();
            // Read the files
            foreach (string file in openfileDialog.FileNames)
            {
                try
                {
                    fileModel.Path = Path.GetDirectoryName(file);
                    fileModel.Name = Path.GetFileName(file);
                }
                catch (Exception ex)
                {
                    // Could not load the file - probably related to Windows file system permissions.
                    MessageBox.Show("Cannot read the file: " + fileModel.Name
                        + ". You may not have permission to read the file, or " +
                        "it may be corrupt.\n\nReported error: " + ex.Message);
                }
                try
                {
                    sqliteDataAccess.PutSingleFile(fileModel);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot save the file into database " + fileModel.Name + "\n\nReported error: " + ex.Message);
                }
            }
        }
    }
}
