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
    public partial class frmUniversalManager : Form
    {
        private UniversalLogic _logic = new UniversalLogic();
        private DataTable _tablaActual;

        public frmUniversalManager()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string tablaSeleccionada = cmbTablas.SelectedItem.ToString();

                _tablaActual = _logic.CargarDatosTabla(tablaSeleccionada);
                dgvData.DataSource = _tablaActual;

                ConfigurarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void frmUniversalManager_Load(object sender, EventArgs e)
        {
            CargarListaTablas();
        }
        private void CargarListaTablas()
        {
            try
            {
                List<string> tablas = _logic.ObtenerTablas();
                cmbTablas.Items.Clear();
                foreach (string t in tablas)
                {
                    if (t != "sysdiagrams") cmbTablas.Items.Add(t);
                }
                if (cmbTablas.Items.Count > 0) cmbTablas.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar tablas: " + ex.Message);
            }
        }
        // --- AQUÍ ESTÁ LA SEGURIDAD ---
        private void ConfigurarGrid()
        {
            dgvData.ReadOnly = false; // Permitimos editar en general
            dgvData.AllowUserToAddRows = true;
            dgvData.AllowUserToDeleteRows = true;

            // (He eliminado la parte que agregaba botones automáticos dentro de la tabla
            //  porque ahora usarás tu propio botón externo 'ibtnDelete')

            foreach (DataGridViewColumn col in dgvData.Columns)
            {
                string nombre = col.Name.ToLower();

                // REGLA DE ORO: Si es ID (PK o FK), Status o Fecha de Auditoría -> BLOQUEADO
                if (nombre.StartsWith("id") || nombre.StartsWith("date") || nombre == "status")
                {
                    col.ReadOnly = true; // ¡No se toca!
                    col.DefaultCellStyle.BackColor = Color.LightGray; // Se ve gris
                    col.DefaultCellStyle.ForeColor = Color.DarkGray;
                }
                else
                {
                    // El resto (Nombres, Precios, Descripciones) sí se puede editar
                    col.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void ibtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTablas.SelectedItem == null) return;
                string tablaSeleccionada = cmbTablas.SelectedItem.ToString();

                // --- CORRECCIÓN: AUTO-COMPLETADO DE AUDITORÍA ---
                // Iteramos sobre las filas para detectar las NUEVAS y asignarles valores por defecto
                // ya que están bloqueadas en la interfaz visual.
                foreach (DataRow row in _tablaActual.Rows)
                {
                    // Solo actuamos si la fila es NUEVA (recién agregada)
                    if (row.RowState == DataRowState.Added)
                    {
                        // 1. Asignar Status Activo por defecto si la columna existe
                        if (_tablaActual.Columns.Contains("status"))
                            row["status"] = "Activo";

                        // 2. Asignar Fecha de Creación actual si la columna existe
                        if (_tablaActual.Columns.Contains("dateCreate"))
                            row["dateCreate"] = DateTime.Now;

                        // 3. Asignar Usuario Creador (Usamos 1 por defecto o el ID del admin)
                        if (_tablaActual.Columns.Contains("idUserCreate"))
                            row["idUserCreate"] = 1;
                    }
                }

                if (_tablaActual.GetChanges() != null)
                {
                    _logic.GuardarCambios(_tablaActual, tablaSeleccionada);
                    MessageBox.Show("¡Cambios guardados exitosamente!");
                    btnLoad.PerformClick();
                }
                else
                {
                    MessageBox.Show("No hay cambios para guardar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void ibtnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is frmMainMenu) { frm.Show(); break; }
            }
        }

        private void ibtnDelete_Click(object sender, EventArgs e)
        {
            // 1. Validar que el usuario haya seleccionado una celda o fila
            if (dgvData.CurrentRow == null)
            {
                MessageBox.Show("Por favor, selecciona primero la fila que quieres inhabilitar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Preguntar confirmación para evitar clics accidentales
            if (MessageBox.Show("¿Estás seguro de inhabilitar el registro seleccionado?", "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    // 3. Obtener la fila seleccionada actualmente
                    DataGridViewRow row = dgvData.CurrentRow;

                    // 4. Verificar si la tabla tiene columna 'status'
                    if (dgvData.Columns.Contains("status"))
                    {
                        // Escribimos "Inhabilitado" en la celda status (aunque esté gris/bloqueada visualmente, por código sí se puede)
                        row.Cells["status"].Value = "Inhabilitado";

                        // Opcional: Si tienes columna de usuario modificador, actualízala también
                        if (dgvData.Columns.Contains("idUserModify"))
                            row.Cells["idUserModify"].Value = 1; // Tu ID de usuario

                        MessageBox.Show("Fila marcada como 'Inhabilitado'.\n\n¡No olvides dar clic en GUARDAR para confirmar!", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Esta tabla no tiene campo 'status', no se puede inhabilitar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al intentar inhabilitar: " + ex.Message);
                }
            }
        }
    }
}
