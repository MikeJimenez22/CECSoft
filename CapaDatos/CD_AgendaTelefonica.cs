using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_AgendaTelefonica
    {

        private CD_Conexion conexion = new CD_Conexion();


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

       

        public DataTable MostrarAgenda(string id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select b.Id_agenda,b.tipo_medio,b.Compañia,b.Numero from Tbl_Personas a join Tbl_AgendaTelefonica b on a.Id_persona = b.Id_persona where a.Id_persona = '" + id + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        //Metodo Insertar Persona
        public void Insertar(int IdPersona, string TipoMedio, string Compañia, string NumeroTelefonico)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarAgendaTelefonica";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idpersona", IdPersona);
            comando.Parameters.AddWithValue("@medio", TipoMedio);
            comando.Parameters.AddWithValue("@Compañia", Compañia);
            comando.Parameters.AddWithValue("@Numero", NumeroTelefonico);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

     
        public void Eliminar(int Codigo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Exec EliminarTelefono " + Codigo;
            comando.ExecuteNonQuery();
        }



    }
}
