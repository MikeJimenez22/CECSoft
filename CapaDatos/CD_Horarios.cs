using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CD_Horarios
    {
        private CD_Conexion conexion = new CD_Conexion();
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable MostrarHorarios(string Turno)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("MostrarTurnosPorHorario", connection))
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
    }
}
