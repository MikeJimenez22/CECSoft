using System;
using System.Data;
using System.Data.SqlClient;



namespace CapaDatos
{
    public class CD_AperturaCaja
    {

        private CD_Conexion conexion = new CD_Conexion();


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public void Insertar(int Caja, double Monto, string Moneda, DateTime FechaApertura, int IdUsuario, string NombreEquipo, double Total, DateTime hora)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarAperturaCaja";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idCaja", Caja);
            comando.Parameters.AddWithValue("@Monto", Monto);
            comando.Parameters.AddWithValue("@Moneda", Moneda);
            comando.Parameters.AddWithValue("@FechaApertura", FechaApertura);
            comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            comando.Parameters.AddWithValue("@NombreEquipo", NombreEquipo);
            comando.Parameters.AddWithValue("@MontoTotal", Total);
            comando.Parameters.AddWithValue("@hora", hora);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }



        public DataTable VerificarApertura(string FechaApertura, string Id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select * from Tbl_AperturaCaja where Fecha_Apertura = '" + FechaApertura + "' and IdCaja = '" + Id + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }




    }
}
