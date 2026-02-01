using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_ActivacionMatriculas
    {
        private CD_ActivacionTipoMatriculas objetoCD = new CD_ActivacionTipoMatriculas();

        public DataTable MostrarEstadoActivacion(string IdActivacion)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarEstadoActivacion(Convert.ToInt32(IdActivacion));
            return tabla;
        }


    }
}
