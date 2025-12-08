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
            label1 = new Label();
            panel1 = new Panel();
            ibtnCleanFilter = new FontAwesome.Sharp.IconButton();
            ibtnApplyFilter = new FontAwesome.Sharp.IconButton();
            dtpFin = new DateTimePicker();
            dtpInicio = new DateTimePicker();
            chkFechas = new CheckBox();
            txtFiltro = new TextBox();
            ibtnExportHtml = new FontAwesome.Sharp.IconButton();
            ibtnExportJson = new FontAwesome.Sharp.IconButton();
            ibtnExportXls = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReportes).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbReportes
            // 
            cmbReportes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportes.FormattingEnabled = true;
            cmbReportes.Location = new Point(113, 170);
            cmbReportes.Name = "cmbReportes";
            cmbReportes.Size = new Size(182, 33);
            cmbReportes.TabIndex = 0;
            // 
            // btnGenerar
            // 
            btnGenerar.BackColor = Color.FromArgb(128, 128, 255);
            btnGenerar.Font = new Font("Yu Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGenerar.Location = new Point(113, 221);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(182, 48);
            btnGenerar.TabIndex = 4;
            btnGenerar.Text = "Generar reportes";
            btnGenerar.UseVisualStyleBackColor = false;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // dgvReportes
            // 
            dgvReportes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReportes.Location = new Point(356, 170);
            dgvReportes.Name = "dgvReportes";
            dgvReportes.RowHeadersWidth = 62;
            dgvReportes.Size = new Size(893, 393);
            dgvReportes.TabIndex = 5;
            // 
            // ibtnExportCsv
            // 
            ibtnExportCsv.Font = new Font("Yu Gothic", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ibtnExportCsv.IconChar = FontAwesome.Sharp.IconChar.File;
            ibtnExportCsv.IconColor = Color.Black;
            ibtnExportCsv.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnExportCsv.Location = new Point(34, 287);
            ibtnExportCsv.Name = "ibtnExportCsv";
            ibtnExportCsv.Size = new Size(55, 87);
            ibtnExportCsv.TabIndex = 6;
            ibtnExportCsv.Text = "CSV";
            ibtnExportCsv.TextAlign = ContentAlignment.BottomCenter;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(13, 177);
            label1.Name = "label1";
            label1.Size = new Size(94, 26);
            label1.TabIndex = 29;
            label1.Text = "Reportes";
            // 
            // panel1
            // 
            panel1.Controls.Add(ibtnCleanFilter);
            panel1.Controls.Add(ibtnApplyFilter);
            panel1.Controls.Add(dtpFin);
            panel1.Controls.Add(dtpInicio);
            panel1.Controls.Add(chkFechas);
            panel1.Controls.Add(txtFiltro);
            panel1.Location = new Point(632, 21);
            panel1.Name = "panel1";
            panel1.Size = new Size(617, 134);
            panel1.TabIndex = 30;
            // 
            // ibtnCleanFilter
            // 
            ibtnCleanFilter.IconChar = FontAwesome.Sharp.IconChar.Broom;
            ibtnCleanFilter.IconColor = Color.Black;
            ibtnCleanFilter.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnCleanFilter.Location = new Point(189, 73);
            ibtnCleanFilter.Name = "ibtnCleanFilter";
            ibtnCleanFilter.Size = new Size(55, 53);
            ibtnCleanFilter.TabIndex = 35;
            ibtnCleanFilter.UseVisualStyleBackColor = true;
            ibtnCleanFilter.Click += ibtnCleanFilter_Click;
            // 
            // ibtnApplyFilter
            // 
            ibtnApplyFilter.IconChar = FontAwesome.Sharp.IconChar.Search;
            ibtnApplyFilter.IconColor = Color.Black;
            ibtnApplyFilter.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnApplyFilter.Location = new Point(189, 14);
            ibtnApplyFilter.Name = "ibtnApplyFilter";
            ibtnApplyFilter.Size = new Size(55, 53);
            ibtnApplyFilter.TabIndex = 31;
            ibtnApplyFilter.UseVisualStyleBackColor = true;
            ibtnApplyFilter.Click += ibtnApplyFilter_Click;
            // 
            // dtpFin
            // 
            dtpFin.Format = DateTimePickerFormat.Short;
            dtpFin.Location = new Point(451, 66);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(149, 31);
            dtpFin.TabIndex = 34;
            // 
            // dtpInicio
            // 
            dtpInicio.Format = DateTimePickerFormat.Short;
            dtpInicio.Location = new Point(451, 29);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(149, 31);
            dtpInicio.TabIndex = 33;
            // 
            // chkFechas
            // 
            chkFechas.AutoSize = true;
            chkFechas.Location = new Point(263, 29);
            chkFechas.Name = "chkFechas";
            chkFechas.Size = new Size(173, 29);
            chkFechas.TabIndex = 32;
            chkFechas.Text = "Filtrar por Fechas";
            chkFechas.UseVisualStyleBackColor = true;
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(21, 29);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(153, 31);
            txtFiltro.TabIndex = 31;
            // 
            // ibtnExportHtml
            // 
            ibtnExportHtml.Font = new Font("Yu Gothic", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ibtnExportHtml.IconChar = FontAwesome.Sharp.IconChar.File;
            ibtnExportHtml.IconColor = Color.Black;
            ibtnExportHtml.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnExportHtml.Location = new Point(95, 287);
            ibtnExportHtml.Name = "ibtnExportHtml";
            ibtnExportHtml.Size = new Size(66, 87);
            ibtnExportHtml.TabIndex = 31;
            ibtnExportHtml.Text = "HTML";
            ibtnExportHtml.TextAlign = ContentAlignment.BottomCenter;
            ibtnExportHtml.UseVisualStyleBackColor = true;
            ibtnExportHtml.Click += ibtnExportHtml_Click;
            // 
            // ibtnExportJson
            // 
            ibtnExportJson.Font = new Font("Yu Gothic", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ibtnExportJson.IconChar = FontAwesome.Sharp.IconChar.File;
            ibtnExportJson.IconColor = Color.Black;
            ibtnExportJson.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnExportJson.Location = new Point(167, 287);
            ibtnExportJson.Name = "ibtnExportJson";
            ibtnExportJson.Size = new Size(65, 87);
            ibtnExportJson.TabIndex = 32;
            ibtnExportJson.Text = "JSON";
            ibtnExportJson.TextAlign = ContentAlignment.BottomCenter;
            ibtnExportJson.UseVisualStyleBackColor = true;
            ibtnExportJson.Click += ibtnExportJson_Click;
            // 
            // ibtnExportXls
            // 
            ibtnExportXls.Font = new Font("Yu Gothic", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ibtnExportXls.IconChar = FontAwesome.Sharp.IconChar.File;
            ibtnExportXls.IconColor = Color.Black;
            ibtnExportXls.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnExportXls.Location = new Point(241, 287);
            ibtnExportXls.Name = "ibtnExportXls";
            ibtnExportXls.Size = new Size(55, 87);
            ibtnExportXls.TabIndex = 33;
            ibtnExportXls.Text = "XLS";
            ibtnExportXls.TextAlign = ContentAlignment.BottomCenter;
            ibtnExportXls.UseVisualStyleBackColor = true;
            ibtnExportXls.Click += ibtnExportXls_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(113, 35);
            label2.Name = "label2";
            label2.Size = new Size(132, 36);
            label2.TabIndex = 34;
            label2.Text = "Reportes";
            // 
            // frmReports
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(1261, 664);
            Controls.Add(label2);
            Controls.Add(ibtnExportXls);
            Controls.Add(ibtnExportJson);
            Controls.Add(ibtnExportHtml);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(ibtnReturn);
            Controls.Add(ibtnExportCsv);
            Controls.Add(dgvReportes);
            Controls.Add(btnGenerar);
            Controls.Add(cmbReportes);
            Name = "frmReports";
            Text = "frmReportes";
            Load += frmReports_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReportes).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbReportes;
        private Button btnGenerar;
        private DataGridView dgvReportes;
        private FontAwesome.Sharp.IconButton ibtnExportCsv;
        private FontAwesome.Sharp.IconButton ibtnReturn;
        private Label label1;
        private Panel panel1;
        private TextBox txtFiltro;
        private FontAwesome.Sharp.IconButton ibtnApplyFilter;
        private DateTimePicker dtpFin;
        private DateTimePicker dtpInicio;
        private CheckBox chkFechas;
        private FontAwesome.Sharp.IconButton ibtnCleanFilter;
        private FontAwesome.Sharp.IconButton ibtnExportHtml;
        private FontAwesome.Sharp.IconButton ibtnExportJson;
        private FontAwesome.Sharp.IconButton ibtnExportXls;
        private Label label2;
    }
}