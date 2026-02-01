using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Configuraciones
    {

        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();



        //Metodo Mostrar Persona
        public DataTable MostrarMensualidadesEnProceso()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select * from Tbl_Detalle_Programacion where Id_estado = '1'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        public void ModificarEstadoMensualidad(int IdDetalleProgramacion)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarAPendienteMensualidad";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id_DetalleProgramacion", IdDetalleProgramacion);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public DataTable MostrarAbonosEnProceso()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select * from Tbl_Abonos where Id_estado = '1'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        public void EliminarAbono(int IdAbono)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarAbono";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdAbono", IdAbono);



            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }


    }
}
