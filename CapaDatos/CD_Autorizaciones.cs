using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Autorizaciones
    {

        private CD_Conexion conexion = new CD_Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable ConsultarAutorizacion(string Codigo)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_ConsultarAutorizacion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Codigo", Codigo);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

        public void Insertar(DateTime Fecha,string Motivo,string Codigo,string Autorizado,int Idusuario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_InsertarAutorizaciones";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Fecha", Fecha);
            comando.Parameters.AddWithValue("@Motivo", Motivo);
            comando.Parameters.AddWithValue("@Codigo", Codigo);
            comando.Parameters.AddWithValue("@Autorizado", Autorizado);
            comando.Parameters.AddWithValue("@IdUsuario", Idusuario);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }


    }
}
