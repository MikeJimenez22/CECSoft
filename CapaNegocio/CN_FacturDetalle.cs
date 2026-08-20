using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_FacturDetalle
    {
        private CD_FacturaDetalle objetoCD = new CD_FacturaDetalle();

        public void InsertarDetalleFactura(string NumFactura, string IdArancel, string IdMoneda, string ValorMoneda, string TotalEnCordobas, string Cantidad, string IdEstado, string Monto, string Observaciones)
        {
            objetoCD.Insertar(NumFactura, Convert.ToInt32(IdArancel), Convert.ToInt32(IdMoneda), Convert.ToDouble(ValorMoneda), Convert.ToDouble(TotalEnCordobas), Convert.ToInt32(Cantidad), Convert.ToInt32(IdEstado), Convert.ToDouble(Monto), Observaciones);
        }


        public void Eliminar(string IdDetalleFactura)
        {
            objetoCD.Eliminar(Convert.ToInt32(IdDetalleFactura));
        }



        public DataTable MostraRocyRos(string NumeroFactura)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarRocYROS(NumeroFactura);
            return tabla;
        }


        public DataTable MostrarDetalleFactura(string NumFactura)
        {
            return objetoCD.MostrarDetalleFactura(NumFactura);
        }

    }
}
