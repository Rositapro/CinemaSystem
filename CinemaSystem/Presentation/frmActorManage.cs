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

    public partial class frmActorManage : Form
    {
        // Instanciamos la lógica una sola vez para usarla en todo el form
        private ActorLogic _logic = new ActorLogic();

        public frmActorManage()
        {
            InitializeComponent();
            CargarDatos();
        }
        private void CargarDatos()
        {
            try
            {
                // 1. Obtenemos datos frescos de la BD
                DataTable dt = _logic.Listar();

                // 2. Usamos BindingSource como intermediario (esto arregla el refresco)
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                // 3. Desconectamos y reconectamos
                dgvActores.DataSource = null;
                dgvActores.DataSource = bs;

                // 4. Ajustes visuales
                dgvActores.ClearSelection();
                if (dgvActores.Columns["idUserCreate"] != null) dgvActores.Columns["idUserCreate"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar lista: " + ex.Message);
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
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) return;

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
                    MessageBox.Show("Actor registrado.");
                    Limpiar();      // Primero limpiamos
                    CargarDatos();  // Luego refrescamos
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ibtnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;

            try
            {
                int id = int.Parse(txtId.Text);
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
                    MessageBox.Show("Actor actualizado.");
                    Limpiar();
                    CargarDatos();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ibtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Selecciona un actor para eliminar.");
                return;
            }

            if (MessageBox.Show("¿Seguro que deseas eliminar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int id = int.Parse(txtId.Text);

                    bool exito = _logic.Delete(id);

                    if (exito)
                    {
                        MessageBox.Show("Actor eliminado correctamente.");

                        // CAMBIO DE ESTRATEGIA:
                        // 1. Limpiamos las cajas de texto INMEDIATAMENTE para que veas el efecto.
                        Limpiar();

                        // 2. Refrescamos la tabla después.
                        CargarDatos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message);
                }
            }
        }

        private void ibtnReturn_Click(object sender, EventArgs e)
        {
            this.Close(); // Cerramos Actores

            // Buscamos el menú principal que está oculto y lo mostramos
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is frmActorManage)
                {
                    frm.Show();
                    break;
                }
            }
        }

        private void dgvActores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Solo si hay filas y no es el header
                if (dgvActores.CurrentRow != null)
                {
                    DataGridViewRow fila = dgvActores.Rows[e.RowIndex];

                    // Usamos ?.ToString() para evitar errores si viene nulo
                    txtId.Text = fila.Cells["idActor"].Value?.ToString();
                    txtNombre.Text = fila.Cells["nombre"].Value?.ToString();
                    txtApellidoP.Text = fila.Cells["apellidoP"].Value?.ToString();
                    txtApellidoM.Text = fila.Cells["apellidoM"].Value?.ToString();
                    txtNacionalidad.Text = fila.Cells["nacionalidad"].Value?.ToString();

                    if (fila.Cells["fechaNacimiento"].Value != DBNull.Value)
                    {
                        dtpFechaNac.Value = Convert.ToDateTime(fila.Cells["fechaNacimiento"].Value);
                    }
                }
            }
        }
    }
}
