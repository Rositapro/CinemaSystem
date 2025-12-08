using System;
using System.Windows.Forms;
using CinemaSystem.Logic; // Para ver el usuario
using CinemaSystem.Presentation;

namespace CinemaSystem
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            this.Text = "Sistema de Cine - Usuario: " + UserSession.Name;
        }

        private void frmMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            this.Hide();
            Presentation.frmReports reports = new Presentation.frmReports();
            reports.ShowDialog();
            this.Show();
        }

        private void btnGestorUniversal_Click(object sender, EventArgs e)
        {
            this.Hide();
            Presentation.frmUniversalManager universal = new Presentation.frmUniversalManager();
            universal.ShowDialog();
            this.Show();
        }
    }
}
