using CapaDatos;
using System;
using System.Data;


namespace CapaNegocio
{
    public class CN_CarterayCobro
    {
        CD_CarterayCobro ObjetoCD = new CD_CarterayCobro();

      
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
