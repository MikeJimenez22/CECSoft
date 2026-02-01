using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Cursos
    {
        private CD_Cursos objetoCD = new CD_Cursos();

        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public DataTable MostrarCursosPorEstado(string IdEstado)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarCursosPorEstado(Convert.ToInt32(IdEstado));
            return tabla;
        }

        public void InsertarCurso(string NombreCurso, string Duracion, string IdEstado, string TipoCurso)
        {
            objetoCD.Insertar(NombreCurso, Convert.ToInt32(Duracion), Convert.ToInt32(IdEstado), TipoCurso);
        }

        public void EditarCurso(string IdCurso, string NombreCurso, string Duracion, string IdEstado, string TipoCurso)
        {
            objetoCD.Editar(Convert.ToInt32(IdCurso), NombreCurso, Convert.ToInt32(Duracion), Convert.ToInt32(IdEstado), TipoCurso);
        }

        public void ActualizarEstadoCurso(string IdCurso, string IdEstado)
        {
            objetoCD.ModificarEstadoCurso(Convert.ToInt32(IdCurso),Convert.ToInt32(IdEstado));
        }


        public void EliminarCargo(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }


        public DataTable MostrarCursosPorNombre(string Nombre)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.VerificarCurso(Nombre);
            return tabla;
        }


    }
}
