using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
   public class CN_FacturaMensualidades
    {
        CD_FacturaMensualidades objetoCD = new CD_FacturaMensualidades();



        public void InsertarFacturaMensualidades(string NumFactura,string IdDetalleProgramacion,string Concepto)
        {
            objetoCD.InsertarFacturaMensualidad(NumFactura,Convert.ToInt32(IdDetalleProgramacion),Concepto);
        }

    }
}
