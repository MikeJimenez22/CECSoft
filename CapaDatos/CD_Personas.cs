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
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT   dbo.Tbl_Personas.Id_persona, dbo.Tbl_Personas.Fecha_Registro, dbo.Tbl_Personas.Nombres, dbo.Tbl_Personas.Apellidos, dbo.Tbl_Personas.Cedula, dbo.Tbl_Personas.Correo, dbo.Tbl_Personas.Genero, dbo.Tbl_Personas.TipoSangre, dbo.Tbl_Personas.Direccion, dbo.Tbl_Personas.CodigoPersona, dbo.Tbl_Ciudades.Ciudad, dbo.Tbl_Departamentos.Departamento, dbo.Tbl_Personas.Id_ciudad, dbo.Tbl_Personas.IdPartidaNacimiento FROM  dbo.Tbl_Ciudades INNER JOIN  dbo.Tbl_Personas ON dbo.Tbl_Ciudades.Id_ciudad = dbo.Tbl_Personas.Id_ciudad INNER JOIN dbo.Tbl_Departamentos ON dbo.Tbl_Ciudades.Id_departamento = dbo.Tbl_Departamentos.Id_departamento WHERE dbo.Tbl_Personas.Apellidos like '" + Apellidos + "' + '%' ORDER BY dbo.Tbl_Personas.Id_persona DESC";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
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
