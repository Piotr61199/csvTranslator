using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Translator;

namespace CsvTranslator
{
    public partial class TrafnslatorForm : Form
    {
        List<TextModel> listText = new List<TextModel>();
        List<FileModel> listFile = new List<FileModel>();
        private ModelFacade GraphicUserInterface = new ModelFacade();

        public TrafnslatorForm()
        {
            InitializeComponent();
            GraphicUserInterface.ShowTextListOnDGV(dataGridView, listText);
            GraphicUserInterface.InitDataGridView(dataGridView);
            GraphicUserInterface.InitializeDataGridView(dataGridView);
            GraphicUserInterface.InitHeadersGridView(dataGridView);
        }

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
                GraphicUserInterface.SaveTextToDB(dataGridView, listText, listFile);
                GraphicUserInterface.ShowTextListOnDGV(dataGridView, listText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to select files from selected directory\n\nReported error: " + ex.Message);
            }
        }

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
    }
}
