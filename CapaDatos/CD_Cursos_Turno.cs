using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Cursos_Turno
    {

        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        //Metodo Mostrar Persona
        public DataTable Mostrar(string textobuscar)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = " SELECT  dbo.Tbl_Curso_Turnos.Id_Curso_turno, dbo.Tbl_Curso_Turnos.Precio, dbo.Tbl_Cursos.Nombre_curso, dbo.Tbl_Cursos.Duracion, dbo.Tbl_Turnos.Turno,Tbl_Turnos.Dias, dbo.Tbl_Estados.Estado, dbo.Tbl_Estados.Id_estado FROM dbo.Tbl_Curso_Turnos INNER JOIN dbo.Tbl_Cursos ON dbo.Tbl_Curso_Turnos.Id_curso = dbo.Tbl_Cursos.Id_curso INNER JOIN dbo.Tbl_Turnos ON dbo.Tbl_Curso_Turnos.Id_turno = dbo.Tbl_Turnos.Id_turno INNER JOIN dbo.Tbl_Estados ON dbo.Tbl_Cursos.id_estado = dbo.Tbl_Estados.Id_estado AND dbo.Tbl_Turnos.Id_estado = dbo.Tbl_Estados.Id_estado where dbo.Tbl_Cursos.Nombre_curso like '" + textobuscar + "' + '%'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable MostrarCursoTurno()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select a.Id_Curso_turno,e.Descripcion,a.Precio,b.Nombre_curso,b.Duracion,c.Turno,c.Dias,d.Estado,d.Id_estado,e.IdMoneda from Tbl_Curso_Turnos a join Tbl_Cursos b on a.Id_curso = b.Id_curso join Tbl_Turnos c on a.Id_turno = c.Id_turno join Tbl_Estados d on d.Id_estado = a.Id_estado join Tbl_TipoMoneda e on e.IdMoneda = a.IdMoneda";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        //Metodo Insertar Persona
        public void Insertar(int IdCurso, int IdTurno, int Precio, int IdEstado, int IdMoneda)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarCursosTurnos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCurso", IdCurso);
            comando.Parameters.AddWithValue("@Turno", IdTurno);
            comando.Parameters.AddWithValue("@Precio", Precio);
            comando.Parameters.AddWithValue("@Idestado", IdEstado);
            comando.Parameters.AddWithValue("@IdMoneda", IdMoneda);



            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(int IdCursoTurno, int IdCurso, int IdTurno, int Precio,  int IdMoneda)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarCursosTurnos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCursoTurno", IdCursoTurno);
            comando.Parameters.AddWithValue("@IdCurso", IdCurso);
            comando.Parameters.AddWithValue("@Turno", IdTurno);
            comando.Parameters.AddWithValue("@Precio", Precio);
            comando.Parameters.AddWithValue("@IdMoneda", IdMoneda);



            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

    

        public DataTable MostrarCursosPorTurno(string curso)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("MostrarCursosPorTurno", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Curso", curso);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }



        public DataTable MostrarCursosTurnoPorEstado(int IdEstado)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_MostrarCursosTurnoPorEstado", connection))
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

        public void ActualizarEstadoCursoTurno(int IdCursoTurno, int IdEstado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_ActualizarEstadoCursoTurno";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCursoTurno", IdCursoTurno);
            comando.Parameters.AddWithValue("@IdEstado", IdEstado);



            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }







    }
}
