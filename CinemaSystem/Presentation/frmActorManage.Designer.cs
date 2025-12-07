namespace CinemaSystem.Presentation
{
    partial class frmActorManage
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
            ibtnReturn = new FontAwesome.Sharp.IconButton();
            txtId = new TextBox();
            dtpFechaNac = new DateTimePicker();
            txtNacionalidad = new TextBox();
            ibtnDelete = new FontAwesome.Sharp.IconButton();
            ibtnUpdate = new FontAwesome.Sharp.IconButton();
            ibtnCreate = new FontAwesome.Sharp.IconButton();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtApellidoM = new TextBox();
            txtApellidoP = new TextBox();
            txtNombre = new TextBox();
            dgvActores = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvActores).BeginInit();
            SuspendLayout();
            // 
            // ibtnReturn
            // 
            ibtnReturn.BackColor = Color.FromArgb(128, 128, 255);
            ibtnReturn.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            ibtnReturn.IconColor = Color.Black;
            ibtnReturn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnReturn.Location = new Point(14, 15);
            ibtnReturn.Name = "ibtnReturn";
            ibtnReturn.Size = new Size(40, 53);
            ibtnReturn.TabIndex = 27;
            ibtnReturn.UseVisualStyleBackColor = false;
            ibtnReturn.Click += ibtnReturn_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(121, 352);
            txtId.Name = "txtId";
            txtId.Size = new Size(181, 31);
            txtId.TabIndex = 26;
            txtId.Visible = false;
            // 
            // dtpFechaNac
            // 
            dtpFechaNac.Location = new Point(121, 315);
            dtpFechaNac.Name = "dtpFechaNac";
            dtpFechaNac.Size = new Size(208, 31);
            dtpFechaNac.TabIndex = 25;
            // 
            // txtNacionalidad
            // 
            txtNacionalidad.Location = new Point(121, 266);
            txtNacionalidad.Name = "txtNacionalidad";
            txtNacionalidad.Size = new Size(181, 31);
            txtNacionalidad.TabIndex = 24;
            // 
            // ibtnDelete
            // 
            ibtnDelete.IconChar = FontAwesome.Sharp.IconChar.Trash;
            ibtnDelete.IconColor = Color.Black;
            ibtnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnDelete.Location = new Point(239, 409);
            ibtnDelete.Name = "ibtnDelete";
            ibtnDelete.Size = new Size(53, 59);
            ibtnDelete.TabIndex = 23;
            ibtnDelete.UseVisualStyleBackColor = true;
            ibtnDelete.Click += ibtnDelete_Click;
            // 
            // ibtnUpdate
            // 
            ibtnUpdate.IconChar = FontAwesome.Sharp.IconChar.Pen;
            ibtnUpdate.IconColor = Color.Black;
            ibtnUpdate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnUpdate.Location = new Point(180, 409);
            ibtnUpdate.Name = "ibtnUpdate";
            ibtnUpdate.Size = new Size(53, 59);
            ibtnUpdate.TabIndex = 22;
            ibtnUpdate.UseVisualStyleBackColor = true;
            ibtnUpdate.Click += ibtnUpdate_Click;
            // 
            // ibtnCreate
            // 
            ibtnCreate.IconChar = FontAwesome.Sharp.IconChar.Save;
            ibtnCreate.IconColor = Color.Black;
            ibtnCreate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnCreate.Location = new Point(121, 409);
            ibtnCreate.Name = "ibtnCreate";
            ibtnCreate.Size = new Size(53, 59);
            ibtnCreate.TabIndex = 21;
            ibtnCreate.UseVisualStyleBackColor = true;
            ibtnCreate.Click += ibtnCreate_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(14, 213);
            label3.Name = "label3";
            label3.Size = new Size(67, 26);
            label3.TabIndex = 20;
            label3.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(14, 167);
            label2.Name = "label2";
            label2.Size = new Size(67, 26);
            label2.TabIndex = 19;
            label2.Text = "label2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 117);
            label1.Name = "label1";
            label1.Size = new Size(67, 26);
            label1.TabIndex = 18;
            label1.Text = "label1";
            // 
            // txtApellidoM
            // 
            txtApellidoM.Location = new Point(121, 213);
            txtApellidoM.Name = "txtApellidoM";
            txtApellidoM.Size = new Size(181, 31);
            txtApellidoM.TabIndex = 17;
            // 
            // txtApellidoP
            // 
            txtApellidoP.Location = new Point(121, 162);
            txtApellidoP.Name = "txtApellidoP";
            txtApellidoP.Size = new Size(181, 31);
            txtApellidoP.TabIndex = 16;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(121, 115);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(181, 31);
            txtNombre.TabIndex = 15;
            // 
            // dgvActores
            // 
            dgvActores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActores.Location = new Point(370, 115);
            dgvActores.Name = "dgvActores";
            dgvActores.RowHeadersWidth = 62;
            dgvActores.Size = new Size(875, 399);
            dgvActores.TabIndex = 14;
            dgvActores.CellClick += dgvActores_CellClick;
            // 
            // frmActorManage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(1257, 654);
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
            Name = "frmActorManage";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvActores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton ibtnReturn;
        private TextBox txtId;
        private DateTimePicker dtpFechaNac;
        private TextBox txtNacionalidad;
        private FontAwesome.Sharp.IconButton ibtnDelete;
        private FontAwesome.Sharp.IconButton ibtnUpdate;
        private FontAwesome.Sharp.IconButton ibtnCreate;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtApellidoM;
        private TextBox txtApellidoP;
        private TextBox txtNombre;
        private DataGridView dgvActores;
    }
}