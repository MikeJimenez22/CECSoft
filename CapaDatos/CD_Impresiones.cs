using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Impresiones
    {

        private CD_Conexion conexion = new CD_Conexion();
      
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();


        public void InsertarRegistroImpresiones(DateTime fechaImpresion, string HoraImpresion, int IdUsuario, string NumFactura, string TipoImpresion, string Descripcion, string IpComputadora, string NombreComputadora)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarRegistroImpresion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@FechaImpresion", fechaImpresion);
            comando.Parameters.AddWithValue("@HoraImpresion", HoraImpresion);
            comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            comando.Parameters.AddWithValue("@NumFactura", NumFactura);
            comando.Parameters.AddWithValue("@TipoImpresion", TipoImpresion);
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);
            comando.Parameters.AddWithValue("@IpComputadora", IpComputadora);
            comando.Parameters.AddWithValue("@NombreComputadora", NombreComputadora);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }






    }
}
