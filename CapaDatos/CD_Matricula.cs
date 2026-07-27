using System;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CD_Matricula
    {

        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

       

        public DataTable ObtenerNumMatricula()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec Generar_Codigo_Matricula";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        


        //Metodo Insertar Persona
        public void Insertar(string CodMatricula, DateTime Fecha, int IdEstudiante, string OrigenMatricula, string IdEmpleado, int IdGrupo, int IdUsuario, DateTime FechaRegistro, int Estado, string observacion, string HoraRegistro, string TipoIngreso, string EstadoGrupo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarMatricula";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CodMatricula", CodMatricula);
            comando.Parameters.AddWithValue("@Fecha", Fecha);
            comando.Parameters.AddWithValue("@IdEstudiante", IdEstudiante);
            comando.Parameters.AddWithValue("@OrigenMatricula", OrigenMatricula);
            comando.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
            comando.Parameters.AddWithValue("@Idgrupo", IdGrupo);
            comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            comando.Parameters.AddWithValue("@FechaRegistro", FechaRegistro);
            comando.Parameters.AddWithValue("@IdEstado", Estado);
            comando.Parameters.AddWithValue("@Observacion", observacion);
            comando.Parameters.AddWithValue("@HoraRegistro", HoraRegistro);
            comando.Parameters.AddWithValue("@TipoIngreso", TipoIngreso);
            comando.Parameters.AddWithValue("@EstadoGrupo", EstadoGrupo);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }
        
        public DataTable MostrarNumProgramacion(string CodMatricula)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("MostrarProgramacionPago", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodMatricula", CodMatricula);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

        public DataTable ObtenerCursoMatricula(string CodMatricula)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("ObtenerCursoMatricula", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodMatricula", CodMatricula);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

        public void ActualizarMatricula(int IdGrupo, string CodMatricula)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarGrupoMatricula";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdGrupo", IdGrupo);
            comando.Parameters.AddWithValue("@CodMatricula", CodMatricula);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }


        public DataTable MostrarUniversoPorFecha(DateTime FechaInicio,DateTime FechaFinal)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("MostrarUniversoPorFechas", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                    command.Parameters.AddWithValue("@fechaFinal", FechaFinal);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }


        public DataTable ObtenerUltimaMatricula()
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_ObtenerUltimaMatricula", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

        public DataTable ObtenerEstudiantesAusentes()
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_ObtenerEstudiantesAusentes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

        public DataTable ObtenerMatriculadosNoAsignados()
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_ObtenerEstudiantesNoAsignado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }


        public DataTable ObtenerInformacionMatricula(string CodMatricula)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_ObtenerInformacionMatricula", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodMatricula", CodMatricula);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }


        public DataTable MostrarMatriculas(string textoBusqueda, int idEstado, string tipoBusqueda)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("MostrarMatriculas", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@TextoBusqueda", textoBusqueda);
                    command.Parameters.AddWithValue("@IdEstado", idEstado);
                    command.Parameters.AddWithValue("@TipoBusqueda", tipoBusqueda);

                    using (var reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

        public DataTable MostrarMatriculasPorFecha(DateTime fechaInicial, DateTime fechaFinal, int idEstado)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("MostrarMatriculasPorFecha", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FechaInicial", fechaInicial.Date);
                    command.Parameters.AddWithValue("@FechaFinal", fechaFinal.Date);
                    command.Parameters.AddWithValue("@IdEstado", idEstado);

                    using (var reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

        public DataTable MostrarInformacion_Matricula(string numeroMatricula)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("MostrarInformacion_Matricula", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@NumeroMatricula", numeroMatricula);

                    using (var reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

    }
}
