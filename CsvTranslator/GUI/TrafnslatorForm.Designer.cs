namespace CsvTranslator
{
    partial class TrafnslatorForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.TranslatorHeader = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.logo = new System.Windows.Forms.Button();
            this.btnSaveBackToCsv = new System.Windows.Forms.Button();
            this.btnImportNewFiles = new System.Windows.Forms.Button();
            this.btnClearTable = new System.Windows.Forms.Button();
            this.btnSaveProgress = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 86);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.Size = new System.Drawing.Size(1061, 397);
            this.dataGridView.TabIndex = 23;
            // 
            // TranslatorHeader
            // 
            this.TranslatorHeader.AutoSize = true;
            this.TranslatorHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TranslatorHeader.Location = new System.Drawing.Point(192, 22);
            this.TranslatorHeader.Name = "TranslatorHeader";
            this.TranslatorHeader.Size = new System.Drawing.Size(735, 39);
            this.TranslatorHeader.TabIndex = 22;
            this.TranslatorHeader.Text = "Conditions files translator for .csv extension";
            this.TranslatorHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // logo
            // 
            this.logo.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.logo.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.logo.FlatAppearance.BorderSize = 0;
            this.logo.Image = global::CsvTranslator.Properties.Resources.icons_translate64;
            this.logo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.logo.Location = new System.Drawing.Point(12, 10);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(70, 70);
            this.logo.TabIndex = 28;
            this.toolTip1.SetToolTip(this.logo, "Conditions file translator by PK");
            this.logo.UseVisualStyleBackColor = false;
            // 
            // btnSaveBackToCsv
            // 
            this.btnSaveBackToCsv.Image = global::CsvTranslator.Properties.Resources.icons_savecsv;
            this.btnSaveBackToCsv.Location = new System.Drawing.Point(280, 500);
            this.btnSaveBackToCsv.Name = "btnSaveBackToCsv";
            this.btnSaveBackToCsv.Size = new System.Drawing.Size(100, 100);
            this.btnSaveBackToCsv.TabIndex = 27;
            this.toolTip1.SetToolTip(this.btnSaveBackToCsv, "Save back .csv files");
            this.btnSaveBackToCsv.UseVisualStyleBackColor = true;
            this.btnSaveBackToCsv.Click += new System.EventHandler(this.btnSaveBackToCsv_Click);
            // 
            // btnImportNewFiles
            // 
            this.btnImportNewFiles.Image = global::CsvTranslator.Properties.Resources.icons_openedfolder;
            this.btnImportNewFiles.Location = new System.Drawing.Point(12, 500);
            this.btnImportNewFiles.Name = "btnImportNewFiles";
            this.btnImportNewFiles.Size = new System.Drawing.Size(100, 100);
            this.btnImportNewFiles.TabIndex = 26;
            this.toolTip1.SetToolTip(this.btnImportNewFiles, "Import new .csv files");
            this.btnImportNewFiles.UseVisualStyleBackColor = true;
            this.btnImportNewFiles.Click += new System.EventHandler(this.btnImportNewFile_Click);
            // 
            // btnClearTable
            // 
            this.btnClearTable.Image = global::CsvTranslator.Properties.Resources.icons_csvfile_;
            this.btnClearTable.Location = new System.Drawing.Point(973, 500);
            this.btnClearTable.Name = "btnClearTable";
            this.btnClearTable.Size = new System.Drawing.Size(100, 100);
            this.btnClearTable.TabIndex = 25;
            this.toolTip1.SetToolTip(this.btnClearTable, "Clear table");
            this.btnClearTable.UseVisualStyleBackColor = true;
            this.btnClearTable.Click += new System.EventHandler(this.btnClearTable_Click);
            // 
            // btnSaveProgress
            // 
            this.btnSaveProgress.Image = global::CsvTranslator.Properties.Resources.icons_saveproggress;
            this.btnSaveProgress.Location = new System.Drawing.Point(145, 500);
            this.btnSaveProgress.Name = "btnSaveProgress";
            this.btnSaveProgress.Size = new System.Drawing.Size(100, 100);
            this.btnSaveProgress.TabIndex = 24;
            this.toolTip1.SetToolTip(this.btnSaveProgress, "Save progress");
            this.btnSaveProgress.UseVisualStyleBackColor = true;
            this.btnSaveProgress.Click += new System.EventHandler(this.btnSaveProgress_Click);
            // 
            // TrafnslatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1084, 611);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.TranslatorHeader);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.btnSaveBackToCsv);
            this.Controls.Add(this.btnImportNewFiles);
            this.Controls.Add(this.btnClearTable);
            this.Controls.Add(this.btnSaveProgress);
            this.Name = "TrafnslatorForm";
            this.Text = "CSV translator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label TranslatorHeader;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button logo;
        private System.Windows.Forms.Button btnSaveBackToCsv;
        private System.Windows.Forms.Button btnImportNewFiles;
        private System.Windows.Forms.Button btnClearTable;
        private System.Windows.Forms.Button btnSaveProgress;
    }
}

