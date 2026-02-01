using CapaDatos;
using System;
using System.Data;


namespace CapaNegocio
{
    public class CN_ClavesAprobacion
    {
        CD_Aprobacion objetoCD = new CD_Aprobacion();

        public void Insertar(string IdUsuario, string Clave, string IdEstado)
        {
            objetoCD.Insertar(Convert.ToInt32(IdUsuario), Clave, Convert.ToInt32(IdEstado));
        }


        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }


       

    }
}
