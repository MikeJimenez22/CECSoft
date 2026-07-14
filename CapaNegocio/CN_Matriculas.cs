using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Matriculas
    {
        private CD_Matricula objetoCD = new CD_Matricula();

     

        public DataTable ObtenerNumeroMatricula()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ObtenerNumMatricula();
            return tabla;
        }



      


        public void Insertar(string CodMatricula, string Fecha, string IdEstudiante, string OrigenMatricula, string IdEmpleado, string IdGrupo, string IdUsuario, string FechaRegistro, string IdEstado, string observacion, string HoraRegistro, string TipoIngreso, string EstadoGrupo)
        {
            objetoCD.Insertar(CodMatricula, Convert.ToDateTime(Fecha), Convert.ToInt32(IdEstudiante), OrigenMatricula, IdEmpleado, Convert.ToInt32(IdGrupo), Convert.ToInt32(IdUsuario), Convert.ToDateTime(FechaRegistro), Convert.ToInt32(IdEstado), observacion, HoraRegistro, TipoIngreso, EstadoGrupo);
        }

    

        public DataTable MostrarNumprogramacion(string CodMatricula)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarNumProgramacion(CodMatricula);
            return tabla;
        }

        public DataTable ObtenerCursoMatricula(string CodMatricula)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ObtenerCursoMatricula(CodMatricula);
            return tabla;
        }

        public DataTable MostrarUniversoPorfechas(string fechaInicio,string FechaFinal)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarUniversoPorFecha(Convert.ToDateTime(fechaInicio),Convert.ToDateTime(FechaFinal));
            return tabla;
        }

        public void ActualizarMatriculaGrupo(string IdGrupo, string CodMatricula)
        {
            objetoCD.ActualizarMatricula(Convert.ToInt32(IdGrupo), CodMatricula);
        }


        public DataTable ObtenerUltimaMatricula()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ObtenerUltimaMatricula();
            return tabla;
        }

        public DataTable ObtenerEstudiantesAusentes()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ObtenerEstudiantesAusentes();
            return tabla;
        }



        public DataTable ObtenerEstudiantesNoAsignados()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ObtenerMatriculadosNoAsignados();
            return tabla;
        }


        public DataTable ObtenerInformacionMatricula(string CodMatricula)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ObtenerInformacionMatricula(CodMatricula);
            return tabla;
        }



    }
}
