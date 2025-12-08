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
            btnReports = new Button();
            btnGestorUniversal = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.FromArgb(128, 128, 255);
            btnReports.Font = new Font("Yu Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReports.Location = new Point(138, 196);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(209, 47);
            btnReports.TabIndex = 4;
            btnReports.Text = "Gestor de reportes";
            btnReports.UseVisualStyleBackColor = false;
            btnReports.Click += btnReports_Click;
            // 
            // btnGestorUniversal
            // 
            btnGestorUniversal.BackColor = Color.FromArgb(128, 128, 255);
            btnGestorUniversal.Font = new Font("Yu Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGestorUniversal.Location = new Point(138, 143);
            btnGestorUniversal.Name = "btnGestorUniversal";
            btnGestorUniversal.Size = new Size(209, 47);
            btnGestorUniversal.TabIndex = 5;
            btnGestorUniversal.Text = "Gestor universal";
            btnGestorUniversal.UseVisualStyleBackColor = false;
            btnGestorUniversal.Click += btnGestorUniversal_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(198, 96);
            label1.Name = "label1";
            label1.Size = new Size(65, 26);
            label1.TabIndex = 30;
            label1.Text = "Menu";
            // 
            // frmMainMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(490, 433);
            Controls.Add(label1);
            Controls.Add(btnGestorUniversal);
            Controls.Add(btnReports);
            Name = "frmMainMenu";
            Text = "frmMainMenu";
            Load += frmMainMenu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnReports;
        private Button btnGestorUniversal;
        private Label label1;
    }
}