namespace CinemaSystem.Presentation
{
    partial class frmUniversalManager
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
            cmbTablas = new ComboBox();
            btnLoad = new Button();
            dgvData = new DataGridView();
            ibtnSave = new FontAwesome.Sharp.IconButton();
            ibtnReturn = new FontAwesome.Sharp.IconButton();
            ibtnDelete = new FontAwesome.Sharp.IconButton();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // cmbTablas
            // 
            cmbTablas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTablas.FormattingEnabled = true;
            cmbTablas.Location = new Point(121, 122);
            cmbTablas.Name = "cmbTablas";
            cmbTablas.Size = new Size(182, 33);
            cmbTablas.TabIndex = 1;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.FromArgb(128, 128, 255);
            btnLoad.Font = new Font("Yu Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLoad.Location = new Point(121, 181);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(182, 48);
            btnLoad.TabIndex = 5;
            btnLoad.Text = "Cargar Tabla";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // dgvData
            // 
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new Point(340, 121);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersWidth = 62;
            dgvData.Size = new Size(865, 444);
            dgvData.TabIndex = 6;
            // 
            // ibtnSave
            // 
            ibtnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            ibtnSave.IconColor = Color.Black;
            ibtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnSave.Location = new Point(121, 248);
            ibtnSave.Name = "ibtnSave";
            ibtnSave.Size = new Size(53, 59);
            ibtnSave.TabIndex = 22;
            ibtnSave.UseVisualStyleBackColor = true;
            ibtnSave.Click += ibtnSave_Click;
            // 
            // ibtnReturn
            // 
            ibtnReturn.BackColor = Color.FromArgb(128, 128, 255);
            ibtnReturn.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            ibtnReturn.IconColor = Color.Black;
            ibtnReturn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnReturn.Location = new Point(24, 23);
            ibtnReturn.Name = "ibtnReturn";
            ibtnReturn.Size = new Size(40, 53);
            ibtnReturn.TabIndex = 28;
            ibtnReturn.UseVisualStyleBackColor = false;
            ibtnReturn.Click += ibtnReturn_Click;
            // 
            // ibtnDelete
            // 
            ibtnDelete.IconChar = FontAwesome.Sharp.IconChar.Trash;
            ibtnDelete.IconColor = Color.Black;
            ibtnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnDelete.Location = new Point(180, 248);
            ibtnDelete.Name = "ibtnDelete";
            ibtnDelete.Size = new Size(53, 59);
            ibtnDelete.TabIndex = 29;
            ibtnDelete.UseVisualStyleBackColor = true;
            ibtnDelete.Click += ibtnDelete_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(27, 124);
            label1.Name = "label1";
            label1.Size = new Size(72, 26);
            label1.TabIndex = 30;
            label1.Text = "Tablas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(118, 50);
            label2.Name = "label2";
            label2.Size = new Size(368, 36);
            label2.TabIndex = 31;
            label2.Text = "Gestión Universal de Datos";
            // 
            // frmUniversalManager
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(1230, 618);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ibtnDelete);
            Controls.Add(ibtnReturn);
            Controls.Add(ibtnSave);
            Controls.Add(dgvData);
            Controls.Add(btnLoad);
            Controls.Add(cmbTablas);
            Name = "frmUniversalManager";
            Text = "frmUniversalManager";
            Load += frmUniversalManager_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbTablas;
        private Button btnLoad;
        private DataGridView dgvData;
        private FontAwesome.Sharp.IconButton ibtnSave;
        private FontAwesome.Sharp.IconButton ibtnReturn;
        private FontAwesome.Sharp.IconButton ibtnDelete;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Label label1;
        private Label label2;
    }
}