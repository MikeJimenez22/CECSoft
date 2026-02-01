using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Configuraciones
    {
        CD_Configuraciones objetoCD = new CD_Configuraciones();


        public DataTable MostrarMensualidadesEnProceso()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarMensualidadesEnProceso();
            return tabla;
        }

        public DataTable MostrarAbonosEnProceso()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarAbonosEnProceso();
            return tabla;
        }

        public void ModificarEstadoMensualidad(string IdDetalleMensualidad)
        {
            objetoCD.ModificarEstadoMensualidad(Convert.ToInt32(IdDetalleMensualidad));
        }


        public void EliminarAbono(string IdAbono)
        {
            objetoCD.EliminarAbono(Convert.ToInt32(IdAbono));
        }
    }
}
