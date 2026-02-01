using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Roles
    {
        private CD_Roles objetoCD = new CD_Roles();

        public DataTable Mostrar(string IdEstado)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarRolesPorEstado(Convert.ToInt32(IdEstado));
            return tabla;
        }

        public DataTable BuscarSiExisteRol(string TextoBuscar)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarSisExisteRol(TextoBuscar);
            return tabla;
        }

        public DataTable BuscarIdRol(string TextoBuscar)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarIdRol(TextoBuscar);
            return tabla;
        }


        public void Insertar(string Descripcion, string Estado)
        {
            objetoCD.Insertar(Descripcion, Convert.ToInt32(Estado));
        }


        public void ModificarEstado(string Codigo, string Estado)
        {
            objetoCD.ModificarEstado(Convert.ToInt32(Codigo), Convert.ToInt32(Estado));
        }



    }
}
