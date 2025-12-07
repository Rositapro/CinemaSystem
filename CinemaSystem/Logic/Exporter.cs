using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSystem.Logic
{
    public static class Exporter
    {
        // Método estático para exportar cualquier DataGridView a un archivo CSV
        public static void ExportarACSV(DataGridView grid)
        {
            // 1. Verificación inicial: ¿Hay datos para exportar?
            if (grid.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Configurar el diálogo para guardar archivo
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo CSV (*.csv)|*.csv";
            sfd.FileName = "Reporte_Cinema_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".csv";
            sfd.Title = "Guardar Reporte como CSV";

            // Si el usuario elige dónde guardar y da "Aceptar"
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    // --- PARTE A: LAS CABECERAS (TÍTULOS DE COLUMNA) ---
                    string[] columnNames = new string[grid.Columns.Count];
                    for (int i = 0; i < grid.Columns.Count; i++)
                    {
                        // Obtenemos el texto del encabezado de cada columna
                        columnNames[i] = grid.Columns[i].HeaderText;
                    }
                    // Unimos los títulos con comas y agregamos salto de línea
                    sb.AppendLine(string.Join(",", columnNames));

                    // --- PARTE B: LAS FILAS DE DATOS ---
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        // Ignoramos la fila vacía del final que a veces pone el Grid
                        if (!row.IsNewRow)
                        {
                            string[] fields = new string[grid.Columns.Count];
                            for (int i = 0; i < grid.Columns.Count; i++)
                            {
                                // Obtenemos el valor de la celda. Si es nulo, ponemos texto vacío ""
                                string val = row.Cells[i].Value?.ToString() ?? "";

                                // TRUCO IMPORTANTE: Si el dato tiene una coma (ej. "Hola, Mundo"), 
                                // lo encerramos entre comillas para que Excel no se confunda de columna.
                                // También reemplazamos saltos de línea por espacios.
                                val = val.Replace("\n", " ").Replace("\r", " ");
                                if (val.Contains(","))
                                {
                                    val = $"\"{val}\"";
                                }

                                fields[i] = val;
                            }
                            // Unimos los campos de esta fila con comas
                            sb.AppendLine(string.Join(",", fields));
                        }
                    }

                    // 3. Escribir el archivo final en el disco
                    // Usamos Encoding.UTF8 para que respete acentos y ñ
                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                    MessageBox.Show("Reporte exportado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
