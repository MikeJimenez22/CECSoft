using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_TiposDocumentos
    {
        private CD_Conexion conexion = new CD_Conexion();

        public void InsertarDocumento(string NombreDocumento,string Prefijo)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("SP_InsertarTipoDocumento", conexion.AbrirConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@NombreDocumento", NombreDocumento);
                    comando.Parameters.AddWithValue("@Prefijo", Prefijo);
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


        public void EditarDocumento(int IdDocumento,string NombreDocumento, string Prefijo)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("SP_EditarTipoDocumento", conexion.AbrirConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@IdTipoDocumento", IdDocumento);
                    comando.Parameters.AddWithValue("@NombreDocumento", NombreDocumento);
                    comando.Parameters.AddWithValue("@Prefijo", Prefijo);
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

        public DataTable ListarDocumentos(string Buscar)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_ListarTiposDocumento", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Buscar", Buscar);


                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

        public void ActualizarDocumento(int IdDocumento)
        {
            using (SqlCommand comando = new SqlCommand("SP_CambiarEstadoTipoDocumento", conexion.AbrirConexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdTipoDocumento", IdDocumento);
                comando.ExecuteNonQuery();
            }
            conexion.CerrarConexion();
        }





    }
}
