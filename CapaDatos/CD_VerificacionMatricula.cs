using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_VerificacionMatricula
    {
        private CD_Conexion conexion = new CD_Conexion();


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable VerificarSiTieneMatriculaCANCELADA(string CarnetEstudiante)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = @"select COUNT(a.Id_estado) as [Total] from Factura_Detalle a join Tbl_Aranceles b on a.Id_Arancel = b.Id_Arancel 
            join Tbl_Factura_Gnral c on c.Num_Factura = a.Num_Factura 
            where c.CarnetEstudiantil = '" + CarnetEstudiante + "' AND (A.Id_Arancel = '8' OR a.Id_Arancel = '20') AND a.Id_estado = '5'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


   



    }
}
