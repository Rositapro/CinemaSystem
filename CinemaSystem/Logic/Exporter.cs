using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSystem.Logic
{
    public static class Exporter
    {
        
        public static void ExportarCSV(DataGridView grid)
        {
            EjecutarExportacion(grid, "Archivo CSV (*.csv)|*.csv", ".csv", GuardarCSV);
        }

        public static void ExportarHTML(DataGridView grid)
        {
            EjecutarExportacion(grid, "Pagina Web HTML (*.html)|*.html", ".html", GuardarHTML);
        }

        public static void ExportarJSON(DataGridView grid)
        {
            EjecutarExportacion(grid, "Datos JSON (*.json)|*.json", ".json", GuardarJSON);
        }

        public static void ExportarExcel(DataGridView grid)
        {
            EjecutarExportacion(grid, "Excel con Formato (*.xls)|*.xls", ".xls", GuardarExcel);
        }

        private delegate void MetodoGuardar(DataGridView g, string p);

        private static void EjecutarExportacion(DataGridView grid, string filtro, string ext, MetodoGuardar metodo)
        {
            if (grid.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = filtro;
            sfd.FileName = "Reporte_" + DateTime.Now.ToString("yyyyMMdd_HHmm");
            sfd.Title = "Guardar Reporte";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                  
                    metodo(grid, sfd.FileName);
                    DialogResult resultado = MessageBox.Show(
                        "Archivo exportado correctamente.\n\n¿Desea abrir el archivo ahora para visualizarlo?",
                        "Exportación Exitosa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        var psi = new ProcessStartInfo();
                        psi.FileName = sfd.FileName;
                        psi.UseShellExecute = true;

                        Process.Start(psi);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static void GuardarCSV(DataGridView grid, string path)
        {
            StringBuilder sb = new StringBuilder();
            string[] headers = new string[grid.Columns.Count];
            for (int i = 0; i < grid.Columns.Count; i++) headers[i] = grid.Columns[i].HeaderText;
            sb.AppendLine(string.Join(",", headers));

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (!row.IsNewRow)
                {
                    string[] cells = new string[grid.Columns.Count];
                    for (int i = 0; i < grid.Columns.Count; i++)
                    {
                        string val = row.Cells[i].Value?.ToString() ?? "";
                        val = val.Replace("\n", " ").Replace("\r", " ");
                        if (val.Contains(",")) val = $"\"{val}\"";
                        cells[i] = val;
                    }
                    sb.AppendLine(string.Join(",", cells));
                }
            }
            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }

        private static void GuardarHTML(DataGridView grid, string path)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html><head><meta charset='UTF-8'><style>");
            sb.AppendLine("table { border-collapse: collapse; width: 100%; font-family: Arial, sans-serif; }");
            sb.AppendLine("th { background-color: #4CAF50; color: white; padding: 10px; text-align: left; }");
            sb.AppendLine("td { border: 1px solid #ddd; padding: 8px; }");
            sb.AppendLine("tr:nth-child(even) { background-color: #f2f2f2; }");
            sb.AppendLine("</style></head><body>");
            sb.AppendLine("<h2>Reporte de Sistema</h2>");
            sb.AppendLine("<table>");
            sb.AppendLine("<tr>");
            foreach (DataGridViewColumn col in grid.Columns)
                sb.AppendLine($"<th>{col.HeaderText}</th>");
            sb.AppendLine("</tr>");

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (!row.IsNewRow)
                {
                    sb.AppendLine("<tr>");
                    foreach (DataGridViewCell cell in row.Cells)
                        sb.AppendLine($"<td>{cell.Value?.ToString() ?? ""}</td>");
                    sb.AppendLine("</tr>");
                }
            }
            sb.AppendLine("</table></body></html>");
            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }

        private static void GuardarJSON(DataGridView grid, string path)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[\n");

            bool firstRow = true;
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (!firstRow) sb.Append(",\n");
                    sb.Append("  {");

                    for (int i = 0; i < grid.Columns.Count; i++)
                    {
                        if (i > 0) sb.Append(", ");
                        string header = grid.Columns[i].HeaderText;
                        string val = row.Cells[i].Value?.ToString() ?? "";
                        val = val.Replace("\"", "\\\"").Replace("\n", " ");
                        sb.Append($"\"{header}\": \"{val}\"");
                    }
                    sb.Append("}");
                    firstRow = false;
                }
            }
            sb.Append("\n]");
            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }

        private static void GuardarExcel(DataGridView grid, string path)
        {
            GuardarHTML(grid, path);
        }
    }
}
