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
        // Diccionario para mapear "Nombre Bonito" -> "Nombre de Vista SQL"
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
            // Llenamos el ComboBox con los nombres bonitos
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
                string vistaSql = _mapaReportes[seleccion]; // Obtenemos el nombre real SQL

                DataTable dt = _logic.ObtenerReporte(vistaSql);
                dgvReportes.DataSource = dt;

                if (dt.Rows.Count == 0)
                    MessageBox.Show("No se encontraron datos para este reporte.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message);
            }
        }

        private void ibtnExportCsv_Click(object sender, EventArgs e)
        {
            Exporter.ExportarACSV(dgvReportes);
        }
    }
}
