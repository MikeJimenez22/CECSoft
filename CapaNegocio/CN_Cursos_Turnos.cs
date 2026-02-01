using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Cursos_Turnos
    {

        private CD_Cursos_Turno objetoCD = new CD_Cursos_Turno();

        public DataTable Mostrar(string TextoBuscar)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar(TextoBuscar);
            return tabla;
        }

        public DataTable MostrarCursoTurno()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarCursoTurno();
            return tabla;
        }



        public void InsertarCursoTurno(string Idcurso, string IdTurno, string Precio, string IdEstado, string IdMoneda)
        {
            objetoCD.Insertar(Convert.ToInt32(Idcurso), Convert.ToInt32(IdTurno), Convert.ToInt32(Precio), Convert.ToInt32(IdEstado), Convert.ToInt32(IdMoneda));
        }

        public void Editar(string IdCursoTurno, string Idcurso, string IdTurno, string Precio, string IdMoneda)
        {
            objetoCD.Editar(Convert.ToInt32(IdCursoTurno), Convert.ToInt32(Idcurso), Convert.ToInt32(IdTurno), Convert.ToInt32(Precio), Convert.ToInt32(IdMoneda));
        }

      

        public DataTable MostrarCursosTurnos(string curso)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarCursosPorTurno(curso);
            return tabla;
        }



        public DataTable MostrarCursoTurnoPorEstado(string IdEstado)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarCursosTurnoPorEstado(Convert.ToInt32(IdEstado));
            return tabla;
        }

        public void ActualizarEstadoCurso(string IdCursoTurno, string IdEstado)
        {
            objetoCD.ActualizarEstadoCursoTurno(Convert.ToInt32(IdCursoTurno),Convert.ToInt32(IdEstado));
        }


    }
}
