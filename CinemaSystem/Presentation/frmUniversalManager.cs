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
    }
}
