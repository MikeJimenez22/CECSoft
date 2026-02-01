using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_AsistenciaEstudiante
    {
        CD_AsistenciaEstudiante objeto = new CD_AsistenciaEstudiante();

        public void InsertarAsistenciaEstudiante(string IdMatricula, string Fecha, string Hora, string Estado, string Comentarios, string IdUsuario)
        {
            objeto.InsertarAsistencia(Convert.ToInt32(IdMatricula), Convert.ToDateTime(Fecha), Convert.ToDateTime(Hora), Estado, Comentarios, Convert.ToInt32(IdUsuario));
        }

        public void QuitarMatriculaDeGrupo(string IdMatricula)
        {
            objeto.QuitarMatriculaDeGrupo(Convert.ToInt32(IdMatricula));
        }

        public DataTable MostrarEstudiantesPorGrupo(string IdGrupo)
        {
            DataTable tabla = new DataTable();
            tabla = objeto.MostrarEstudiantesPorGrupo(Convert.ToInt32(IdGrupo));
            return tabla;
        }

        public DataTable MostrarReporteAsistencia(string fecha)
        {
            DataTable tabla = new DataTable();
            tabla = objeto.MostrarReporteAsistencia(Convert.ToDateTime(fecha));
            return tabla;
        }

        public DataTable MostrarGruposActivosPorTurno(string Turno)
        {
            DataTable tabla = new DataTable();
            tabla = objeto.MostrarGruposActivosPorTurno(Turno);
            return tabla;
        }


     
      


        public DataTable MostrarUniversoPorGrupo()
        {
            DataTable tabla = new DataTable();
            tabla = objeto.MostrarUniversoPorGrupo();
            return tabla;
        }

        public DataTable MostrarEstudiantesPorCurso()
        {
            DataTable tabla = new DataTable();
            tabla = objeto.MostrarEstudiantesPorCurso();
            return tabla;
        }

        public DataTable MostrarEstudiantesPorCategorias()
        {
            DataTable tabla = new DataTable();
            tabla = objeto.MostrarEstudiantesPorCategorias();
            return tabla;
        }

        public DataTable MostrarEstudiantesPorTurnos()
        {
            DataTable tabla = new DataTable();
            tabla = objeto.MostrarEstudiantesPorTurnos();
            return tabla;
        }

       

        public DataTable MostrarAusentesPorRegular()
        {
            DataTable tabla = new DataTable();
            tabla = objeto.MostrarAusentesRegular();
            return tabla;
        }


        public DataTable MostrarAusentesPorEncuentro()
        {
            DataTable tabla = new DataTable();
            tabla = objeto.MostrarAusentesEncuentro();
            return tabla;
        }

        


     
        public DataTable MostrarAsistenciaPorGrupo(string Fecha,string IdGrupo)
        {
            DataTable tabla = new DataTable();
            tabla = objeto.MostrarAsistenciaPorGrupo(Convert.ToDateTime(Fecha),Convert.ToInt32(IdGrupo));
            return tabla;
        }


    }
}
