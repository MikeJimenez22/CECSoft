using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Movimiento
    {


        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();


        public DataTable VerificarSIExisteReferencia(string Referencia)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select a.Num_Factura,a.Tipo_Pago,a.NReferencia, b.FechaRegistro,c.Nombre_Completo,c.CarnetEstudiantil  from Tbl_Detalle_Pago a join Tbl_MovimientoCaja b on a.Num_Factura = b.Num_Documento join Tbl_Factura_Gnral c on c.Num_Factura = b.Num_Documento where NReferencia = '" + Referencia + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


    }
}
