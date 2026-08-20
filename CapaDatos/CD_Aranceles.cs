using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Aranceles
    {


        private CD_Conexion conexion = new CD_Conexion();


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        //Metodo Mostrar Persona
        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select a.Id_Arancel,a.Nombre_Arancel,a.Precio,b.Simbolo,c.Estado,a.Tipo from Tbl_Aranceles a join Tbl_TipoMoneda b on a.IdMoneda = b.IdMoneda join Tbl_Estados c on c.Id_estado = a.Id_estado";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        //Metodo Insertar Persona
        public void Insertar(string NombreArancel, double precio, int TipoMoneda, int IdEstado, string Tipo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarArancel";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", NombreArancel);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@IdMoneda", TipoMoneda);
            comando.Parameters.AddWithValue("@Id_estado", IdEstado);
            comando.Parameters.AddWithValue("@Tipo", Tipo);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(int IdArancel, string NombreArancel, double precio, int TipoMoneda, int IdEstado, string Tipo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarArancel";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdArancel", IdArancel);
            comando.Parameters.AddWithValue("@Nombre", NombreArancel);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@IdMoneda", TipoMoneda);
            comando.Parameters.AddWithValue("@Id_estado", IdEstado);
            comando.Parameters.AddWithValue("@Tipo", Tipo);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public DataTable MostrarInformacionArancel(int IdArancel)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_ObtenerInformacionArancel", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdArancel", IdArancel);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }



        public DataTable MostrarAranceles()
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_MostrarAranceles", connection))
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
