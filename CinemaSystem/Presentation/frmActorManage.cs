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
        // Variable bandera para evitar bucles infinitos al recargar
        private bool _isLoading = false;

        public frmActorManage()
        {
            InitializeComponent();
            // CONEXIÓN MANUAL DE EVENTOS (Para asegurar que funcionen)
            // Esto conecta el evento de "Terminar de Editar Celda" con nuestro código
            this.dgvActores.CellEndEdit += new DataGridViewCellEventHandler(this.dgvActores_CellEndEdit);

            CargarDatos();
        }
        private void CargarDatos()
        {
            _isLoading = true; // Activamos bandera para que el evento CellEndEdit no se dispare por error
            try
            {
                DataTable dt = _logic.Listar();
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                dgvActores.DataSource = null;
                dgvActores.DataSource = bs;

                // CONFIGURACIÓN DE EDICIÓN DIRECTA
                dgvActores.ReadOnly = false; // ¡Permitir editar!
                dgvActores.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Opcional: CellSelect es mejor para editar
                dgvActores.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect; // Mejor para editar celdas individuales

                // Proteger columnas que no se deben editar
                if (dgvActores.Columns["idActor"] != null)
                {
                    dgvActores.Columns["idActor"].ReadOnly = true;
                    dgvActores.Columns["idActor"].DefaultCellStyle.BackColor = Color.LightGray; // Visualmente bloqueada
                }

                // Ocultar columnas de auditoría
                if (dgvActores.Columns["idUserCreate"] != null) dgvActores.Columns["idUserCreate"].Visible = false;
                if (dgvActores.Columns["idUserUpdate"] != null) dgvActores.Columns["idUserUpdate"].Visible = false;
                if (dgvActores.Columns["idUserDelete"] != null) dgvActores.Columns["idUserDelete"].Visible = false;
                if (dgvActores.Columns["status"] != null) dgvActores.Columns["status"].ReadOnly = true; // El status se cambia con el botón borrar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar lista: " + ex.Message);
            }
            finally
            {
                _isLoading = false;
            }
        }
        private void dgvActores_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_isLoading) return; // Si estamos cargando, no hacemos nada

            try
            {
                // 1. Capturamos la fila actual que se acaba de editar
                DataGridViewRow row = dgvActores.Rows[e.RowIndex];

                // 2. Obtenemos los valores de las celdas (usando nombres de columna de BD)
                // Usamos TryParse para evitar errores si el usuario escribe texto en un número
                int id = Convert.ToInt32(row.Cells["idActor"].Value);
                string nombre = row.Cells["nombre"].Value?.ToString() ?? "";
                string apP = row.Cells["apellidoP"].Value?.ToString() ?? "";
                string apM = row.Cells["apellidoM"].Value?.ToString() ?? "";
                string nac = row.Cells["nacionalidad"].Value?.ToString() ?? "";

                DateTime fechaNac = DateTime.Now;
                if (row.Cells["fechaNacimiento"].Value != DBNull.Value)
                {
                    DateTime.TryParse(row.Cells["fechaNacimiento"].Value.ToString(), out fechaNac);
                }

                // 3. Enviamos los cambios a SQL (Live Update)
                bool exito = _logic.Update(id, nombre, apP, apM, fechaNac, nac);

                if (!exito)
                {
                    MessageBox.Show("Error: No se pudieron guardar los cambios de esta fila.");
                    // Opcional: Podrías recargar la tabla aquí para deshacer el cambio visual erróneo
                    CargarDatos();
                }
                else
                {
                    // ÉXITO SILENCIOSO: No mostramos MessageBox para no interrumpir al usuario
                    // mientras escribe rápido, pero podrías poner un label que diga "Guardado..."
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cambio: " + ex.Message);
                CargarDatos(); // Revertimos los datos si hubo error crítico
            }
        }

        // --- MÉTODO AUXILIAR: LIMPIAR CAMPOS ---
        private void Limpiar()
        {
            if (Controls.ContainsKey("txtId")) txtId.Text = "";
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
