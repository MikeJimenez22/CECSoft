using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CD_ActualizandoDatos
    {

        private CD_Conexion conexion = new CD_Conexion();


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable MostrarDetallesPagoAbonado()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select a.Id_Detalle_Programacion,(select COUNT(Id_Detalle_Programacion) as Total from Tbl_Abonos where Tbl_Abonos.Id_Detalle_Programacion = a.Id_Detalle_Programacion) from Tbl_Detalle_Programacion a join Tbl_Abonos b on a.Id_Detalle_Programacion = b.Id_Detalle_Programacion where b.Id_estado = '6'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }



    }
}
