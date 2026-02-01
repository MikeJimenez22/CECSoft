using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Abonos
    {
        CD_Abonos objetoCD = new CD_Abonos();

        public void InsertarAbono(string FechaActual, string Monto, string IdMoneda, string IdUsuario, string IdDetalleProgramacion, string NumFactura, string IdEstado, string Observaciones, string NumProgramacion)
        {
            objetoCD.InsertarAbono(Convert.ToDateTime(FechaActual), Convert.ToDouble(Monto), Convert.ToInt32(IdMoneda), Convert.ToInt32(IdUsuario), Convert.ToInt32(IdDetalleProgramacion), NumFactura, Convert.ToInt32(IdEstado), Observaciones, NumProgramacion);
        }

        
        public DataTable Mostrar(string id)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar(Convert.ToInt32(id));
            return tabla;
        }


        public void AnularAbono(string IdAbono)
        {
            objetoCD.AnularAbono(Convert.ToInt32(IdAbono));
        }

        
    }
}
