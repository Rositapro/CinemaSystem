using CinemaSystem.Data;
using CinemaSystem.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaSystem.Presentation
{
    public partial class frmMainMenu : Form
    {
        // Instanciamos la lógica una sola vez para usarla en todo el form
        private ActorLogic _logic = new ActorLogic();

        public frmMainMenu()
        {
            InitializeComponent();
            CargarDatos(); // Cargar la lista apenas abra la ventana
        }
        // --- MÉTODO AUXILIAR: REFRESCAR LA TABLA ---
        private void CargarDatos()
        {
            try
            {
                dgvActores.DataSource = _logic.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        // --- MÉTODO AUXILIAR: LIMPIAR CAMPOS ---
        private void Limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtApellidoP.Text = "";
            txtApellidoM.Text = "";
            txtNacionalidad.Text = "";
            dtpFechaNac.Value = DateTime.Now;
        }
        private void ibtnCreate_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
                return;
            }

            try
            {
                bool exito = _logic.Create(
                    txtNombre.Text.Trim(),
                    txtApellidoP.Text.Trim(),
                    txtApellidoM.Text.Trim(),
                    dtpFechaNac.Value,
                    txtNacionalidad.Text.Trim()
                );

                if (exito)
                {
                    MessageBox.Show("Actor registrado correctamente.");
                    CargarDatos(); // Recargar la tabla para ver el nuevo
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el actor.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ibtnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Selecciona un actor de la tabla primero.");
                return;
            }

            try
            {
                int id = int.Parse(txtId.Text); // Recuperamos el ID oculto

                bool exito = _logic.Update(
                    id,
                    txtNombre.Text.Trim(),
                    txtApellidoP.Text.Trim(),
                    txtApellidoM.Text.Trim(),
                    dtpFechaNac.Value,
                    txtNacionalidad.Text.Trim()
                );

                if (exito)
                {
                    MessageBox.Show("Actor modificado correctamente.");
                    CargarDatos();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar: " + ex.Message);
            }
        }

        private void ibtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Selecciona un actor de la tabla para eliminar.");
                return;
            }

            if (MessageBox.Show("¿Seguro que deseas eliminar este actor?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int id = int.Parse(txtId.Text);
                    bool exito = _logic.Delete(id);

                    if (exito)
                    {
                        MessageBox.Show("Actor eliminado del sistema.");
                        CargarDatos();
                        Limpiar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message);
                }
            }
        }
        // 4. EVENTO EXTRA: LLENAR CAMPOS AL HACER CLIC EN LA TABLA
        // (Ve a las propiedades del DataGridView -> Rayito -> Doble clic en CellClick)

        private void dgvActores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verificar que no sea el encabezado
            {
                DataGridViewRow fila = dgvActores.Rows[e.RowIndex];

                // Pasamos los datos de la tabla a los TextBoxes para editar
                txtId.Text = fila.Cells["idActor"].Value.ToString();
                txtNombre.Text = fila.Cells["nombre"].Value.ToString();
                txtApellidoP.Text = fila.Cells["apellidoP"].Value.ToString();
                txtApellidoM.Text = fila.Cells["apellidoM"].Value.ToString();
                txtNacionalidad.Text = fila.Cells["nacionalidad"].Value.ToString();

                // Validación para fecha (por si viene nula)
                if (fila.Cells["fechaNacimiento"].Value != DBNull.Value)
                {
                    dtpFechaNac.Value = Convert.ToDateTime(fila.Cells["fechaNacimiento"].Value);
                }
            }
        }

        private void ibtnReturn_Click(object sender, EventArgs e)
        {
         
            // Busca el Menú Principal entre las ventanas abiertas (aunque esté oculto)
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is frmMainMenu) // Si encuentra el menú
                {
                    frm.Show(); // ¡Lo obliga a mostrarse!
                    break;
                }
            }
        }
    }
}
