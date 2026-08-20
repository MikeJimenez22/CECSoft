using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Arqueos
    {


        public CD_Conexion conexion = new CD_Conexion();
        //SqlDataReader leer;
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

     

        public DataTable BuscarMovimientos(string Fecha, int IdCAJA)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec BuscarMovimientos '" + Fecha + "','" + IdCAJA + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        public DataTable BuscarMovimientosTodasLasCajas(string Fecha)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec BuscarPagosTodasLasCajas '" + Fecha + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        

    }
}
