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
        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select a.Id_curso,a.Nombre_curso,a.Duracion as [Duracion Meses],b.Estado,b.Id_estado,a.TipoCurso from Tbl_Cursos a join Tbl_Estados b on a.id_estado = b.Id_estado";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        //Metodo Insertar Persona
        public void Insertar(string NombreCurso, int Duracion, int IdEstado, string TipoCurso)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Insert into Tbl_Cursos values('" + NombreCurso + "','" + Duracion + "','" + IdEstado + "','" + TipoCurso + "')";
            comando.ExecuteNonQuery();

        }

        public void Editar(int IdCurso, string NombreCurso, int Duracion, int IdEstado, string TipoCurso)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Update  Tbl_Cursos set Nombre_curso='" + NombreCurso + "',Duracion='" + Duracion + "',id_estado='" + IdEstado + "',TipoCurso = '" + TipoCurso + "' where Id_curso ='" + IdCurso + "'";
            comando.ExecuteNonQuery();

        }

        public void Eliminar(int CodigoCargo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = " Delete Tbl_Cursos where Id_curso = '" + CodigoCargo + "'";
            comando.ExecuteNonQuery();
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


        public DataTable VerificarCurso(string NombreCurso)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SPVerificarCurso", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Curso", NombreCurso);

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
