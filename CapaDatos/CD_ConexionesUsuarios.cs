using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_ConexionesUsuarios
    {

        private CD_Conexion conexion = new CD_Conexion();


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public void InsertarConexion(string CodigoConexion, DateTime FechaIngreso, DateTime HoraIngreso, string NombrePC, string IpComputadora, int IdUsuario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarConexionUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CodConexion", CodigoConexion);
            comando.Parameters.AddWithValue("@FechaIngreso", FechaIngreso);
            comando.Parameters.AddWithValue("@HoraIngreso", HoraIngreso);
            comando.Parameters.AddWithValue("@NombrePC", NombrePC);
            comando.Parameters.AddWithValue("@IpMaquina", IpComputadora);
            comando.Parameters.AddWithValue("@Id_Usuario", IdUsuario);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }


        public void DesconectarSesion(DateTime FechaSalida, DateTime HoraSalida, string CodigoConexion)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "DesconectarConexion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@fechaSalida", FechaSalida);
            comando.Parameters.AddWithValue("@HoraSalida", HoraSalida);
            comando.Parameters.AddWithValue("@CodConexion", CodigoConexion);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void ActualizarConexionesUsuario(int IdUsuario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarConexionesACerradas";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }


        public DataTable MostrarConexionPorUsuario(string usuario)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("VerificarConexionUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Usuario", usuario);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

        public DataTable MostrarIdUsuario(string usuario)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("BuscarIdUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Usuario", usuario);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }



    }
}
