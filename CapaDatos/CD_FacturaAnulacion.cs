using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_FacturaAnulacion
    {

        private CD_Conexion conexion = new CD_Conexion();


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();


        //Aqui mostraremos todas las Facturas que no se han Completado
        //Metodo Mostrar Persona
        public DataTable Mostrar(string CodigoFactura)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec BuscarMensualidad_Factura '" + CodigoFactura + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable MostrarAbonosPendiente(string CodigoFactura)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec ActualizarEstadoAbono '" + CodigoFactura + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable MostrarAbonos(string CodigoFactura)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec BuscarAbonos_factura '" + CodigoFactura + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }





        //aqui anularemos detalle de factura
        public void AnularDetalleDeFactura(int codigo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "AnularDetalle_deFactura";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdFacturaDetalle", codigo);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void AbonoCompletado(int codigo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizaraAbonoCompletado";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdAbono", codigo);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }




    }
}
