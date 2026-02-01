using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Aranceles
    {
        private CD_Aranceles objetoCD = new CD_Aranceles();

        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public void InsertarArancel(string NombreArancel, string Precio, string IdMoneda, string IdEstado, string Tipo)
        {
            objetoCD.Insertar(NombreArancel, Convert.ToDouble(Precio), Convert.ToInt32(IdMoneda), Convert.ToInt32(IdEstado), Tipo);
        }

        public void EditarArancel(string Idarancel, string NombreArancel, string Precio, string IdMoneda, string IdEstado, string Tipo)
        {
            objetoCD.Editar(Convert.ToInt32(Idarancel), NombreArancel, Convert.ToDouble(Precio), Convert.ToInt32(IdMoneda), Convert.ToInt32(IdEstado), Tipo);
        }


        public DataTable MostrarInformacionArancel(string IdArancel)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarInformacionArancel(Convert.ToInt32(IdArancel));
            return tabla;
        }



    }
}
