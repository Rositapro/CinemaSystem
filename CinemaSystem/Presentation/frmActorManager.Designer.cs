namespace CinemaSystem.Presentation
{
    partial class frmMainMenu
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
            dgvActores = new DataGridView();
            txtNombre = new TextBox();
            txtApellidoP = new TextBox();
            txtApellidoM = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ibtnCreate = new FontAwesome.Sharp.IconButton();
            ibtnUpdate = new FontAwesome.Sharp.IconButton();
            ibtnDelete = new FontAwesome.Sharp.IconButton();
            txtNacionalidad = new TextBox();
            dtpFechaNac = new DateTimePicker();
            txtId = new TextBox();
            ibtnReturn = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dgvActores).BeginInit();
            SuspendLayout();
            // 
            // dgvActores
            // 
            dgvActores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActores.Location = new Point(368, 112);
            dgvActores.Name = "dgvActores";
            dgvActores.RowHeadersWidth = 62;
            dgvActores.Size = new Size(875, 399);
            dgvActores.TabIndex = 0;
            dgvActores.CellClick += dgvActores_CellClick;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(119, 112);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(181, 31);
            txtNombre.TabIndex = 1;
            // 
            // txtApellidoP
            // 
            txtApellidoP.Location = new Point(119, 159);
            txtApellidoP.Name = "txtApellidoP";
            txtApellidoP.Size = new Size(181, 31);
            txtApellidoP.TabIndex = 2;
            // 
            // txtApellidoM
            // 
            txtApellidoM.Location = new Point(119, 210);
            txtApellidoM.Name = "txtApellidoM";
            txtApellidoM.Size = new Size(181, 31);
            txtApellidoM.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 114);
            label1.Name = "label1";
            label1.Size = new Size(67, 26);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 164);
            label2.Name = "label2";
            label2.Size = new Size(67, 26);
            label2.TabIndex = 5;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 210);
            label3.Name = "label3";
            label3.Size = new Size(67, 26);
            label3.TabIndex = 6;
            label3.Text = "label3";
            // 
            // ibtnCreate
            // 
            ibtnCreate.IconChar = FontAwesome.Sharp.IconChar.Save;
            ibtnCreate.IconColor = Color.Black;
            ibtnCreate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnCreate.Location = new Point(119, 406);
            ibtnCreate.Name = "ibtnCreate";
            ibtnCreate.Size = new Size(53, 59);
            ibtnCreate.TabIndex = 7;
            ibtnCreate.UseVisualStyleBackColor = true;
            ibtnCreate.Click += ibtnCreate_Click;
            // 
            // ibtnUpdate
            // 
            ibtnUpdate.IconChar = FontAwesome.Sharp.IconChar.Pen;
            ibtnUpdate.IconColor = Color.Black;
            ibtnUpdate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnUpdate.Location = new Point(178, 406);
            ibtnUpdate.Name = "ibtnUpdate";
            ibtnUpdate.Size = new Size(53, 59);
            ibtnUpdate.TabIndex = 8;
            ibtnUpdate.UseVisualStyleBackColor = true;
            ibtnUpdate.Click += ibtnUpdate_Click;
            // 
            // ibtnDelete
            // 
            ibtnDelete.IconChar = FontAwesome.Sharp.IconChar.Trash;
            ibtnDelete.IconColor = Color.Black;
            ibtnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnDelete.Location = new Point(237, 406);
            ibtnDelete.Name = "ibtnDelete";
            ibtnDelete.Size = new Size(53, 59);
            ibtnDelete.TabIndex = 9;
            ibtnDelete.UseVisualStyleBackColor = true;
            ibtnDelete.Click += ibtnDelete_Click;
            // 
            // txtNacionalidad
            // 
            txtNacionalidad.Location = new Point(119, 263);
            txtNacionalidad.Name = "txtNacionalidad";
            txtNacionalidad.Size = new Size(181, 31);
            txtNacionalidad.TabIndex = 10;
            // 
            // dtpFechaNac
            // 
            dtpFechaNac.Location = new Point(119, 312);
            dtpFechaNac.Name = "dtpFechaNac";
            dtpFechaNac.Size = new Size(208, 31);
            dtpFechaNac.TabIndex = 11;
            // 
            // txtId
            // 
            txtId.Location = new Point(119, 349);
            txtId.Name = "txtId";
            txtId.Size = new Size(181, 31);
            txtId.TabIndex = 12;
            txtId.Visible = false;
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
            ibtnReturn.TabIndex = 13;
            ibtnReturn.UseVisualStyleBackColor = false;
            ibtnReturn.Click += ibtnReturn_Click;
            // 
            // frmActorManager
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(1273, 643);
            Controls.Add(ibtnReturn);
            Controls.Add(txtId);
            Controls.Add(dtpFechaNac);
            Controls.Add(txtNacionalidad);
            Controls.Add(ibtnDelete);
            Controls.Add(ibtnUpdate);
            Controls.Add(ibtnCreate);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtApellidoM);
            Controls.Add(txtApellidoP);
            Controls.Add(txtNombre);
            Controls.Add(dgvActores);
            Name = "frmActorManager";
            Text = "frmActorManager";
            ((System.ComponentModel.ISupportInitialize)dgvActores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvActores;
        private TextBox txtNombre;
        private TextBox txtApellidoP;
        private TextBox txtApellidoM;
        private Label label1;
        private Label label2;
        private Label label3;
        private FontAwesome.Sharp.IconButton ibtnCreate;
        private FontAwesome.Sharp.IconButton ibtnUpdate;
        private FontAwesome.Sharp.IconButton ibtnDelete;
        private TextBox txtNacionalidad;
        private DateTimePicker dtpFechaNac;
        private TextBox txtId;
        private FontAwesome.Sharp.IconButton ibtnReturn;
    }
}