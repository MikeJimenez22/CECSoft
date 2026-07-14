using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
   public class CD_Libros
    {
        private CD_Conexion conexion = new CD_Conexion();
        public void InsertarLibro(string NombreLibro,
                            int Tomo,
                            string Observaciones,int IdTipoDocumento)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("SP_InsertarLibroRegistro", conexion.AbrirConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@NombreLibro", NombreLibro);
                    comando.Parameters.AddWithValue("@Tomo", Tomo);
                    comando.Parameters.AddWithValue("@Observaciones",
                        string.IsNullOrWhiteSpace(Observaciones)
                        ? (object)DBNull.Value
                        : Observaciones);
                    comando.Parameters.AddWithValue("@IdTipoDocumento", IdTipoDocumento);

                    comando.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }


        public DataTable ListarLibrosRegistro(string Buscar)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_ListarLibrosRegistro", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Buscar",Buscar);


                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

        public void AbrirLibro(int IdLibro)
        {
            using (SqlCommand comando = new SqlCommand("SP_AbrirLibroRegistro", conexion.AbrirConexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdLibro", IdLibro);
                comando.ExecuteNonQuery();
            }
            conexion.CerrarConexion();
        }

        public void CerrarLibro(int IdLibro)
        {
            using (SqlCommand comando = new SqlCommand("SP_CerrarLibroRegistro", conexion.AbrirConexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdLibro", IdLibro);
                comando.ExecuteNonQuery();
            }
            conexion.CerrarConexion();
        }


        public void EditarLibro(int IdLibro,string NombreLibro,
                            int Tomo,
                            string Observaciones)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("SP_EditarLibroRegistro", conexion.AbrirConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@IdLibro", IdLibro);
                    comando.Parameters.AddWithValue("@NombreLibro", NombreLibro);
                    comando.Parameters.AddWithValue("@Tomo", Tomo);
                    comando.Parameters.AddWithValue("@Observaciones",
                        string.IsNullOrWhiteSpace(Observaciones)
                        ? (object)DBNull.Value
                        : Observaciones);

                    comando.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public void AnularLibro(int IdLibro)
        {
            using (SqlCommand comando = new SqlCommand("SP_AnularLibroRegistro", conexion.AbrirConexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdLibro", IdLibro);
                comando.ExecuteNonQuery();
            }
            conexion.CerrarConexion();
        }


        public DataTable CargarLibrosPorTipoDocumento(int IdTipoDocumento)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_CargarLibrosPorTipoDocumento", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdTipoDocumento", IdTipoDocumento);


                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }


        public DataTable ObtenerSiguienteRegistro(int idLibro, int idTipoDocumento)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlCommand comando = new SqlCommand("SP_ObtenerSiguienteRegistro", conexion.AbrirConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@IdLibro", idLibro);
                    comando.Parameters.AddWithValue("@IdTipoDocumento", idTipoDocumento);

                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    da.Fill(tabla);
                }
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return tabla;
        }







    }
}
