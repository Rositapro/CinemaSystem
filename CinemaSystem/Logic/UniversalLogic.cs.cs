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
    public class UniversalLogic
    {
        // 1. Obtener la lista de TODAS las tablas de tu base de datos
        public List<string> ObtenerTablas()
        {
            List<string> tablas = new List<string>();
            using (SqlConnection con = Connection.GetConexion())
            {
                // Consultamos el esquema de SQL Server para ver qué tablas existen
                string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tablas.Add(reader.GetString(0));
                }
            }
            return tablas;
        }

        // 2. Cargar datos de la tabla seleccionada
        public DataTable CargarDatosTabla(string nombreTabla)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = Connection.GetConexion())
            {
                // OJO: Aquí no podemos usar parámetros normales (@tabla) para nombres de tablas.
                // Pero como el nombre viene de nuestra propia lista (método anterior), es seguro.
                string query = $"SELECT * FROM [{nombreTabla}]";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(dt);
            }
            return dt;
        }

        // 3. Guardar cambios masivos (La Magia)
        public void GuardarCambios(DataTable dt, string nombreTabla)
        {
            using (SqlConnection con = Connection.GetConexion())
            {
                string query = $"SELECT * FROM [{nombreTabla}]";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);

                // SqlCommandBuilder es el "Robot" que escribe los Inserts y Updates por ti
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                // Esto aplica todos los cambios de la tabla visual a la base de datos
                adapter.Update(dt);
            }
        }
    }
}
