using CapaDatos;
using System;
using System.Data;


namespace CapaNegocio
{
    public class CN_Estudiantes
    {
        private CD_Estudiantes objetoCD = new CD_Estudiantes();
        
        public DataTable Buscar_ModificacionCarnet(string IdEstudiante)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Buscar_ModificacionCarnet(Convert.ToInt32(IdEstudiante));
            return tabla;
        }


      
        public DataTable BuscarPorApellidos(string Apellidos)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarEstudianteApellidos(Apellidos);
            return tabla;
        }

        public DataTable BuscarPorCedula(string cedula)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarEstudianteCedula(cedula);
            return tabla;
        }

        public DataTable ObtenerCarnetEstudiante()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ObtenerCarnetEstudiantil();
            return tabla;
        }

       
        public DataTable MostrarEstudiantes(string textobuscar, string Fecha)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarEstudiante(textobuscar, Convert.ToDateTime(Fecha));
            return tabla;
        }

        public DataTable MostrarEstudiantesEspecifico(string textobuscar)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarEstudianteEspecifico(textobuscar);
            return tabla;
        }

        public DataTable BuscarEstudianteSiExtiste(string textobuscar)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarSiExisteEstudiante(Convert.ToInt32(textobuscar));
            return tabla;
        }

      



        public void InsertarEstudiante(string IdPersona, string CodigoCarnet, string FechaIngreso, string FechaFinalizacion, string IdPadreTutor, string IdSucursal, string IdEstado)
        {
            objetoCD.Insertar(Convert.ToInt32(IdPersona), CodigoCarnet, Convert.ToDateTime(FechaIngreso), Convert.ToDateTime(FechaFinalizacion), Convert.ToInt32(IdPadreTutor), Convert.ToInt32(IdSucursal), Convert.ToInt32(IdEstado));
        }



        public void ModificarCarnet(string IdEstudiante, string Carnet)
        {
            objetoCD.ModificarCarnet(Convert.ToInt32(IdEstudiante), Carnet);
        }

       
        public DataTable ObtenerFechaIngreso(string Carnet)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ObtenerFechaIngresoEstudiante(Carnet);
            return tabla;
        }


        public DataTable MostrarCarnetEstudiantesListado(string FechaInicio,string FechaFinal)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarListadoCarnetSolicitud(Convert.ToDateTime(FechaInicio),Convert.ToDateTime(FechaFinal));
            return tabla;
        }

    }
}

