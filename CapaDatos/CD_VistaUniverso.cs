using System.Data;
using System.Data.SqlClient;
using System;


namespace CapaDatos
{
    public class CD_VistaUniverso
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();




        public DataTable MostrarPorCarnet(string carnet, int estado)
        {
            DataTable tabla = new DataTable();



            using (SqlCommand comando = new SqlCommand("MostrarMatriculasPorCarnet", conexion.Conexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@TextoBusqueda", carnet);
                comando.Parameters.AddWithValue("@IdEstado", estado);

                comando.CommandTimeout = 60;

                conexion.AbrirConexion();
                tabla.Load(comando.ExecuteReader());
            }


            return tabla;

        }




        public DataTable MostrarPorCodMatricula(string carnet, int estado)
        {
            DataTable tabla = new DataTable();



            using (SqlCommand comando = new SqlCommand("MostrarMatriculasPorCodMatricula", conexion.Conexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@TextoBusqueda", carnet);
                comando.Parameters.AddWithValue("@IdEstado", estado);

                comando.CommandTimeout = 60;

                conexion.AbrirConexion();
                tabla.Load(comando.ExecuteReader());
            }


            return tabla;

        }

        

        public DataTable MostrarPorNombres(string nombre, int estado)
        {
            DataTable tabla = new DataTable();



            using (SqlCommand comando = new SqlCommand("MostrarMatriculasPorNombres", conexion.Conexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@TextoBusqueda", nombre);
                comando.Parameters.AddWithValue("@IdEstado", estado);

                conexion.AbrirConexion();
                tabla.Load(comando.ExecuteReader());
            }


            return tabla;

        }


        public DataTable MostrarPorApellidos(string Apellidos,int estado)
        {
            DataTable tabla = new DataTable();



            using (SqlCommand comando = new SqlCommand("MostrarMatriculasPorApellidos", conexion.Conexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@TextoBusqueda", Apellidos);
                comando.Parameters.AddWithValue("@IdEstado", estado);

                conexion.AbrirConexion();
                tabla.Load(comando.ExecuteReader());
            }


            return tabla;

        }



        //Metodo Mostrar Persona
        public DataTable MostrarAltas(int IdMatricula)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select Fecha_Reingreso from Tbl_Reingresos where Id_Matricula = '" + IdMatricula + "' order by Fecha_Reingreso Desc";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        //Metodo Mostrar Persona
        public DataTable MostrarBajas(int IdMatricula)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select Motivo_baja,Descripcion,Fecha_Baja from Tbl_Bajas where Id_Matricula  = '" + IdMatricula + "' order by Fecha_Baja desc";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        public DataTable MostrarMatriculasPorFechaEjecutivo(
     DateTime FechaInicial,
     DateTime FechaFinal,
     int Estado)
        {
            DataTable tabla = new DataTable();

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_MostrarMatriculasPorFechaEjecutivo";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Clear();

            comando.Parameters.Add("@FechaInicial", SqlDbType.Date).Value = FechaInicial.Date;
            comando.Parameters.Add("@FechaFinal", SqlDbType.Date).Value = FechaFinal.Date;
            comando.Parameters.Add("@Estado", SqlDbType.Int).Value = Estado;

            leer = comando.ExecuteReader();

            tabla.Load(leer);

            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return tabla;
        }





        public DataTable GenerarExpedienteEstudiantil(string CodigoMatricula)
        {
            DataTable tabla = new DataTable();



            using (SqlCommand comando = new SqlCommand("GenerarExpedienteEstudiante", conexion.Conexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@TextoBusqueda", CodigoMatricula);
                comando.CommandTimeout = 60;

                conexion.AbrirConexion();
                tabla.Load(comando.ExecuteReader());
            }


            return tabla;

        }


     

     

        public DataTable ObtenerFacturaRegistro(string CodMatricula)
        {
            DataTable tabla = new DataTable();



            using (SqlCommand comando = new SqlCommand("ObtenerPrimerFactura", conexion.Conexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@CodMatricula", CodMatricula);

                comando.CommandTimeout = 60;

                conexion.AbrirConexion();
                tabla.Load(comando.ExecuteReader());
            }


            return tabla;

        }

        




    }
}
