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


        public void InsertarRegistroAcademico(
       string CodigoDocumento,
       int IdTipoDocumento,
       int IdLibro,
       int Folio,
       DateTime FechaDocumento,
       int IdMatricula,
       string NumFactura,
       string NombreCompleto,
       string Cedula,
       string CodigoMatricula,
       string NombreCurso,
       string NombreSucursal,
       DateTime? FechaFinalizacionCurso,
       string Observaciones,
       int IdUsuario,
       out int IdRegistro,
       out int NumeroRegistro,
       out string CodigoDocumentoGenerado,
       out string NombreEstudiante,
       out int FolioGenerado,
       out DateTime FechaDocumentoGenerada,
       out string LibroTomo)
        {
            IdRegistro = 0;
            NumeroRegistro = 0;
            CodigoDocumentoGenerado = string.Empty;
            NombreEstudiante = string.Empty;
            FolioGenerado = 0;
            FechaDocumentoGenerada = DateTime.MinValue;
            LibroTomo = string.Empty;

            try
            {
                using (SqlCommand comando = new SqlCommand("SP_InsertarRegistroAcademico", conexion.AbrirConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@CodigoDocumento", CodigoDocumento);
                    comando.Parameters.AddWithValue("@IdTipoDocumento", IdTipoDocumento);
                    comando.Parameters.AddWithValue("@IdLibro", IdLibro);
                    comando.Parameters.AddWithValue("@Folio", Folio);
                    comando.Parameters.AddWithValue("@FechaDocumento", FechaDocumento);
                    comando.Parameters.AddWithValue("@Id_Matricula", IdMatricula);

                    comando.Parameters.AddWithValue("@Num_Factura",
                        string.IsNullOrWhiteSpace(NumFactura)
                        ? (object)DBNull.Value
                        : NumFactura);

                    comando.Parameters.AddWithValue("@NombreCompleto", NombreCompleto);

                    comando.Parameters.AddWithValue("@Cedula",
                        string.IsNullOrWhiteSpace(Cedula)
                        ? (object)DBNull.Value
                        : Cedula);

                    comando.Parameters.AddWithValue("@CodigoMatricula", CodigoMatricula);
                    comando.Parameters.AddWithValue("@NombreCurso", NombreCurso);
                    comando.Parameters.AddWithValue("@NombreSucursal", NombreSucursal);

                    comando.Parameters.AddWithValue("@FechaFinalizacionCurso",
                        FechaFinalizacionCurso.HasValue
                        ? (object)FechaFinalizacionCurso.Value
                        : DBNull.Value);

                    comando.Parameters.AddWithValue("@Observaciones",
                        string.IsNullOrWhiteSpace(Observaciones)
                        ? (object)DBNull.Value
                        : Observaciones);

                    comando.Parameters.AddWithValue("@Id_usuario", IdUsuario);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IdRegistro = Convert.ToInt32(reader["IdRegistro"]);
                            NumeroRegistro = Convert.ToInt32(reader["NumeroRegistro"]);
                            CodigoDocumentoGenerado = reader["CodigoDocumento"].ToString();
                            NombreEstudiante = reader["NombreCompleto"].ToString();
                            FolioGenerado = Convert.ToInt32(reader["Folio"]);
                            FechaDocumentoGenerada = Convert.ToDateTime(reader["FechaDocumento"]);
                            LibroTomo = reader["LibroTomo"].ToString();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al registrar el documento académico.\n\n" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error inesperado.\n\n" + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }


        public DataTable ConsultaGeneralRegistroAcademico(string tipoBusqueda, string valorBusqueda)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlCommand comando = new SqlCommand("SP_ConsultaGeneralRegistroAcademico", conexion.AbrirConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@TipoBusqueda", tipoBusqueda);
                    comando.Parameters.AddWithValue("@ValorBusqueda", valorBusqueda);

                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    da.Fill(tabla);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al consultar los registros académicos.\n\n" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error inesperado.\n\n" + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return tabla;
        }

        public DataTable ConsultaPorLibroRegistro(int? IdLibro, int? Folio, DateTime? FechaDocumento)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlCommand comando = new SqlCommand("SP_ConsultaPorLibroRegistro", conexion.AbrirConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@IdLibro",
                        IdLibro.HasValue ? (object)IdLibro.Value : DBNull.Value);

                    comando.Parameters.AddWithValue("@Folio",
                        Folio.HasValue ? (object)Folio.Value : DBNull.Value);

                    comando.Parameters.AddWithValue("@FechaDocumento",
                        FechaDocumento.HasValue ? (object)FechaDocumento.Value : DBNull.Value);


                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    da.Fill(tabla);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al consultar los registros por libro.\n\n" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error inesperado.\n\n" + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return tabla;
        }

        public DataTable CargarLibros()
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_CargarLibros", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;


                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }


        public void ActualizarRegistroAcademico(
    int IdRegistro,
    string NumFactura,
    string Observaciones)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("SP_ActualizarRegistroAcademico", conexion.AbrirConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@IdRegistro", IdRegistro);

                    comando.Parameters.AddWithValue("@Num_Factura",
                        string.IsNullOrWhiteSpace(NumFactura)
                        ? (object)DBNull.Value
                        : NumFactura.Trim());

                    comando.Parameters.AddWithValue("@Observaciones",
                        string.IsNullOrWhiteSpace(Observaciones)
                        ? (object)DBNull.Value
                        : Observaciones.Trim());

                    comando.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al actualizar el registro académico.\n\n" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error inesperado.\n\n" + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public void AnularRegistroAcademico(
    int IdRegistro,
    string MotivoAnulacion,
    int IdUsuarioAnulacion)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("SP_AnularRegistroAcademico", conexion.AbrirConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@IdRegistro", IdRegistro);

                    comando.Parameters.AddWithValue("@MotivoAnulacion",
                        string.IsNullOrWhiteSpace(MotivoAnulacion)
                        ? (object)DBNull.Value
                        : MotivoAnulacion);

                    comando.Parameters.AddWithValue("@IdUsuarioAnulacion", IdUsuarioAnulacion);

                    comando.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al anular el registro académico.\n\n" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error inesperado.\n\n" + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }


    }
}
