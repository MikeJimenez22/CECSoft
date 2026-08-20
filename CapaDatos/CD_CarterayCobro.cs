using System;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CD_CarterayCobro
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();


        

        public DataTable ConsultarCarteraAcademica(DateTime fechaInicial,
                                           DateTime fechaFinal,
                                           string estado,
                                           string turno)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_ConsultarCarteraAcademica", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FechaInicio", fechaInicial);
                    command.Parameters.AddWithValue("@FechaFinal", fechaFinal);
                    command.Parameters.AddWithValue("@Estado", estado);
                    command.Parameters.AddWithValue("@Turno", turno);

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
