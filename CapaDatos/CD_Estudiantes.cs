using System;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CD_Estudiantes
    {

        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        
        public DataTable Buscar_ModificacionCarnet(int IdEstudiante)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Select Cod_carnet from Tbl_Estudiantes where Cod_carnet = '00000000000' and Id_estudiante = '" + IdEstudiante + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

     


        public DataTable BuscarEstudianteApellidos(string Apellidos)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select a.Id_estudiante,a.Cod_carnet,b.Nombres,b.Apellidos,b.Cedula,c.NombreSucursal,d.Estado from Tbl_Estudiantes a join Tbl_Personas b on a.Id_persona = b.Id_persona join TblSucursales c on a.Id_sucursal = c.Id_sucursal join Tbl_Estados d on  a.Id_estado = d.Id_estado where b.Apellidos like '" + Apellidos + "' + '%'  and d.Id_estado = '3'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable BuscarEstudianteCedula(string Cedula)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select a.Id_estudiante,a.Cod_carnet,b.Nombres,b.Apellidos,b.Cedula,c.NombreSucursal,d.Estado from Tbl_Estudiantes a join Tbl_Personas b on a.Id_persona = b.Id_persona join TblSucursales c on a.Id_sucursal = c.Id_sucursal join Tbl_Estados d on  a.Id_estado = d.Id_estado where b.Cedula like '" + Cedula + "' + '%'  and d.Id_estado = '3'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

      
     

        public DataTable ObtenerCarnetEstudiantil()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec Generar_Carnet_Estudiante";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


     


        public DataTable BuscarSiExisteEstudiante(int IdPersona)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select a.Id_estudiante,a.Id_persona from Tbl_Estudiantes a join Tbl_Personas b on a.Id_persona = b.Id_persona where b.Id_persona = '" + IdPersona + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


  




        public DataTable MostrarEstudiante(string TextoBuscar, DateTime Fecha)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("MostrarEstudiantePorDia", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre", TextoBuscar);
                    command.Parameters.AddWithValue("@fecha", Fecha);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

        public DataTable MostrarEstudianteEspecifico(string TextoBuscar)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("MostrarEstudiante", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre", TextoBuscar);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

        //Metodo Insertar Persona
        public void Insertar(int idpersona, string codigoCarnet, DateTime FechaIngreso, DateTime FechaFinalizacion, int IdpadreTutor, int IdScursal, int IdEstado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarEstudiante";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdPersona", idpersona);
            comando.Parameters.AddWithValue("@CodCarnet", codigoCarnet);
            comando.Parameters.AddWithValue("@FechaIngreso", FechaIngreso);
            comando.Parameters.AddWithValue("@FechaFinalizacion", FechaFinalizacion);
            comando.Parameters.AddWithValue("@IdpadreTutor", IdpadreTutor);
            comando.Parameters.AddWithValue("@IdSucursal", IdScursal);
            comando.Parameters.AddWithValue("@IdEstado", IdEstado);



            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }


        


        //Metodo Insertar Persona
        public void ModificarCarnet(int idestudiante, string NuevoCarnet)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ModificarCarnetEstudiante";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idEstudiante", idestudiante);
            comando.Parameters.AddWithValue("@Carnet", NuevoCarnet);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }


       


        public DataTable ObtenerFechaIngresoEstudiante(string CodigoEstudiante)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec ObtenerFechaIngresoEstudiante '" + CodigoEstudiante + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        public DataTable MostrarListadoCarnetSolicitud(DateTime FechaInicio, DateTime FechaFinal)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_ObtenerListadoCarnet", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                    command.Parameters.AddWithValue("@FechaFinal", FechaFinal);

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
