using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Estados
    {
        private CD_Conexion conexion = new CD_Conexion();


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable MostrarEstados()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select Id_estado,Estado from Tbl_Estados where Id_estado = '3' or Id_estado = '4'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


    }
}
