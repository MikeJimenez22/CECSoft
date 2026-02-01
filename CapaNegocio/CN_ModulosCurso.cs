using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_ModulosCurso
    {
        private CD_ModulosCurso objetoCD = new CD_ModulosCurso();


        public DataTable MostrarModulos(string Idcurso)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarModulos(Convert.ToInt32(Idcurso));
            return tabla;

        }

        public DataTable MostrarModulosPorGrupo(string IdGrupo)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarModulosPorCurso(Convert.ToInt32(IdGrupo));
            return tabla;

        }


    }
}
