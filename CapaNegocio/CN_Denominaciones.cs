using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Denominaciones
    {
        CD_Denominaciones objetoCD = new CD_Denominaciones();

       
       

        public DataTable MostrarFacturaInicial(DateTime FechaInicial, string IdCaja)
        {

            CD_Denominaciones objetoCD = new CD_Denominaciones();
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarFacturaInicial(FechaInicial.ToString("yyyy-MM-dd"), Convert.ToInt32(IdCaja));
            return tabla;

        }

       



        public DataTable MostrarFacturaFinal(DateTime FechaInicial, string IdCaja)
        {

            CD_Denominaciones objetoCD = new CD_Denominaciones();
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarFacturaFinal(FechaInicial.ToString("yyyy-MM-dd"), Convert.ToInt32(IdCaja));
            return tabla;

        }


    }
}
