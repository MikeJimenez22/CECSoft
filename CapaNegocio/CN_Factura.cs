using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Factura
    {
        private CD_Factura objetoCD = new CD_Factura();

        public void Insertar(string NumFactura, string FormaPago, string subtotal, string Iva, string Total, string Idmoneda, string IdEstado,string IdUsuario, string NombreEquipo, string fechaFactura, string NombreCompleto, string Carnet, string Nidentificacion)
        {
            objetoCD.Insertar(NumFactura, FormaPago, Convert.ToDouble(subtotal), Convert.ToDouble(Iva), Convert.ToDouble(Total), Convert.ToInt32(Idmoneda), Convert.ToInt32(IdEstado), Convert.ToInt32(IdUsuario), NombreEquipo,Convert.ToDateTime(fechaFactura), NombreCompleto, Carnet, Nidentificacion);
        }
        
        public void ModificarDatos_Factura(string NombreCompleto, string Carnet, string NIdentificacion, string Num_Factura)
        {
            objetoCD.ModificarDatos_Factura(NombreCompleto, Carnet, NIdentificacion, Num_Factura);
        }

        public DataTable MostrarFacturasCompletadasestudiante(string Carnet)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarfACTURAScompletadasEstudiante(Carnet);
            return tabla;
        }

        public DataTable MostrarFacturaDetalle(string NumFactura)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarfACTURASDetalle(NumFactura);
            return tabla;
        }


        /*****************************************************************************************************************************************************/
        //                                  GENERAR NUMERO DE FACTURA Y CONSECUTIVO CON RESPECTO A LA CAJA                                               //
      

        public DataTable MostrarPorFechasFacturas(DateTime FechaInicial, DateTime fechafinal, string IdCaja)
        {
            CD_Factura objetoCD = new CD_Factura();
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarPorFechasFacturas(FechaInicial.ToString("yyyy-MM-dd"), fechafinal.ToString("yyyy-MM-dd"), Convert.ToInt32(IdCaja));
            return tabla;

        }




        public void InsertarDetallePago(string NumFactura, string TipoPago, string PagoCon, string IdMoneda, string ValorMoneda, string TotalEnCordobas, string MontoApagar, string cambio, string NumReferencia)
        {
            objetoCD.InsertarPagoDetalle(NumFactura, TipoPago, Convert.ToDouble(PagoCon), Convert.ToInt32(IdMoneda), Convert.ToDouble(ValorMoneda), Convert.ToDouble(TotalEnCordobas), Convert.ToDouble(MontoApagar), Convert.ToDouble(cambio), NumReferencia);
        }

        public void InsertarMovimientoCaja(string TipoDocumento, string NumDocumento, string TipoMovimiento, string Cantidad, string IdMoneda, string FechaRegistro, string IdUsuario, string IdCaja, string HorayFecha)
        {
            objetoCD.InsertarMovimientoCaja(TipoDocumento, NumDocumento, TipoMovimiento, Convert.ToDouble(Cantidad), Convert.ToInt32(IdMoneda), Convert.ToDateTime(FechaRegistro), Convert.ToInt32(IdUsuario), Convert.ToInt32(IdCaja), HorayFecha);
        }

        public void ModificarEstadoEnProceso(string IdDetalleProgramacion)
        {
            objetoCD.CambiarEstadoEnProceso(Convert.ToInt32(IdDetalleProgramacion));
        }


        public void ModificarEstadoaCompletado(string IdDetalleProgramacion)
        {
            objetoCD.CambiarEstadoaCompletado(Convert.ToInt32(IdDetalleProgramacion));
        }


        public void ModificarEstadoaPendiente(string IdDetalleProgramacion)
        {
            objetoCD.CambiarEstadoaPendiente(Convert.ToInt32(IdDetalleProgramacion));
        }








    }
}
