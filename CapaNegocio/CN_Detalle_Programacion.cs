using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Detalle_Programacion
    {
        CD_Detalle_Programacion objetoCD = new CD_Detalle_Programacion();


        public void Insertar(string NumProgramacion, string FechaProgramada, string concepto, string Monto, string IdMoneda, string FechaVencimiento, string Mora, string Estado)
        {
            objetoCD.Insertar(NumProgramacion, Convert.ToDateTime(FechaProgramada), concepto, Convert.ToDouble(Monto), Convert.ToInt32(IdMoneda), Convert.ToDateTime(FechaVencimiento), Convert.ToInt32(Mora), Convert.ToInt32(Estado));
        }

       

        public void CambiarFecha(DateTime Fecha, string IdDetalle)
        {
            objetoCD.CambiarFecha(Fecha.ToString("yyyy-MM-dd"), Convert.ToInt32(IdDetalle));
        }

     



        public DataTable BuscarDetallesPagos(string Num_Programacion)
        {
            CD_Detalle_Programacion objetoCD = new CD_Detalle_Programacion();
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarDetalles_de_Pagos(Num_Programacion);
            return tabla;
        }

      
        public void EliminarMora(string IdDetalleProgramacion)
        {
            objetoCD.EliminarMora(Convert.ToInt32(IdDetalleProgramacion));
        }

        public DataTable ObtenerPrimerDetalleProgramacion(string Num_Programacion)
        {
            CD_Detalle_Programacion objetoCD = new CD_Detalle_Programacion();
            DataTable tabla = new DataTable();
            tabla = objetoCD.ObtenerPrimerDetalleProgramacion(Num_Programacion);
            return tabla;
        }

     

        public void ActualizarMora(string Mora, string IdDetalleProgramacion)
        {
            objetoCD.ActualizarMora(Convert.ToInt32(Mora), Convert.ToInt32(IdDetalleProgramacion));
        }


        public void ActualizarHistorialPago(string CodMatricula,string IdMoneda,string Monto)
        {
            objetoCD.ActualizarHistorialPago(CodMatricula,Convert.ToInt32(IdMoneda),Convert.ToInt32(Monto));
        }

        public void ModificarMensualidad(string IdDetalleProgramacion,string Monto)
        {
            objetoCD.ModificarMensualidad(Convert.ToInt32(IdDetalleProgramacion),Convert.ToDecimal(Monto));
        }

    }
}
