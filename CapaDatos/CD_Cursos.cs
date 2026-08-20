using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Cursos
    {

        private CD_Conexion conexion = new CD_Conexion();


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        //Metodo Mostrar Persona
    

    
     

        public void Insertar(string NombreCurso,int Duracion,string TipoCurso,string Acreditacion,string Modalidad)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_InsertarCurso";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@NombreCurso", NombreCurso);
            comando.Parameters.AddWithValue("@Duracion", Duracion);
            comando.Parameters.AddWithValue("@TipoCurso", TipoCurso);
            comando.Parameters.AddWithValue("@Acreditacion", Acreditacion);
            comando.Parameters.AddWithValue("@Modalidad", Modalidad);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

       

        public void Editar(string NombreCurso, int Duracion, string TipoCurso, string Acreditacion,string Modalidad,int IdCurso)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_EditarCurso";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@NombreCurso", NombreCurso);
            comando.Parameters.AddWithValue("@Duracion", Duracion);
            comando.Parameters.AddWithValue("@TipoCurso", TipoCurso);
            comando.Parameters.AddWithValue("@Acreditacion", Acreditacion);
            comando.Parameters.AddWithValue("@Modalidad", Modalidad);
            comando.Parameters.AddWithValue("@IdCurso", IdCurso);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

    


        public DataTable MostrarCursosPorEstado(int IdEstado)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_MostrarCursosPorEstado", connection))
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

        public void ModificarEstadoCurso(int IdCurso, int IdEstado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SPActualizarEstadoCurso";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdEstado", IdEstado);
            comando.Parameters.AddWithValue("@IdCurso", IdCurso);
          


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }
        
    }
}
