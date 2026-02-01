using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Roles
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();


        //Metodo Mostrar Persona
     
        public DataTable MostrarRolesPorEstado(int IdEstado)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("MostrarRolesPorEstado", connection))
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


        public DataTable BuscarSisExisteRol(string TextoBusqueda)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Exec VerificarSiExisteRol '" + TextoBusqueda + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable BuscarIdRol(string TextoBusqueda)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select IdRol from Tbl_Roles where Descripcion = '" + TextoBusqueda + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }




        public void Insertar(string Descripcion, int IdEstado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Insertar_Rol";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);
            comando.Parameters.AddWithValue("@IdEstado", IdEstado);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }
     
        public void ModificarEstado(int IdRol, int IdEstado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ModificarEstado_Rol";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdRol", IdRol);
            comando.Parameters.AddWithValue("@Estado", IdEstado);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }







    }
}
