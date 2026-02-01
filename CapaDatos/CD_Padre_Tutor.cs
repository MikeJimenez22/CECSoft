using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{


    public class CD_Padre_Tutor
    {
        private CD_Conexion conexion = new CD_Conexion();


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        //Metodo Mostrar Persona
        public DataTable Mostrar(string textobuscar)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT  dbo.Tbl_Personas.Id_persona, dbo.Tbl_Personas.Nombres, dbo.Tbl_Personas.Apellidos, dbo.Tbl_Personas.Cedula, dbo.Tbl_padre_tutor.Id_padre_tutor FROM dbo.Tbl_padre_tutor INNER JOIN dbo.Tbl_Personas ON dbo.Tbl_padre_tutor.Id_persona = dbo.Tbl_Personas.Id_persona where dbo.Tbl_Personas.Nombres like '" + textobuscar + "' + '%'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

      


    }
}
