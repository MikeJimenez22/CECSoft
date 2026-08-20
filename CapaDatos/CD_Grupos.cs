using System.Data;
using System.Data.SqlClient;
using System;

namespace CapaDatos
{
    public class CD_Grupos
    {

        private CD_Conexion conexion = new CD_Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        //Metodo Mostrar Persona
        
        public DataTable MostrarGrupos(string textobuscar)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select a.Id_Grupo,f.Nombre_curso,f.Duracion, g.Turno,c.Horario,d.Cod_Carnet,e.Nombres,e.Apellidos,k.Estado,a.Id_Curso_turno,a.Id_Horario,a.Id_empleado,f.Id_curso from Tbl_Grupos a join Tbl_Curso_Turnos b on a.Id_Curso_turno = b.Id_Curso_turno join Tbl_Horarios c on a.Id_Horario = c.Id_Horario join Tbl_Empleados d on a.Id_empleado = d.Id_empleado join Tbl_Personas e on d.Id_persona = e.Id_persona join Tbl_Cursos f on f.Id_Curso = b.Id_Curso join Tbl_Turnos g on b.Id_turno = g.Id_turno join Tbl_Estados k on k.Id_estado = A.Id_estado where f.Nombre_curso like '" + textobuscar + "' + '%' AND a.Id_estado = '3'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        //Metodo Insertar Persona
      

      


        public DataTable MostrarGrupoPorEstado(string estado, string curso)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("MostrarGrupos_PorEstado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Estado", estado);
                    command.Parameters.AddWithValue("@NombreCurso", curso);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }


        public void ActualizarGrupo(int IdGrupo, int IdHorario, int IdEmpleado, int IdEstado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarGrupo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdGrupo", IdGrupo);
            comando.Parameters.AddWithValue("@IdHorario", IdHorario);
            comando.Parameters.AddWithValue("@Id_empleado", IdEmpleado);
            comando.Parameters.AddWithValue("@IdEstado", IdEstado);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void CrearNuevoGrupo(int IdCursoTurno, int IdHorario, int IdEmpleado, int IdEstado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarNuevoGrupo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCursoTurno", IdCursoTurno);
            comando.Parameters.AddWithValue("@IdHorario", IdHorario);
            comando.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
            comando.Parameters.AddWithValue("@IdEstado", IdEstado);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }


        public DataTable ConsultarGruposInatecPorFecha(DateTime fechaInicio, DateTime fechaFinal)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_ConsultarGruposInatecPorFecha", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@FechaFinal", fechaFinal);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

        public DataSet ConsultarEstudiantesGrupoInatec(
     int idGrupo,
     DateTime fechaInicio,
     DateTime fechaFinal,
     string turno)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand(
                    "SP_ConsultarEstudiantesOfertaINATEC",
                    connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue(
                        "@IdGrupo",
                        idGrupo);

                    command.Parameters.AddWithValue(
                        "@FechaInicio",
                        fechaInicio.Date);

                    command.Parameters.AddWithValue(
                        "@FechaFinal",
                        fechaFinal.Date);

                    command.Parameters.AddWithValue(
                        "@Turno",
                        turno);

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        return dataSet;
                    }
                }
            }
        }








    }
}
