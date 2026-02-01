using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Padre_Tutor
    {

        private CD_Padre_Tutor objetoCD = new CD_Padre_Tutor();

        public DataTable Mostrar(string textobuscar)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar(textobuscar);
            return tabla;
        }

      


    }
}
