using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Translator;

namespace CsvTranslator
{
    /// <summary>
    /// Main Form class. 
    /// Contains all elements and functions of the graphic user interface.
    /// </summary>
    public partial class TrafnslatorForm : Form
    {
        List<TextModel> listText = new List<TextModel>();
        List<FileModel> listFile = new List<FileModel>();
        private ModelFacade GraphicUserInterface = new ModelFacade();

        /// <summary>
        /// GUI initialization method.
        /// </summary>
        public TrafnslatorForm()
        {
            InitializeComponent();
            GraphicUserInterface.ShowTextListOnDGV(dataGridView, listText);
            GraphicUserInterface.InitDataGridView(dataGridView);
            GraphicUserInterface.InitializeDataGridView(dataGridView);
            GraphicUserInterface.InitHeadersGridView(dataGridView);
        }

        /// <summary>
        /// Button "Import .csv files".
        /// This button is used to import by selecting a file or multiple files with the extension .csv.
        /// </summary>
        /// <param name="sender">Reference to the control/object that raised the event.</param>
        /// <param name="e">Event data.</param>
        private void btnImportNewFile_Click(object sender, EventArgs e)
        {
            try
            {
                GraphicUserInterface.ClearTextFromDB(dataGridView);
                var openfileDialog = GraphicUserInterface.OpenFileDialogMultiselect();
                DialogResult dr = openfileDialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    GraphicUserInterface.SelectFiles(openfileDialog);
                }
                GraphicUserInterface.SaveTextToDB(listFile);
                GraphicUserInterface.ShowTextListOnDGV(dataGridView, listText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to select files from selected directory\n\nReported error: " + ex.Message);
            }
        }

        /// <summary>
        /// Button "Save proggress".
        /// This button is used to save the progress of the translation without saving the final version to .csv files. 
        /// After restarting the program, the changes made will be available for re-editing.
        /// </summary>
        /// <param name="sender">Reference to the control/object that raised the event.</param>
        /// <param name="e">Event data.</param>
        private void btnSaveProgress_Click(object sender, EventArgs e)
        {
            try
            {
                GraphicUserInterface.SaveDGVToDB(dataGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save files\n\nReported error: " + ex.Message);
            }
        }

        /// <summary>
        /// Button "Save back to .csv files".
        /// This button is used to save the progress of the translation with saving the final version to .csv files. 
        /// After restarting the program, the changes made will be available for re-editing.
        /// </summary>
        /// <param name="sender">Reference to the control/object that raised the event.</param>
        /// <param name="e">Event data.</param>
        private void btnSaveBackToCsv_Click(object sender, EventArgs e)
        {
            try
            {
                GraphicUserInterface.SaveDGVToDB(dataGridView);
                GraphicUserInterface.SaveTextToCsv();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save .csv file\n\nReported error: " + ex.Message);
            }
        }

        /// <summary>
        /// Button "Clear working table".
        /// This button clears the screen memory contents along with the displayed table.
        /// </summary>
        /// <param name="sender">Reference to the control/object that raised the event.</param>
        /// <param name="e">Event data.</param>
        private void btnClearTable_Click(object sender, EventArgs e)
        {
            try
            {
                GraphicUserInterface.ClearTextFromDB(dataGridView);
                GraphicUserInterface.ShowTextListOnDGV(dataGridView, listText);
                GraphicUserInterface.ClearFileFromDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to clear text from database\n\nReported error: " + ex.Message);
            }
        }
    }
}
