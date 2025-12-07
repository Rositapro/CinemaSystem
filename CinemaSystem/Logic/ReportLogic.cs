using CinemaSystem.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSystem.Logic
{
    public class ReportLogic
    {
        // Método Maestro: Sirve para cualquiera de los 10 reportes
        public DataTable ObtenerReporte(string nombreVista)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = Connection.GetConexion())
                {
                    // Validamos que sea una vista permitida para evitar inyección SQL manual
                    if (!nombreVista.StartsWith("vw_Reporte"))
                        throw new Exception("Vista no válida");

                    // Consulta simple a la vista
                    string query = $"SELECT * FROM {nombreVista}";

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                    adaptador.Fill(dt);
                }
            }
            catch (Exception)
            {
                // Aquí podrías loguear el error real
                throw;
            }
            return dt;
        }
    }
}
