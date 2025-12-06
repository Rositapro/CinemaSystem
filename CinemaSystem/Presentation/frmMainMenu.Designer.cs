namespace CinemaSystem
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
            ibtn = new FontAwesome.Sharp.IconButton();
            btnActores = new Button();
            SuspendLayout();
            // 
            // ibtn
            // 
            ibtn.IconChar = FontAwesome.Sharp.IconChar.FileCsv;
            ibtn.IconColor = Color.Black;
            ibtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtn.Location = new Point(12, 385);
            ibtn.Name = "ibtn";
            ibtn.Size = new Size(55, 53);
            ibtn.TabIndex = 1;
            ibtn.UseVisualStyleBackColor = true;
            // 
            // btnActores
            // 
            btnActores.BackColor = Color.FromArgb(128, 128, 255);
            btnActores.Font = new Font("Yu Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnActores.Location = new Point(271, 139);
            btnActores.Name = "btnActores";
            btnActores.Size = new Size(209, 48);
            btnActores.TabIndex = 3;
            btnActores.Text = "Gestión de Actores";
            btnActores.UseVisualStyleBackColor = false;
            btnActores.Click += btnActores_Click;
            // 
            // frmMainMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnActores);
            Controls.Add(ibtn);
            Name = "frmMainMenu";
            Text = "frmMainMenu";
            Load += frmMainMenu_Load;
            ResumeLayout(false);
        }

        #endregion
        private FontAwesome.Sharp.IconButton ibtn;
        private Button btnActores;
    }
}