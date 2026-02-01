using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Roles_Usuarios
    {
        private CD_Roles_Usuarios objetoCD = new CD_Roles_Usuarios();


        public void InsertarRolUsuario(string IdUsuario, string IdRol, string IdEstado)
        {
            objetoCD.Insertar(Convert.ToInt32(IdUsuario), Convert.ToInt32(IdRol), Convert.ToInt32(IdEstado));
        }

        public void ModificarEstadoRol_Usuario(string IdRolUsuario, string IdEstado)
        {
            objetoCD.ModificarEstado(Convert.ToInt32(IdRolUsuario), Convert.ToInt32(IdEstado));
        }

        

        public DataTable Mostrar(string IdEstado)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar(Convert.ToInt32(IdEstado));
            return tabla;
        }

        public DataTable VerificarSiExistenRoles(string Idusuario)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.VerificarSiExistenRolesActivo(Convert.ToInt32(Idusuario));
            return tabla;
        }




    }
}
