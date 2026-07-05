using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Personas
    {

        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();


        //Metodo Mostrar Persona
        public DataTable Mostrar(string Apellidos)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_BuscarPersonasPorApellido", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Apellidos", Apellidos);

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
        public void Insertar(DateTime Fecharegistro, string nombres, string apellidos, string cedula, string correo, string genero, string tipoSangre, int CodigoCiudad, string NumeroIdentificacion, string Direccion, string CodigoPersona, int Idprofesion, string CentroTrabajo, string CelularTrabajo, string Ocupacion, string NombreTutor, string CelularTutor, DateTime FechaNacimiento, string Parentesco)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "RegistrarPersonas";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@FechaRegistro", Fecharegistro);
            comando.Parameters.AddWithValue("@Nombres", nombres);
            comando.Parameters.AddWithValue("@Apellidos", apellidos);
            comando.Parameters.AddWithValue("@cedula", cedula);
            comando.Parameters.AddWithValue("@Correo", correo);
            comando.Parameters.AddWithValue("@Genero", genero);
            comando.Parameters.AddWithValue("@TipoSangre", tipoSangre);
            comando.Parameters.AddWithValue("@IdCiudad", CodigoCiudad);
            comando.Parameters.AddWithValue("@NumeroIdentificacion", NumeroIdentificacion);
            comando.Parameters.AddWithValue("@Direccion", Direccion);
            comando.Parameters.AddWithValue("@codigoPersona", CodigoPersona);
            comando.Parameters.AddWithValue("@Idprofesion", Idprofesion);
            comando.Parameters.AddWithValue("@CentroTrabajo", CentroTrabajo);
            comando.Parameters.AddWithValue("@CelularTrabajo", CelularTrabajo);
            comando.Parameters.AddWithValue("@Ocupacion", Ocupacion);
            comando.Parameters.AddWithValue("@NombreTutor", NombreTutor);
            comando.Parameters.AddWithValue("@CelularTutor", CelularTutor);
            comando.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
            comando.Parameters.AddWithValue("@Parentesco", Parentesco);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        //Metodo Editar Persona
        public void Editar(int Id,string nombres, string apellidos, string cedula, string correo, string genero, string tipoSangre, int CodigoCiudad, string NumeroIdentificacion, string Direccion, int Idprofesion, string CentroTrabajo, string CelularTrabajo, string Ocupacion, string NombreTutor, string CelularTutor, DateTime FechaNacimiento, string Parentesco)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarPersona";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idPersona", Id);
            comando.Parameters.AddWithValue("@Nombres", nombres);
            comando.Parameters.AddWithValue("@Apellidos", apellidos);
            comando.Parameters.AddWithValue("@cedula", cedula);
            comando.Parameters.AddWithValue("@Correo", correo);
            comando.Parameters.AddWithValue("@Genero", genero);
            comando.Parameters.AddWithValue("@TipoSangre", tipoSangre);
            comando.Parameters.AddWithValue("@IdCiudad", CodigoCiudad);
            comando.Parameters.AddWithValue("@NumeroIdentificacion", NumeroIdentificacion);
            comando.Parameters.AddWithValue("@Direccion", Direccion);
            comando.Parameters.AddWithValue("@Idprofesion", Idprofesion);
            comando.Parameters.AddWithValue("@CentroTrabajo", CentroTrabajo);
            comando.Parameters.AddWithValue("@CelularTrabajo", CelularTrabajo);
            comando.Parameters.AddWithValue("@Ocupacion", Ocupacion);
            comando.Parameters.AddWithValue("@NombreTutor", NombreTutor);
            comando.Parameters.AddWithValue("@CelularTutor", CelularTutor);
            comando.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
            comando.Parameters.AddWithValue("@Parentesco", Parentesco);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();


        }


        public DataTable MostrarPersonasPorNombres(string Nombres)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("BuscarPersonaPorNombre", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombres", Nombres);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

        public DataTable ObtenerDatosPersonaConCedula(string cedula)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("ObtenerDatosPersonaConCedula", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Cedula", cedula);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }


        public DataTable ObtenerUltimaPersona()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec ObtenerIdUltimaPersona";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }



        public DataTable VerificarCorreo(string correo,string usuario)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SPVerificarCorreo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Correo",correo);
                    command.Parameters.AddWithValue("@Usuario", usuario);

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
