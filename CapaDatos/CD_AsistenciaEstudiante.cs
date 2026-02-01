using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_AsistenciaEstudiante
    {
        private CD_Conexion conexion = new CD_Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public void InsertarAsistencia(int IdMatricula, DateTime Fecha, DateTime Hora, string Estado, string Comentarios, int IdUsuario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarAsistenciaEstudiantil";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdMatricula", IdMatricula);
            comando.Parameters.AddWithValue("@Fecha", Fecha);
            comando.Parameters.AddWithValue("@Hora", Hora);
            comando.Parameters.AddWithValue("@Estado", Estado);
            comando.Parameters.AddWithValue("@Comentarios", Comentarios);
            comando.Parameters.AddWithValue("@Id_usuario", IdUsuario);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public DataTable MostrarEstudiantesPorGrupo(int IdGrupo)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("MostrarEstudiantesPorGrupo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdGrupo", IdGrupo);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

        public void QuitarMatriculaDeGrupo(int IdMatricula)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "QuitarMatriculaDeGrupo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdMatricula", IdMatricula);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }




        public DataTable MostrarReporteAsistencia(DateTime Fecha)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("ReporteAsistencia", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fecha", Fecha);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }


     

     


        public DataTable MostrarUniversoPorGrupo()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec MostrarUniversoPorGrupo";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        public DataTable MostrarEstudiantesPorCurso()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec MostrarEstudiantesPorCurso";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        public DataTable MostrarEstudiantesPorCategorias()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec MostrarEstudiantesPorCategorias";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable MostrarEstudiantesPorTurnos()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec MostrarEstudiantesPorTurnos";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }



    



        public DataTable MostrarAusentesRegular()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec DarBajaPorAusenciaRegular";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        public DataTable MostrarAusentesEncuentro()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec VerAusentesPorEncuentro";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

       

       

        public DataTable MostrarGruposActivosPorTurno(string Turno)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_MostrarGruposPorTurno", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Turno", Turno);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

        public DataTable MostrarAsistenciaPorGrupo(DateTime Fecha,int IdGrupo)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_ObtenerAsistenciaPorGrupo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Fecha", Fecha);
                    command.Parameters.AddWithValue("@IdGrupo", IdGrupo);

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
