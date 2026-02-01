using CapaDatos;
using System;



namespace CapaNegocio
{
    public class CN_Factura_Matricula
    {

        CD_Factura_Matriculas objetoCN = new CD_Factura_Matriculas();

        public void Insertar(DateTime FechaInicial, string FactMatricula, string FactFactura)
        {
            CD_Factura_Matriculas objetoCD = new CD_Factura_Matriculas();

            objetoCD.Insertar(FechaInicial.ToString("yyyy-MM-dd"), FactMatricula, FactFactura);


        }


    }
}
