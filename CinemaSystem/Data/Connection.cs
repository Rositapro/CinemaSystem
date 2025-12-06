using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace CinemaSystem.Data
{
    public class Connection
    {
        // Cadena de conexión (Ajusta Data Source a tu servidor real)
        // NOTA: Con Microsoft.Data.SqlClient es importante agregar TrustServerCertificate=True para desarrollo local
        private static string cadena = "Data Source=ROSALINDA\\SQLEXPRESS;Initial Catalog=CinemaSystem;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetConexion()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(cadena);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con SQL: " + ex.Message);
            }
        }
    }
}
