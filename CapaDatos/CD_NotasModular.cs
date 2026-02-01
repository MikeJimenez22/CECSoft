using System.Data;
using System.Data.SqlClient;
using System;

namespace CapaDatos
{
    public class CD_NotasModular
    {


        private CD_Conexion conexion = new CD_Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();



        
        public void InsertarActaNota(string CodigoActa,DateTime FechaRegistro,DateTime HoraRegistro,int IdUsuario,string IpComputadora,string NombrePC,string Docente,string Observaciones )
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_InsertarActaNotas";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CodidoActa", CodigoActa);
            comando.Parameters.AddWithValue("@FechaActa", FechaRegistro);
            comando.Parameters.AddWithValue("@HoraCreacion", HoraRegistro);
            comando.Parameters.AddWithValue("@IdUsuario",IdUsuario);
            comando.Parameters.AddWithValue("@Ipcomputadora", IpComputadora);
            comando.Parameters.AddWithValue("@NombrePC",NombrePC);
            comando.Parameters.AddWithValue("@Docente", Docente);
            comando.Parameters.AddWithValue("@Observaciones", Observaciones);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();


        }

        public void InsertarNotasEstudiante(int IdMatricula, string Modulo, string Curso, int Nota, DateTime fechaRegistro, DateTime HoraRegistro, string Observaciones, string CodigoActa, string Estado)
        {
            
                // Abrir conexión
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SP_InsertarNotas";
                comando.CommandType = CommandType.StoredProcedure;

                // Agregar parámetros
                comando.Parameters.AddWithValue("@IdMatricula", IdMatricula);
                comando.Parameters.AddWithValue("@Modulo", Modulo);
                comando.Parameters.AddWithValue("@curso", Curso);
                comando.Parameters.AddWithValue("@Nota", Nota);
                comando.Parameters.AddWithValue("@FechaRegistro", fechaRegistro); // Solo la fecha
                comando.Parameters.AddWithValue("@HoraRegistro", HoraRegistro); // Solo la hora
                comando.Parameters.AddWithValue("@Observacion", Observaciones);
                comando.Parameters.AddWithValue("@CodigoActa", CodigoActa);
                comando.Parameters.AddWithValue("@Estado", Estado);

                // Ejecutar el procedimiento almacenado
                comando.ExecuteNonQuery();

                // Limpiar parámetros
                comando.Parameters.Clear();
            
        }


        public DataTable MostrarNotasEstudante(int IdMatricula)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_BuscarNotasEstudiante", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdMatricula", IdMatricula);

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
