using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Personas
    {
        CD_Personas objetoCD = new CD_Personas();

        public DataTable Mostrar(string Apellidos)
        {
            CD_Personas objetoCD = new CD_Personas();
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar(Apellidos);
            return tabla;
        }

        


        public void InsertarPersonas(string FechaRegistro, string Nombres, string Apellidos, string Cedula, string Correo, string Genero, string TipoSangre, string IdCiudad, string NumeroIdentificacion, string Direccion, string CodigoPersona, string IDprofesion, string CentroTrabajo, string CelularTrabajo, string Ocupacion, string NombreTutor, string CelularTutor, string FechaNacimiento, string Parentesco)
        {
            objetoCD.Insertar(Convert.ToDateTime(FechaRegistro), Nombres, Apellidos, Cedula, Correo, Genero, TipoSangre, Convert.ToInt32(IdCiudad), NumeroIdentificacion, Direccion, CodigoPersona, Convert.ToInt32(IDprofesion), CentroTrabajo, CelularTrabajo, Ocupacion, NombreTutor, CelularTutor, Convert.ToDateTime(FechaNacimiento), Parentesco);
        }

        public void EditarPersona(string id, string Nombres, string Apellidos, string Cedula, string Correo, string Genero, string TipoSangre, string IdCiudad, string NumeroIdentificacion, string Direccion, string IDprofesion, string CentroTrabajo, string CelularTrabajo, string Ocupacion, string NombreTutor, string CelularTutor, string FechaNacimiento, string Parentesco)
        {
            objetoCD.Editar(Convert.ToInt32(id), Nombres, Apellidos, Cedula, Correo, Genero, TipoSangre, Convert.ToInt32(IdCiudad), NumeroIdentificacion, Direccion, Convert.ToInt32(IDprofesion), CentroTrabajo, CelularTrabajo, Ocupacion, NombreTutor, CelularTutor, Convert.ToDateTime(FechaNacimiento), Parentesco);
        }

        

        public DataTable MostrarPersonasPorNombres(string Nombres)
        {
            CD_Personas objetoCD = new CD_Personas();
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarPersonasPorNombres(Nombres);
            return tabla;
        }

        public DataTable ObtenerDatosCedula(string cedula)
        {
            CD_Personas objetoCD = new CD_Personas();
            DataTable tabla = new DataTable();
            tabla = objetoCD.ObtenerDatosPersonaConCedula(cedula);
            return tabla;
        }


        public DataTable ObtenerUltimaPersona()
        {
            CD_Personas objetoCD = new CD_Personas();
            DataTable tabla = new DataTable();
            tabla = objetoCD.ObtenerUltimaPersona();
            return tabla;
        }

        public DataTable VerificarCorreo(string correo,string usuario)
        {
            CD_Personas objetoCD = new CD_Personas();
            DataTable tabla = new DataTable();
            tabla = objetoCD.VerificarCorreo(correo,usuario);
            return tabla;
        }



    }
}
