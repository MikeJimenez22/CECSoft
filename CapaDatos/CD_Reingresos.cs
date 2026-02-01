using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Reingresos
    {

        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();



        public void Insertar(DateTime FechaReingreso, int IdmMatricula, int IdUsuario, string NombrePC)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Insertar_Reingreso";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Fecha_Reingreso", FechaReingreso);
            comando.Parameters.AddWithValue("@IdMatricula", IdmMatricula);
            comando.Parameters.AddWithValue("@Idusuario", IdUsuario);
            comando.Parameters.AddWithValue("@NombrePC", NombrePC);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }


        public void AtivarEstudiante(int CodigoMatricula)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ReingresarEstudiante";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idMatricula", CodigoMatricula);



            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }



    }
}
