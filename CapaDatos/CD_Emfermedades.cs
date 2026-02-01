using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CD_Emfermedades
    {

        private CD_Conexion conexion = new CD_Conexion();


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        //Metodo Mostrar Persona
  
       

        public DataTable MostrarEnfermedades(string TextoBuscar)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select * from Tbl_Emfermedades where  Emfermedades like '" + TextoBuscar + "' + '%'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        //Metodo Insertar Persona
        public void Insertar(int IdPersona, int IdEmfermedad)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Insert into TblHistorialEmfermedades values('" + IdPersona + "','" + IdEmfermedad + "')";
            comando.ExecuteNonQuery();

        }

        public void Editar(int Codigo, int IdPersona, int IdEmfermedad)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Update  TblHistorialEmfermedades set Id_persona ='" + IdPersona + "', IdEmfermedad = '" + IdEmfermedad + "' where IdHistorialEnfermedades = '" + Codigo + "'";
            comando.ExecuteNonQuery();

        }

        public void Eliminar(int Codigo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = " Delete TblHistorialEmfermedades  where IdHistorialEnfermedades = '" + Codigo + "'";
            comando.ExecuteNonQuery();
        }


        public DataTable MostrarEnfermedadesPorPersona(int IdPersona)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("ObtenerEnfermedadesPorPersona", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdPersona", IdPersona);

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
