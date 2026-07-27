using CapaDatos;
using System;
using System.Data;


namespace CapaNegocio
{
    public class CN_CarterayCobro
    {
        CD_CarterayCobro ObjetoCD = new CD_CarterayCobro();

        public DataTable MostrarPorFechas(string FechaInicial, string fechafinal, string Estado, string Turno)
        {
            CD_CarterayCobro objetoCD = new CD_CarterayCobro();
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarPorFechas(Convert.ToDateTime(FechaInicial), Convert.ToDateTime(fechafinal), Estado, Turno);
            return tabla;

        }


        public DataTable MostrarCarteraGeneral(string FechaInicial, string fechafinal, string Estado)
        {
            CD_CarterayCobro objetoCD = new CD_CarterayCobro();
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarGeneral(Convert.ToDateTime(FechaInicial), Convert.ToDateTime(fechafinal), Estado);
            return tabla;

        }




        public DataTable MostrarListadoTelefonico(DateTime FechaInicial, DateTime FechaFinal, string Estado)
        {
            CD_CarterayCobro objetoCD = new CD_CarterayCobro();
            DataTable tabla = new DataTable();
            tabla = ObjetoCD.BuscarPorFechaListaCelulares(FechaInicial.ToString("yyyy-MM-dd"), FechaFinal.ToString("yyyy-MM-dd"), Estado);
            return tabla;
        }


        public DataTable MostrarCarteraEstadisticas(string FechaInicial, string fechafinal)
        {
            CD_CarterayCobro objetoCD = new CD_CarterayCobro();
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarCarteraGeneral(Convert.ToDateTime(FechaInicial), Convert.ToDateTime(fechafinal));
            return tabla;

        }

        public DataTable ConsultarCarteraAcademica(DateTime fechaInicial,
                                           DateTime fechaFinal,
                                           string estado,
                                           string turno)
        {
            CD_CarterayCobro objetoCD = new CD_CarterayCobro();

            return objetoCD.ConsultarCarteraAcademica(
                fechaInicial,
                fechaFinal,
                estado,
                turno);
        }



    }
}
