using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Rol_Formularios
    {
        private CD_Rol_Formularios objetoCD = new CD_Rol_Formularios();

        public void InsertarRolFormulario(string IdRol, string IdFormulario)
        {
            objetoCD.Insertar(Convert.ToInt32(IdRol), Convert.ToInt32(IdFormulario));
        }

        public void ModificarRolFormulario(string IdRolFormulario, string Estado)
        {
            objetoCD.ModificarEstado(Convert.ToInt32(IdRolFormulario), Convert.ToInt32(Estado));
        }


        public DataTable Mostrar_FormulariosxRol(string TextoBuscar)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar_FormulariosxRol(TextoBuscar);
            return tabla;
        }

        public DataTable Mostrar_FormulariosxRol_Estado(string TextoBuscar)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar_FormulariosxRol_Estado(TextoBuscar);
            return tabla;
        }


    }
}
