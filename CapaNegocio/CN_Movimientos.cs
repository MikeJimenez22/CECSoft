using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Movimientos
    {
        private CD_Movimiento objetoCD = new CD_Movimiento();



        public DataTable VerificarSiExisteReferencia(string Referencia)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.VerificarSIExisteReferencia(Referencia);
            return tabla;
        }



    }
}
