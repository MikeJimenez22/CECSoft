using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
   public class CD_Cajas
    {
      

        private CD_Conexion conexion = new CD_Conexion();

        private SqlCommand comando = new SqlCommand();
        private SqlDataReader leer;

        public DataTable MostrarCajasActivas()
        {
            DataTable tabla = new DataTable();

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_MostrarCajasActivas";
            comando.CommandType = CommandType.StoredProcedure;

            leer = comando.ExecuteReader();
            tabla.Load(leer);

            conexion.CerrarConexion();

            return tabla;
        }


    }
}
