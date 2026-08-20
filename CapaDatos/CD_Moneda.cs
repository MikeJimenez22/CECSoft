using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Moneda
    {

        private CD_Conexion conexion = new CD_Conexion();

        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        SqlDataReader leer;



        public void Editar(double Valor)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "CambiarValorDolar";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@valor", Valor);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }




        public DataTable MostrarValorMoneda()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select Simbolo,ValorMoneda from Tbl_TipoMoneda where IdMoneda = '2'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        public DataTable MostrarMonedas()
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_MostrarMonedas", connection))
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



    }
}
