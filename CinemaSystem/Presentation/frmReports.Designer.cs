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
            dgvReportes.Location = new Point(339, 166);
            dgvReportes.Name = "dgvReportes";
            dgvReportes.RowHeadersWidth = 62;
            dgvReportes.Size = new Size(893, 393);
            dgvReportes.TabIndex = 5;
            // 
            // ibtnExportCsv
            // 
            ibtnExportCsv.IconChar = FontAwesome.Sharp.IconChar.FileCsv;
            ibtnExportCsv.IconColor = Color.Black;
            ibtnExportCsv.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnExportCsv.Location = new Point(351, 565);
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
            panel1.Location = new Point(339, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(893, 134);
            panel1.TabIndex = 30;
            // 
            // ibtnCleanFilter
            // 
            ibtnCleanFilter.IconChar = FontAwesome.Sharp.IconChar.Broom;
            ibtnCleanFilter.IconColor = Color.Black;
            ibtnCleanFilter.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnCleanFilter.Location = new Point(301, 73);
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
            ibtnApplyFilter.Location = new Point(301, 14);
            ibtnApplyFilter.Name = "ibtnApplyFilter";
            ibtnApplyFilter.Size = new Size(55, 53);
            ibtnApplyFilter.TabIndex = 31;
            ibtnApplyFilter.UseVisualStyleBackColor = true;
            ibtnApplyFilter.Click += ibtnApplyFilter_Click;
            // 
            // dtpFin
            // 
            dtpFin.Format = DateTimePickerFormat.Short;
            dtpFin.Location = new Point(729, 51);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(149, 31);
            dtpFin.TabIndex = 34;
            // 
            // dtpInicio
            // 
            dtpInicio.Format = DateTimePickerFormat.Short;
            dtpInicio.Location = new Point(729, 14);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(149, 31);
            dtpInicio.TabIndex = 33;
            // 
            // chkFechas
            // 
            chkFechas.AutoSize = true;
            chkFechas.Location = new Point(541, 14);
            chkFechas.Name = "chkFechas";
            chkFechas.Size = new Size(173, 29);
            chkFechas.TabIndex = 32;
            chkFechas.Text = "Filtrar por Fechas";
            chkFechas.UseVisualStyleBackColor = true;
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(133, 29);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(153, 31);
            txtFiltro.TabIndex = 31;
            // 
            // frmReports
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(1261, 621);
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
    }
}