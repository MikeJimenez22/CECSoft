using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Formularios
    {

        private CD_Conexion conexion = new CD_Conexion();


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();


        public DataTable MostrarFormularios()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select * from Tbl_Formularios";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


    }
}
