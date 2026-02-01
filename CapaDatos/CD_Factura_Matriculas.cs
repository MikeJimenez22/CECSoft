using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Factura_Matriculas
    {

        private CD_Conexion conexion = new CD_Conexion();


        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public void Insertar(string FechaHoraFactura, string Num_Matricula, string Num_Factura)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarCodFacTxMat";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@FechaHora", FechaHoraFactura);
            comando.Parameters.AddWithValue("@CodigoMatricula", Num_Matricula);
            comando.Parameters.AddWithValue("@NumFactura", Num_Factura);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();


        }


    }
}
