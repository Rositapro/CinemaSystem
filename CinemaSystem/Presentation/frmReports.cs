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
            Exporter.ExportarCSV(dgvReportes);
        }

        private void ibtnApplyFilter_Click(object sender, EventArgs e)
        {
            // Si no hay datos cargados, no hacemos nada
            if (_bs.DataSource == null) return;

            List<string> filtros = new List<string>();

            // A. Filtro de Texto (Buscador)
            string texto = txtFiltro.Text.Trim();
            if (!string.IsNullOrEmpty(texto))
            {
                string filtroTexto = "";
                // Recorremos las columnas para ver cuáles son de texto
                foreach (DataGridViewColumn col in dgvReportes.Columns)
                {
                    if (col.ValueType == typeof(string))
                    {
                        if (filtroTexto.Length > 0) filtroTexto += " OR ";
                        // Creamos la regla: Columna LIKE '%texto%'
                        filtroTexto += $"[{col.Name}] LIKE '%{texto.Replace("'", "''")}%'";
                    }
                }
                if (filtroTexto.Length > 0) filtros.Add($"({filtroTexto})");
            }

            // B. Filtro de Fechas (Solo si el CheckBox está marcado)
            if (chkFechas.Checked)
            {
                string colFecha = BuscarColumnaFecha(); // Método inteligente que halla la columna
                if (!string.IsNullOrEmpty(colFecha))
                {
                    string fechaInicio = dtpInicio.Value.ToString("MM/dd/yyyy"); // Formato estándar
                    string fechaFin = dtpFin.Value.ToString("MM/dd/yyyy");

                    // CORRECCIÓN AQUÍ: Usamos # en lugar de ' para fechas
                    // Esto le dice al sistema que son fechas reales y no texto
                    filtros.Add($"[{colFecha}] >= #{fechaInicio}# AND [{colFecha}] <= #{fechaFin}#");
                }
                else
                {
                    MessageBox.Show("Este reporte no tiene columnas de fecha, no se puede filtrar por tiempo.");
                    chkFechas.Checked = false;
                }
            }

            // C. Aplicar al Grid
            if (filtros.Count > 0)
            {
                try
                {
                    // Unimos todos los filtros con AND
                    _bs.Filter = string.Join(" AND ", filtros);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo filtrar: " + ex.Message);
                    _bs.RemoveFilter();
                }
            }
            else
            {
                _bs.RemoveFilter(); // Si no hay filtros, mostrar todo
            }
        }

        private void ibtnCleanFilter_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
            chkFechas.Checked = false;
            _bs.RemoveFilter(); // Quita todos los filtros y muestra todo
        }

        private string BuscarColumnaFecha()
        {
            foreach (DataGridViewColumn col in dgvReportes.Columns)
            {
                if (col.ValueType == typeof(DateTime) || col.Name.ToLower().Contains("fecha") || col.Name.ToLower().Contains("date"))
                {
                    return col.Name;
                }
            }
            return "";
        }

        private void ibtnExportHtml_Click(object sender, EventArgs e)
        {
            Exporter.ExportarHTML(dgvReportes);
        }

        private void ibtnExportJson_Click(object sender, EventArgs e)
        {
            Exporter.ExportarJSON(dgvReportes);
        }

        private void ibtnExportXls_Click(object sender, EventArgs e)
        {
            Exporter.ExportarExcel(dgvReportes);
        }
    }
}
