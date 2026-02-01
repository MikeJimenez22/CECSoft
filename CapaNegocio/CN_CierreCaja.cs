using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_CierreCaja
    {
        DCierreCaja objetoCD = new DCierreCaja();



        public DataTable ObtenerCierreCaja()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ObtenerCierreCaja();
            return tabla;
        }



    }
}
