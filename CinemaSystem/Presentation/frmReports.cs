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
    public partial class frmReports : Form
    {
        private ReportLogic _logic = new ReportLogic();
        // El BindingSource es el motor que permite filtrar sin volver a consultar SQL
        private BindingSource _bs = new BindingSource();

        private Dictionary<string, string> _mapaReportes = new Dictionary<string, string>()
        {
            { "1. Ingresos por Película", "vw_Reporte_IngresosPelicula" },
            { "2. Ventas por Sucursal", "vw_Reporte_VentasSucursal" },
            { "3. Top Clientes VIP", "vw_Reporte_ClientesVIP" },
            { "4. Ocupación de Salas", "vw_Reporte_OcupacionSalas" },
            { "5. Métodos de Pago", "vw_Reporte_MetodosPago" },
            { "6. Ventas Dulcería", "vw_Reporte_VentaSnacks" },
            { "7. Origen de Películas", "vw_Reporte_OrigenPeliculas" },
            { "8. Mantenimiento Empleados", "vw_Reporte_MantenimientoEmpleado" },
            { "9. Actores Taquilleros", "vw_Reporte_ActoresTaquilleros" },
            { "10. Auditoría Global", "vw_Reporte_AuditoriaGlobal" }
        };

        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            foreach (var nombre in _mapaReportes.Keys)
            {
                cmbReportes.Items.Add(nombre);
            }
            if (cmbReportes.Items.Count > 0) cmbReportes.SelectedIndex = 0;
        }
        private void ibtnReturn_Click(object sender, EventArgs e)
        {

            this.Close();
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is frmMainMenu) { frm.Show(); break; }
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
           try
            {
                string seleccion = cmbReportes.SelectedItem.ToString();
                string vistaSql = _mapaReportes[seleccion];

                DataTable dt = _logic.ObtenerReporte(vistaSql);

                // Conectamos los datos al BindingSource
                _bs.DataSource = dt;
                dgvReportes.DataSource = _bs;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron datos para este reporte.");
                }
                
                // --- CONFIGURACIÓN DE SOLO LECTURA ---
                dgvReportes.ReadOnly = true; // ¡Nadie puede editar!
                dgvReportes.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Se selecciona toda la fila al dar clic
                dgvReportes.AllowUserToAddRows = false; // Quita la fila blanca de abajo
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message);
            }
        }

        private void ConfigurarEdicionGrid()
        {
            dgvReportes.ReadOnly = false;
            dgvReportes.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

            foreach (DataGridViewColumn col in dgvReportes.Columns)
            {
                // Bloqueo inteligente de columnas numéricas/financieras
                if (col.ValueType == typeof(decimal) ||
                    col.ValueType == typeof(int) ||
                    col.ValueType == typeof(double) ||
                    col.Name.ToLower().Contains("total") ||
                    col.Name.ToLower().Contains("precio") ||
                    col.Name.ToLower().Contains("ingresos") ||
                    col.Name.ToLower().Contains("boletos") ||
                    col.Name.ToLower().Contains("cantidad") ||
                    col.Name.ToLower().Contains("monto"))
                {
                    col.ReadOnly = true;
                    col.DefaultCellStyle.BackColor = Color.LightGray;
                    col.DefaultCellStyle.ForeColor = Color.DimGray;
                }
                else
                {
                    col.ReadOnly = false;
                    col.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }
        private void ibtnExportCsv_Click(object sender, EventArgs e)
        {
            Exporter.ExportarACSV(dgvReportes);
        }

        private void ibtnApplyFilter_Click(object sender, EventArgs e)
        {
            if (_bs.DataSource == null) return;

            string filtroFinal = "";
            List<string> filtros = new List<string>();

            // 1. Filtro de Texto
            string texto = txtFiltro.Text.Trim();
            if (!string.IsNullOrEmpty(texto))
            {
                // Busca coincidencias en cualquier columna de texto
                string filtroTexto = "";
                foreach (DataGridViewColumn col in dgvReportes.Columns)
                {
                    if (col.ValueType == typeof(string))
                    {
                        if (filtroTexto.Length > 0) filtroTexto += " OR ";
                        // Evitamos inyección en el filtro local escapando la comilla simple
                        filtroTexto += $"[{col.Name}] LIKE '%{texto.Replace("'", "''")}%'";
                    }
                }
                if (filtroTexto.Length > 0) filtros.Add($"({filtroTexto})");
            }

            // 2. Filtro de Fechas
            if (chkFechas.Checked)
            {
                string colFecha = BuscarColumnaFecha();
                if (!string.IsNullOrEmpty(colFecha))
                {
                    string fechaInicio = dtpInicio.Value.ToString("MM/dd/yyyy");
                    string fechaFin = dtpFin.Value.ToString("MM/dd/yyyy");
                    filtros.Add($"[{colFecha}] >= '{fechaInicio}' AND [{colFecha}] <= '{fechaFin}'");
                }
                else
                {
                    MessageBox.Show("Este reporte no tiene columnas de fecha para filtrar.");
                    chkFechas.Checked = false;
                }
            }

            // 3. Aplicar al Grid
            if (filtros.Count > 0)
            {
                filtroFinal = string.Join(" AND ", filtros);
                try
                {
                    _bs.Filter = filtroFinal;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo aplicar el filtro: " + ex.Message);
                }
            }
            else
            {
                _bs.RemoveFilter();
            }
        }

        private void ibtnCleanFilter_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
            chkFechas.Checked = false;
            _bs.RemoveFilter(); // Quita todos los filtros y muestra todo
        }

        // Método auxiliar para hallar columnas de fecha
        private string BuscarColumnaFecha()
        {
            foreach (DataGridViewColumn col in dgvReportes.Columns)
            {
                // Busca columnas tipo DateTime o que se llamen "Fecha..." o "...Date"
                if (col.ValueType == typeof(DateTime) || col.Name.ToLower().Contains("fecha") || col.Name.ToLower().Contains("date"))
                {
                    return col.Name;
                }
            }
            return "";
        }

    }
}
