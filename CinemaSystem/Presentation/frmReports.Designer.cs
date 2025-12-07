namespace CinemaSystem.Presentation
{
    partial class frmReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbReportes = new ComboBox();
            btnGenerar = new Button();
            dgvReportes = new DataGridView();
            ibtnExportCsv = new FontAwesome.Sharp.IconButton();
            ibtnReturn = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dgvReportes).BeginInit();
            SuspendLayout();
            // 
            // cmbReportes
            // 
            cmbReportes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportes.FormattingEnabled = true;
            cmbReportes.Location = new Point(153, 109);
            cmbReportes.Name = "cmbReportes";
            cmbReportes.Size = new Size(182, 33);
            cmbReportes.TabIndex = 0;
            // 
            // btnGenerar
            // 
            btnGenerar.BackColor = Color.FromArgb(128, 128, 255);
            btnGenerar.Font = new Font("Yu Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGenerar.Location = new Point(153, 171);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(209, 48);
            btnGenerar.TabIndex = 4;
            btnGenerar.Text = "Generar reportes";
            btnGenerar.UseVisualStyleBackColor = false;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // dgvReportes
            // 
            dgvReportes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReportes.Location = new Point(368, 45);
            dgvReportes.Name = "dgvReportes";
            dgvReportes.RowHeadersWidth = 62;
            dgvReportes.Size = new Size(881, 393);
            dgvReportes.TabIndex = 5;
            // 
            // ibtnExportCsv
            // 
            ibtnExportCsv.IconChar = FontAwesome.Sharp.IconChar.FileCsv;
            ibtnExportCsv.IconColor = Color.Black;
            ibtnExportCsv.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnExportCsv.Location = new Point(368, 444);
            ibtnExportCsv.Name = "ibtnExportCsv";
            ibtnExportCsv.Size = new Size(55, 53);
            ibtnExportCsv.TabIndex = 6;
            ibtnExportCsv.UseVisualStyleBackColor = true;
            ibtnExportCsv.Click += ibtnExportCsv_Click;
            // 
            // ibtnReturn
            // 
            ibtnReturn.BackColor = Color.FromArgb(128, 128, 255);
            ibtnReturn.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            ibtnReturn.IconColor = Color.Black;
            ibtnReturn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnReturn.Location = new Point(12, 12);
            ibtnReturn.Name = "ibtnReturn";
            ibtnReturn.Size = new Size(40, 53);
            ibtnReturn.TabIndex = 28;
            ibtnReturn.UseVisualStyleBackColor = false;
            ibtnReturn.Click += ibtnReturn_Click;
            // 
            // frmReports
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(1261, 621);
            Controls.Add(ibtnReturn);
            Controls.Add(ibtnExportCsv);
            Controls.Add(dgvReportes);
            Controls.Add(btnGenerar);
            Controls.Add(cmbReportes);
            Name = "frmReports";
            Text = "frmReportes";
            Load += frmReports_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReportes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbReportes;
        private Button btnGenerar;
        private DataGridView dgvReportes;
        private FontAwesome.Sharp.IconButton ibtnExportCsv;
        private FontAwesome.Sharp.IconButton ibtnReturn;
    }
}