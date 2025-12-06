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
    public class ActorLogic
    {
        // 1. MÉTODO LEER (READ) - Trae todos los actores activos
        //public DataTable Listar()
        //{
        //    DataTable dt = new DataTable();
        //    using (SqlConnection con = Connection.GetConexion())
        //    {
        //        // Solo traemos los Activos (Ocultamos los borrados lógicamente)
        //        string query = "SELECT * FROM Actor WHERE status = 'Activo'";
        //        SqlCommand cmd = new SqlCommand(query, con);
        //        SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
        //        adaptador.Fill(dt);
        //    }
        //    return dt;
        //}

        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = Connection.GetConexion())
            {
                // IMPORTANTE: Agregamos "WHERE status = 'Activo'"
                // Así la lista ignorará a los que acabas de borrar.
                string query = "SELECT * FROM Actor WHERE status = 'Activo'";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                adaptador.Fill(dt);
            }
            return dt;

        }

        // 2. MÉTODO CREAR (CREATE)
        public bool Create(string nombre, string apellidoP, string apellidoM, DateTime fechaNac, string nacionalidad)
        {
            //using (SqlConnection con = Connection.GetConexion())
            //{
            //    // Usamos parámetros para evitar inyección SQL
            //    // Nota: No enviamos 'status' ni 'dateCreate' porque tu base de datos ya los pone solos (Defaults)
            //    string query = "INSERT INTO Actor (nombre, apellidoP, apellidoM, fechaNacimiento, nacionalidad, idUserCreate) " +
            //                   "VALUES (@nombre, @apellidoP, @apellidoM, @fechaNac, @nacionalidad, @idUser)";

            //    SqlCommand cmd = new SqlCommand(query, con);
            //    cmd.Parameters.AddWithValue("@nombre", nombre);
            //    cmd.Parameters.AddWithValue("@apellidoP", apellidoP);
            //    cmd.Parameters.AddWithValue("@apellidoM", apellidoM);
            //    cmd.Parameters.AddWithValue("@fechaNac", fechaNac);
            //    cmd.Parameters.AddWithValue("@nacionalidad", nacionalidad);
            //    cmd.Parameters.AddWithValue("@idUser", UserSession.Id); // Auditoría automática desde C#

            //    int filas = cmd.ExecuteNonQuery();
            //    return filas > 0;
            //}
            using (SqlConnection con = Connection.GetConexion())
            {
                string query = "INSERT INTO Actor (nombre, apellidoP, apellidoM, fechaNacimiento, nacionalidad, idUserCreate) " +
                               "VALUES (@nombre, @apellidoP, @apellidoM, @fechaNac, @nacionalidad, @idUser)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellidoP", apellidoP);
                cmd.Parameters.AddWithValue("@apellidoM", apellidoM);
                cmd.Parameters.AddWithValue("@fechaNac", fechaNac);
                cmd.Parameters.AddWithValue("@nacionalidad", nacionalidad);
                cmd.Parameters.AddWithValue("@idUser", UserSession.Id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 3. MÉTODO EDITAR (UPDATE)
        public bool Update(int idActor, string nombre, string apellidoP, string apellidoM, DateTime fechaNac, string nacionalidad)
        {
            using (SqlConnection con = Connection.GetConexion())
            {
                // Al editar, el Trigger de SQL se encargará de la fecha (dateUpdate), 
                // nosotros solo actualizamos el usuario (idUserUpdate).
                string query = "UPDATE Actor SET nombre = @nombre, apellidoP = @apellidoP, apellidoM = @apellidoM, " +
                               "fechaNacimiento = @fechaNac, nacionalidad = @nacionalidad, idUserUpdate = @idUser " +
                               "WHERE idActor = @idActor";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idActor", idActor);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellidoP", apellidoP);
                cmd.Parameters.AddWithValue("@apellidoM", apellidoM);
                cmd.Parameters.AddWithValue("@fechaNac", fechaNac);
                cmd.Parameters.AddWithValue("@nacionalidad", nacionalidad);
                cmd.Parameters.AddWithValue("@idUser", UserSession.Id);

                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }

        // 4. MÉTODO ELIMINAR (SOFT DELETE) - Usando tu Procedure
        public bool Delete(int idActor)
        {
            using (SqlConnection con = Connection.GetConexion())
            {
                // Llamamos al Stored Procedure que creamos en SQL para el borrado lógico
                SqlCommand cmd = new SqlCommand("sp_Eliminar_Actor", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", idActor); // Ojo: Revisa si tu SP pide @ID o @idActor
                cmd.Parameters.AddWithValue("@idUsuarioQueBorra", UserSession.Id);

                int filas = cmd.ExecuteNonQuery();
                return filas > 0; // Si retorna -1 es normal en SPs con NOCOUNT ON, pero usualmente funciona
            }
        }
    }
}
