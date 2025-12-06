using Microsoft.Data.SqlClient;
using System.Data;
using CinemaSystem.Data;
using CinemaSystem.Logic;

namespace CinemaSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string passwordPlano = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(passwordPlano))
            {
                MessageBox.Show("Por favor ingresa usuario y contraseña.");
                return;
            }

            // 1. Encriptamos la contraseña escrita para compararla con la BD
            string passwordHash = Security.EncriptarSHA256(passwordPlano);

            try
            {
                using (SqlConnection con = Connection.GetConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ValidarLogin", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            // 2. ¡LOGIN EXITOSO! Guardamos los datos en la sesión global
                            UserSession.Id = reader.GetInt32(0); // Columna ID
                            UserSession.Name = reader.GetString(1); // Columna Name

                            MessageBox.Show("Bienvenido " + UserSession.Name);

                            // 3. Abrir el Menú Principal
                            frmMainMenu menu = new frmMainMenu();
                            this.Hide();
                            menu.Show();
                        }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
