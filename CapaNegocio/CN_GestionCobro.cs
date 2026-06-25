using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_GestionCobro
    {
        CD_GestionCobro objetoCD = new CD_GestionCobro();

        public void InsertarGestionCobro(
            string IdDetalleProgramacion,
            string TipoGestion,
            string Resultado,
            string Comentario,
            string FechaPromesaPago,
            string FechaProximaGestion,
            string IdUsuario)
        {
            DateTime? fechaPromesa = string.IsNullOrWhiteSpace(FechaPromesaPago)
                ? (DateTime?)null
                : Convert.ToDateTime(FechaPromesaPago);

            DateTime? fechaProxima = string.IsNullOrWhiteSpace(FechaProximaGestion)
                ? (DateTime?)null
                : Convert.ToDateTime(FechaProximaGestion);

            objetoCD.InsertarGestionCobro(
                Convert.ToInt32(IdDetalleProgramacion),
                TipoGestion,
                Resultado,
                Comentario,
                fechaPromesa,
                fechaProxima,
                Convert.ToInt32(IdUsuario)
            );
        }

        public DataTable MostrarHistorialGestion(int IdDetalleProgramacion)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarHistorialGestion(IdDetalleProgramacion);
            return tabla;
        }

        public DataTable ValidarDuplicados(int IdDetalleProgramacion)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ValidarDuplicados(IdDetalleProgramacion);
            return tabla;
        }

        public DataTable ObtenerUltimas5GestionesCobro()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ObtenerUltimas5GestionesCobro();
            return tabla;
        }

        public DataTable BuscarGestionesPorRango(string FechaInicio,string FechaFinal)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarGestionesPorRango(Convert.ToDateTime(FechaInicio),Convert.ToDateTime(FechaFinal));
            return tabla;
        }


    }
}
