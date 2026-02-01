using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CD_Arreglos
    {


        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public void Insertar(string NumArreglo, string Fecha, string NumProgramacion, string FechaProxima, string Observacion, string Autorizado, string FechaAutorizado, int IdUsuario, string NameEquipo, int IdEstado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarArreglos_Pagos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@numArreglos", NumArreglo);
            comando.Parameters.AddWithValue("@Fecha", Fecha);
            comando.Parameters.AddWithValue("@NumProgramacion", NumProgramacion);
            comando.Parameters.AddWithValue("@FechaProxima", FechaProxima);
            comando.Parameters.AddWithValue("@Observacion", Observacion);
            comando.Parameters.AddWithValue("@Autorizado", Autorizado);
            comando.Parameters.AddWithValue("@FechaAutorizado", FechaAutorizado);
            comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            comando.Parameters.AddWithValue("@Equipo", NameEquipo);
            comando.Parameters.AddWithValue("@IdEstado", IdEstado);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        
        public DataTable ObtenerNumArreglo()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec Generar_NumArreglo";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable MostrarSolicitudes()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select Id_Arreglo,Num_Arreglo,Fecha,Num_programacion,Fecha_ProximaPago,Observacion from Tbl_Arreglos where Autorizado = 'NO'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        public void EditarEstado(int IdArreglo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "update Tbl_Arreglos set Autorizado = 'SI' where Id_Arreglo = '" + IdArreglo + "'";
            comando.ExecuteNonQuery();

        }


        public void DenegegarSolicitud(int IdArreglo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "update Tbl_Arreglos set Autorizado = 'NO' where Id_Arreglo = '" + IdArreglo + "'";
            comando.ExecuteNonQuery();

        }





    }
}
