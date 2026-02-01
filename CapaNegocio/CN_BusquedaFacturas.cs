using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class CN_BusquedaFacturas
    {
        CD_BusquedaFacturas objetoCD = new CD_BusquedaFacturas();

        public DataTable Mostrar(string NumFactura)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarFactura(NumFactura);
            return tabla;
        }



        public DataTable MostrarDetalleFactura(string NumFactura)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarFacturaDetalle(NumFactura);
            return tabla;
        }


    }
}
