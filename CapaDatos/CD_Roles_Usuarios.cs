using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CD_Roles_Usuarios
    {

        private CD_Conexion conexion = new CD_Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

       
        public DataTable Mostrar(int IdEstado)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("Mostrar_Roles", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdEstado", IdEstado);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }


        public DataTable VerificarSiExistenRolesActivo(int IdUsuario)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_BuscarRolUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

        public void Insertar(int IdUsuario, int IdRol, int IdState)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Insertar_Rol_Usuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            comando.Parameters.AddWithValue("@IdRol", IdRol);
            comando.Parameters.AddWithValue("@IdEstado", IdState);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void ModificarEstado(int IdRolUsuario, int IdEstado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_ModificarRolUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdRolUsuario", IdRolUsuario);
            comando.Parameters.AddWithValue("@IdEstado", IdEstado);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();


        }

    





    }
}
