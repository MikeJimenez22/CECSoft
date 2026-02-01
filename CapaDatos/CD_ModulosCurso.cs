using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_ModulosCurso
    {

        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

       

        public DataTable MostrarModulos(int IdCurso)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select b.IdModuloCurso,b.Descripcion,b.Duracion as [Duracion en Meses] from Tbl_Cursos a join Tbl_ModulosCurso b on a.Id_curso = b.Id_curso where a.Id_curso ='" + IdCurso + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        
        public DataTable MostrarModulosPorCurso(int IdGrupo)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_MostrarModulosPorGrupo", connection))
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


    }
}
