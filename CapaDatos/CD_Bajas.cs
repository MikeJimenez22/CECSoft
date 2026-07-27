using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Bajas
    {

        private CD_Conexion conexion = new CD_Conexion();

    
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        //Metodo Mostrar Persona
   

    
        public DataTable MostrarBajas(string FechaInicial, string FechaFinal)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_MostrarBajas", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FechaInicio", FechaInicial);
                    command.Parameters.AddWithValue("@FechaFin", FechaFinal);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }



        public void Insertar(string Motivo, string Descripcion, int IdmMatricula, int IdUsuario, string NombrePC)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarBaja";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@motivoBaja", Motivo);
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);
            comando.Parameters.AddWithValue("@IdMatricula", IdmMatricula);
            comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            comando.Parameters.AddWithValue("@NombrePC", NombrePC);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void DardeBaja(int CodigoMatricula)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "DarDeBaja";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idMatricula", CodigoMatricula);



            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }


        public DataTable ConsultarEgresadosPorFecha(DateTime FechaInicial, DateTime FechaFinal)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_ConsultarEgresadosPorFecha", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FechaInicio", FechaInicial.Date);
                    command.Parameters.AddWithValue("@FechaFinal", FechaFinal.Date);

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
