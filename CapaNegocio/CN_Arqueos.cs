using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Arqueos
    {
        private CD_Arqueos objetoCD = new CD_Arqueos();
        
        public DataTable BuscarMovimientos(DateTime FechaInicial, string IdCaja)
        {

            CD_Arqueos objetoCD = new CD_Arqueos();
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarMovimientos(FechaInicial.ToString("yyyy-MM-dd"), Convert.ToInt32(IdCaja));
            return tabla;

        }

        public DataTable BuscarMovimientosTodasLasCajas(DateTime FechaInicial)
        {

            CD_Arqueos objetoCD = new CD_Arqueos();
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarMovimientosTodasLasCajas(FechaInicial.ToString("yyyy-MM-dd"));
            return tabla;

        }

        
        
    }
}
