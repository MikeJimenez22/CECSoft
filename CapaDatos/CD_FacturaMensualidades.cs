using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_FacturaMensualidades
    {
        private CD_Conexion conexion = new CD_Conexion();


        public void InsertarFacturaMensualidad(string Codigo,int IdDetalleProgramacion,string Concepto)
        {
            using (SqlCommand comando = new SqlCommand("Insertar_Mensualidad", conexion.AbrirConexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Codigo", Codigo);
                comando.Parameters.AddWithValue("@Id_detalleProgramacion", IdDetalleProgramacion);
                comando.Parameters.AddWithValue("@Concepto", Concepto);
                comando.ExecuteNonQuery();
            }
            conexion.CerrarConexion();
        }


    }
}
