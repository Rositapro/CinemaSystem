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
            btnActores = new Button();
            btnReports = new Button();
            SuspendLayout();
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
            // btnReports
            // 
            btnReports.BackColor = Color.FromArgb(128, 128, 255);
            btnReports.Font = new Font("Yu Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReports.Location = new Point(271, 193);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(209, 48);
            btnReports.TabIndex = 4;
            btnReports.Text = "Gestor de reportes";
            btnReports.UseVisualStyleBackColor = false;
            btnReports.Click += btnReports_Click;
            // 
            // frmMainMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(800, 450);
            Controls.Add(btnReports);
            Controls.Add(btnActores);
            Name = "frmMainMenu";
            Text = "frmMainMenu";
            Load += frmMainMenu_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button btnActores;
        private Button btnReports;
    }
}