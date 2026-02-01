using CapaDatos;
using System;

namespace CapaNegocio
{
    public class CN_Impresiones
    {
        CD_Impresiones objetoCD = new CD_Impresiones();

        public void InsertarRegistroImpresiones(string FechaImpresiones, string HoraImpresion, string IdUsuario, string NumFactura, string TipoImpresion, string Descripcion, string IpComputadora, string NombreComputadora)
        {
            objetoCD.InsertarRegistroImpresiones(Convert.ToDateTime(FechaImpresiones), HoraImpresion, Convert.ToInt32(IdUsuario), NumFactura, TipoImpresion, TipoImpresion, IpComputadora, NombreComputadora);

        }


    }
}
