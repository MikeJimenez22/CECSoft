using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Egresos
    {

        private CD_Conexion conexion = new CD_Conexion();


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public void Insertar(string NumEgreso, double Monto, int IdMoneda, string Descripcion, int IdUsuario, string Equipo, string Fecha, DateTime Hora)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Insertar_Egreso";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@NumEgreso", NumEgreso);
            comando.Parameters.AddWithValue("@Monto", Monto);
            comando.Parameters.AddWithValue("@IdMoneda", IdMoneda);
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);
            comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            comando.Parameters.AddWithValue("@Equipo", Equipo);
            comando.Parameters.AddWithValue("@FechaRegistro", Fecha);
            comando.Parameters.AddWithValue("@HoraRegistro", Hora);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public DataTable ObtenerCodEgreso()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec Generar_Num_Egreso";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }



        public void AnularEgreso(string NumEgreso)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "AnularEgreso";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@NumEgreso", NumEgreso);



            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }


    }
}
