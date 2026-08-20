using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_FacturaGeneral
    {
        CD_FacturaGeneral objetoCD = new CD_FacturaGeneral();
        

        public void ActualizarFacturaGeneralPendiente(string IdEstado)
        {
            objetoCD.ActualizarDetallesFacturaApendiente(Convert.ToInt32(IdEstado));
        }

 
        
        public DataTable BuscarMoviemientosHoy(DateTime FechaActual, string IdCaja)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarMoviemientosHoy(FechaActual.ToString("yyyy-MM-dd"), Convert.ToInt32(IdCaja));
            return tabla;
        }

        


        public DataTable BuscarVentaLibreriaHoy(DateTime FechaActual)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.CalcularVentaLibreriaTotal(FechaActual.ToString("yyyy-MM-dd"));
            return tabla;
        }


    }
}
