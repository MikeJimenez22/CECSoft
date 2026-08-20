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

        public DataTable MostrarMatriculas(string textoBusqueda, int idEstado, string tipoBusqueda)
        {
            return objetoCD.MostrarMatriculas(textoBusqueda, idEstado, tipoBusqueda);
        }






    

            public int InsertarMatricula(
                string CodMatricula,
                DateTime Fecha,
                int IdEstudiante,
                string OrigenMatricula,
                string IdEmpleado,
                int IdGrupo,
                int IdUsuario,
                int Estado,
                string observacion,
                string TipoIngreso,
                string EstadoGrupo)
            {
                return objetoCD.Insertar(
                    CodMatricula,
                    Fecha,
                    IdEstudiante,
                    OrigenMatricula,
                    IdEmpleado,
                    IdGrupo,
                    IdUsuario,
                    Estado,
                    observacion,
                    TipoIngreso,
                    EstadoGrupo
                );
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

        public DataTable MostrarMatriculasPorFecha(DateTime fechaInicial, DateTime fechaFinal, int idEstado)
        {
            return objetoCD.MostrarMatriculasPorFecha(fechaInicial, fechaFinal, idEstado);
        }

        public DataTable MostrarInformacion_Matricula(string numeroMatricula)
        {
            return objetoCD.MostrarInformacion_Matricula(numeroMatricula);
        }



    }
}
