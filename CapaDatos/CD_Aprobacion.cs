using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Aprobacion
    {

        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        //Metodo Mostrar 
        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select a.IdAprobacion,b.Usuario,a.Clave,c.Estado from Tbl_ClavesAprobaciones a join Tbl_Usuarios b on a.Id_usuario = b.Id_usuario join Tbl_Estados c on c.Id_estado = a.Id_estado";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        //Metodo Insertar 
        public void Insertar(int IdUsuario, string Clave, int IdEstado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarClave";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id_usuario", IdUsuario);
            comando.Parameters.AddWithValue("@Clave", Clave);
            comando.Parameters.AddWithValue("@Id_estado", IdEstado);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }


       

    }
}
