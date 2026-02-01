using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Incentivo
    {
        private CD_Incentivo objetoCD = new CD_Incentivo();



        public void CambiarValorINcentivo(string Valor)
        {
            objetoCD.CambiarValorIncentivo(Convert.ToInt32(Valor));
        }

        

        public DataTable MostrarUniversoPorDiaEjecutivo(DateTime FechaInicial, DateTime fechafinal, string IdEstado)
        {
            CD_Incentivo objetoCD = new CD_Incentivo();
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarUniversoPorFechaEjecutivo(FechaInicial.ToString("yyyy-MM-dd"), fechafinal.ToString("yyyy-MM-dd"), Convert.ToInt32(IdEstado));
            return tabla;
        }

        

        public DataTable MostrarMatriculasAgrupadas(DateTime FechaInicial, DateTime fechafinal, string IdEstado)
        {
            CD_Incentivo objetoCD = new CD_Incentivo();
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarMatriculasAgrupadas(FechaInicial.ToString("yyyy-MM-dd"), fechafinal.ToString("yyyy-MM-dd"), Convert.ToInt32(IdEstado));
            return tabla;
        }


        public DataTable MostrarUniversoPorEjecutivo(DateTime FechaInicial, DateTime fechafinal, string IdEstado)
        {
            CD_VistaUniverso objetoCD = new CD_VistaUniverso();
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarMatriculasPorFechaEjecutivo(FechaInicial.ToString("yyyy-MM-dd"), fechafinal.ToString("yyyy-MM-dd"), Convert.ToInt32(IdEstado));
            return tabla;
        }

        public DataTable MostrarPagoTotalIncentivo(DateTime FechaInicial, DateTime fechafinal, string IdEstado)
        {
            CD_Incentivo objetoCD = new CD_Incentivo();
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarPagoIncentivoTotal(FechaInicial.ToString("yyyy-MM-dd"), fechafinal.ToString("yyyy-MM-dd"), Convert.ToInt32(IdEstado));
            return tabla;
        }






    }
}
