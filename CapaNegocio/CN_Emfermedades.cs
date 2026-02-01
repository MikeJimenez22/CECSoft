using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Emfermedades
    {

        CD_Emfermedades objetoCD = new CD_Emfermedades();
        
        public DataTable MostrarEnfermedad(string TextoBuscar)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarEnfermedades(TextoBuscar);
            return tabla;

        }

        public void Insertar(string Idpersona, string IdEnfermedades)
        {
            objetoCD.Insertar(Convert.ToInt32(Idpersona), Convert.ToInt32(IdEnfermedades));
        }

      

        public void Eliminar(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }


        public DataTable MostrarEnfermedadesPorPersona(string IdPersona)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarEnfermedadesPorPersona(Convert.ToInt32(IdPersona));
            return tabla;

        }


    }
}
