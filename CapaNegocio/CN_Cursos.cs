using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Cursos
    {
        private CD_Cursos objetoCD = new CD_Cursos();


        public DataTable MostrarCursosPorEstado(string IdEstado)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarCursosPorEstado(Convert.ToInt32(IdEstado));
            return tabla;
        }

        public void InsertarCurso(string NombreCurso, int Duracion, string TipoCurso,string Acreditacion,string Modalidad)
        {
            objetoCD.Insertar(NombreCurso,Duracion, TipoCurso,Acreditacion,Modalidad);
        }

        public void EditarCurso( string NombreCurso,int Duracion, string TipoCurso,string Acreditacion,string Modalidad, int IdCurso)
        {
            objetoCD.Editar(NombreCurso,Duracion, TipoCurso,Acreditacion,Modalidad,IdCurso);
        }

        public void ActualizarEstadoCurso(string IdCurso, string IdEstado)
        {
            objetoCD.ModificarEstadoCurso(Convert.ToInt32(IdCurso),Convert.ToInt32(IdEstado));
        }
        

    }
}
