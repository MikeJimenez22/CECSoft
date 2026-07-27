using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_FacturaAbonos
    {
        private CD_Conexion conexion = new CD_Conexion();

        
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();


        public void InsertarFactura_Abonos(string codigo, string NumProgramacion, string Concepto)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Insertar_Factura_Abono";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Codigo", codigo);
            comando.Parameters.AddWithValue("@Num_programacion", NumProgramacion);
            comando.Parameters.AddWithValue("@Concepto", Concepto);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void ActualizarFacturabonos(string Nuevo, string Anterior)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Actualizar_FacturaAbonos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@FacturaNueva", Nuevo);
            comando.Parameters.AddWithValue("@FacturaAnterior", Anterior);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

    }
}
