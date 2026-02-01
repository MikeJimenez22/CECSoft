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


        public DataTable BuscarMovimientosRocyRos(DateTime FechaInicial, string IdCaja)
        {

            CD_Arqueos objetoCD = new CD_Arqueos();
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarMovimientosrocyros(FechaInicial.ToString("yyyy-MM-dd"), Convert.ToInt32(IdCaja));
            return tabla;

        }


        public DataTable BuscarMovimientosxCaja(DateTime FechaInicial, string IdCaja)
        {

            CD_Arqueos objetoCD = new CD_Arqueos();
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarFacturasXCaja(FechaInicial.ToString("yyyy-MM-dd"), Convert.ToInt32(IdCaja));
            return tabla;

        }


        public DataTable BuscarMovimientosxCajaAsc(DateTime FechaInicial, string IdCaja)
        {

            CD_Arqueos objetoCD = new CD_Arqueos();
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarFacturasXCajaasc(FechaInicial.ToString("yyyy-MM-dd"), Convert.ToInt32(IdCaja));
            return tabla;

        }


        public DataTable BuscarMovimientosXtipo(DateTime FechaInicial, string IdCaja)
        {

            CD_Arqueos objetoCD = new CD_Arqueos();
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarMovimientoXtipo(FechaInicial.ToString("yyyy-MM-dd"), Convert.ToInt32(IdCaja));
            return tabla;

        }


        public DataTable BuscarMovimientosXtipo_Movimiento(DateTime FechaInicial, string IdCaja)
        {

            CD_Arqueos objetoCD = new CD_Arqueos();
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarMovimientoXtipo_Movimiento(FechaInicial.ToString("yyyy-MM-dd"), Convert.ToInt32(IdCaja));
            return tabla;

        }


        public DataTable BuscarMovimientosXRocRos(DateTime FechaInicial, string IdCaja)
        {

            CD_Arqueos objetoCD = new CD_Arqueos();
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarMovimientoXRocRos(FechaInicial.ToString("yyyy-MM-dd"), Convert.ToInt32(IdCaja));
            return tabla;

        }




        public DataTable BuscarMoviemientosGeneral(DateTime FechaActual, DateTime FechaFinal)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarMoviemientosGeneralCAJAS(FechaActual.ToString("yyyy-MM-dd"), FechaFinal.ToString("yyyy-MM-dd"));
            return tabla;
        }

        public DataTable BuscarMoviemientosGeneralxcaja(DateTime FechaActual, DateTime FechaFinal, string IdCaja)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarMoviemientosGeneralXCAJAS(FechaActual.ToString("yyyy-MM-dd"), FechaFinal.ToString("yyyy-MM-dd"), Convert.ToInt32(IdCaja));
            return tabla;
        }


        public DataTable BuscarExoneracionPorDepositos(DateTime FechaInicial, DateTime FechaFinal)
        {

            CD_Arqueos objetoCD = new CD_Arqueos();
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarExoneracionPorDepositos(FechaInicial.ToString("yyyy-MM-dd"), FechaFinal.ToString("yyyy-MM-dd"));
            return tabla;

        }

        public void ActualizarExoneracion(string IdExoneracion, DateTime FechaRevision, string HoraRevision, string Estado)
        {
            objetoCD.ActualizarMoraExonerada(Convert.ToInt32(IdExoneracion), FechaRevision.ToString("yyyy-MM-dd"), HoraRevision, Estado);
        }




    }
}
