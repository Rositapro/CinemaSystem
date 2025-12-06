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
            // Mostrar quién está logueado en la barra de título o en un label
            this.Text = "Sistema de Cine - Usuario: " + UserSession.Name;
        }


        // 2. CERRAR SESIÓN (Importante para matar el proceso al cerrar)
        private void frmMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // 3. BOTÓN PARA ABRIR GESTIÓN DE ACTORES
      
        private void btnActores_Click(object sender, EventArgs e)
        {
            // 1. Ocultamos este menú
            this.Hide();

            // 2. Creamos la instancia de la OTRA ventana (el CRUD)
            // Asegúrate de que tienes otro archivo llamado frmActorManager.cs en la carpeta Presentation
            Presentation.frmMainMenu ventanaActores = new Presentation.frmMainMenu();

            // 3. La mostramos
            ventanaActores.ShowDialog();

            // 4. Al cerrar la otra, mostramos el menú de nuevo
            this.Show();
        }
    }
}
