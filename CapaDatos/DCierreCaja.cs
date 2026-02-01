using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCierreCaja
    {

        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();


        public void InsertarCierre(int IdCaja, string Num_cierre, double MontoCordobas, double MontoDolares, string Fecha, int IdUsuario, string Equipo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Insertar_CierreCaja";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Idcaja", IdCaja);
            comando.Parameters.AddWithValue("@numCierre", Num_cierre);
            comando.Parameters.AddWithValue("@montoCordobas", MontoCordobas);
            comando.Parameters.AddWithValue("@montoDolares", MontoDolares);
            comando.Parameters.AddWithValue("@fecha", Fecha);
            comando.Parameters.AddWithValue("@Idusuario", IdUsuario);
            comando.Parameters.AddWithValue("@Equipo", Equipo);



            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }


        public DataTable ObtenerCierreCaja()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec GenerarNumCierre";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }





    }
}
