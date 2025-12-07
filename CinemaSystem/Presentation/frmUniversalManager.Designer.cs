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
            ibtnUpdate = new FontAwesome.Sharp.IconButton();
            ibtnDelete = new FontAwesome.Sharp.IconButton();
            ibtnReturn = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // cmbTablas
            // 
            cmbTablas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTablas.FormattingEnabled = true;
            cmbTablas.Location = new Point(68, 104);
            cmbTablas.Name = "cmbTablas";
            cmbTablas.Size = new Size(182, 33);
            cmbTablas.TabIndex = 1;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.FromArgb(128, 128, 255);
            btnLoad.Font = new Font("Yu Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLoad.Location = new Point(68, 163);
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
            dgvData.Location = new Point(323, 104);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersWidth = 62;
            dgvData.Size = new Size(863, 488);
            dgvData.TabIndex = 6;
            // 
            // ibtnSave
            // 
            ibtnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            ibtnSave.IconColor = Color.Black;
            ibtnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnSave.Location = new Point(79, 423);
            ibtnSave.Name = "ibtnSave";
            ibtnSave.Size = new Size(53, 59);
            ibtnSave.TabIndex = 22;
            ibtnSave.UseVisualStyleBackColor = true;
            ibtnSave.Click += ibtnSave_Click;
            // 
            // ibtnUpdate
            // 
            ibtnUpdate.IconChar = FontAwesome.Sharp.IconChar.Pen;
            ibtnUpdate.IconColor = Color.Black;
            ibtnUpdate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnUpdate.Location = new Point(138, 423);
            ibtnUpdate.Name = "ibtnUpdate";
            ibtnUpdate.Size = new Size(53, 59);
            ibtnUpdate.TabIndex = 23;
            ibtnUpdate.UseVisualStyleBackColor = true;
            // 
            // ibtnDelete
            // 
            ibtnDelete.IconChar = FontAwesome.Sharp.IconChar.Trash;
            ibtnDelete.IconColor = Color.Black;
            ibtnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnDelete.Location = new Point(197, 423);
            ibtnDelete.Name = "ibtnDelete";
            ibtnDelete.Size = new Size(53, 59);
            ibtnDelete.TabIndex = 24;
            ibtnDelete.UseVisualStyleBackColor = true;
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
            // frmUniversalManager
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1230, 618);
            Controls.Add(ibtnReturn);
            Controls.Add(ibtnDelete);
            Controls.Add(ibtnUpdate);
            Controls.Add(ibtnSave);
            Controls.Add(dgvData);
            Controls.Add(btnLoad);
            Controls.Add(cmbTablas);
            Name = "frmUniversalManager";
            Text = "frmUniversalManager";
            Load += frmUniversalManager_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbTablas;
        private Button btnLoad;
        private DataGridView dgvData;
        private FontAwesome.Sharp.IconButton ibtnSave;
        private FontAwesome.Sharp.IconButton ibtnUpdate;
        private FontAwesome.Sharp.IconButton ibtnDelete;
        private FontAwesome.Sharp.IconButton ibtnReturn;
    }
}