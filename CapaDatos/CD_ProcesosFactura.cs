using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_ProcesosFactura
    {
        private CD_Conexion conexion = new CD_Conexion();


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public void EjecutarProcesos(string NumFactura)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_ANULACION_TOTAL";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Factura", NumFactura);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }





    }
}
