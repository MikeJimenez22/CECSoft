using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_ActivacionTipoMatriculas
    {

        private CD_Conexion conexion = new CD_Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable BuscarEstadoActivacion(int IdActivacion)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select * from Tbl_ActivacionMatricula where IdActivacionMatricula = '" + IdActivacion + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        public DataTable BuscarDatosArancel(int Id_Arancel)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = @"select a.Id_Arancel,b.IdMoneda,B.ValorMoneda,(a.Precio * B.ValorMoneda) as [Total] from Tbl_Aranceles a join Tbl_TipoMoneda b 
            on a.IdMoneda = B.IdMoneda
            where Id_Arancel = '" + Id_Arancel + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }




    }
}
