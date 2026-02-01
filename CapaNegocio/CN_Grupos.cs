using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Grupos
    {
        private CD_Grupos objetoCD = new CD_Grupos();

        


        public DataTable MostrarGrupos(string TextoBuscar)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarGrupos(TextoBuscar);
            return tabla;
        }

        


        public DataTable MostrarPorGrupoPorEstado(string Estado, string Curso)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarGrupoPorEstado(Estado, Curso);
            return tabla;
        }

        public void ActualizarGrupo(string IdGrupo, string IdHorario, string IdEmpleado, string IdEstado)
        {
            objetoCD.ActualizarGrupo(Convert.ToInt32(IdGrupo), Convert.ToInt32(IdHorario), Convert.ToInt32(IdEmpleado), Convert.ToInt32(IdEstado));
        }

        public void CrearNuevoGrupo(string IdCursoTurno, string IdHorario, string IdEmpleado, string IdEstado)
        {
            objetoCD.CrearNuevoGrupo(Convert.ToInt32(IdCursoTurno), Convert.ToInt32(IdHorario), Convert.ToInt32(IdEmpleado), Convert.ToInt32(IdEstado));
        }



    }
}
