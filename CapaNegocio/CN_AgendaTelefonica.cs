using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_AgendaTelefonica
    {
        CD_AgendaTelefonica objetoCD = new CD_AgendaTelefonica();


        public DataTable MostrarAgenda(string Id)
        {
            CD_AgendaTelefonica objetoCD = new CD_AgendaTelefonica();
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarAgenda(Id);
            return tabla;
        }



        public void Insertar(string Idpersona, string TipoMedio, string Compañia, string NumeroTelefonico)
        {
            objetoCD.Insertar(Convert.ToInt32(Idpersona), TipoMedio, Compañia, NumeroTelefonico);
        }



        public void Eliminar(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }



    }
}
