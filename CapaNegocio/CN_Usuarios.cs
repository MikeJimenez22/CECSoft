using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Usuarios
    {
        private CD_Usuarios objetoCD = new CD_Usuarios();

        public DataTable Login(string usuario, string contraseña)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.login(usuario, contraseña);
            return tabla;

        }


        public DataTable BuscarCajaAsignada(string Idusuario)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarCajaAsignada(Convert.ToInt32(Idusuario));
            return tabla;

        }

     

        public DataTable VerificarEstado(string Estado)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.VerificarEstado(Convert.ToInt32(Estado));
            return tabla;
        }

        public DataTable VerificarUsuario(string Usuario)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarUsuarioExiste(Usuario);
            return tabla;
        }

       
        public DataTable MostrarUsuarios(string usuario)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarUsuarios(usuario);
            return tabla;
        }

      

        public void EliminarAsignacion(string IdCajaAsignacion)
        {
            objetoCD.EliminarAsignacion(Convert.ToInt32(IdCajaAsignacion));
        }

        

        public void Activar(string Iduser)
        {

            objetoCD.Activar(Convert.ToInt32(Iduser));
        }

        public void Inactivar(string IdUser)
        {
            objetoCD.Inactivar(Convert.ToInt32(IdUser));
        }

        public void InactivarUser(string User)
        {
            objetoCD.InactivarUser(User);
        }

        public void Insertar(string idempleado, string usuario, string contraseña, string fechaIngreso, string idestado, string cambios, string IdSucursal)
        {
            objetoCD.Insertar(Convert.ToInt32(idempleado), usuario, contraseña, Convert.ToDateTime(fechaIngreso), Convert.ToInt32(idestado), Convert.ToInt32(cambios), Convert.ToInt32(IdSucursal));

        }

        public void AsignacionCaja(string IdCaja, string IdUsuario, string IdEstado)
        {
            objetoCD.AsignacionCaja(Convert.ToInt32(IdCaja), Convert.ToInt32(IdUsuario), Convert.ToInt32(IdEstado));
        }

        public DataTable MostrarUsuarioCajas()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostraCajasUsuario();
            return tabla;
        }

        public void ActivarUsuaroCaja(string IdCajaUsuario)
        {
            objetoCD.ActivarCajaUser(Convert.ToInt32(IdCajaUsuario));
        }

        public void InactivarUsuaroCaja(string IdCajaUsuario)
        {
            objetoCD.InactivarCajaUser(Convert.ToInt32(IdCajaUsuario));
        }

        public DataTable ObtenerUsuariosPorEstado(string IdEstado)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ObtenerUsuarios(Convert.ToInt32(IdEstado));
            return tabla;
        }


        public DataTable ObtenerCajaUsuario(string IdUsuario)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ObtenerCajasUsuario(Convert.ToInt32(IdUsuario));
            return tabla;

        }



        public DataTable ObtenerRolUsuario(string IdUsuario)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ObtenerRolUsuario(Convert.ToInt32(IdUsuario));
            return tabla;

        }


        public void ActualizarContraseña(string Contraseña,string usuario)
        {
            objetoCD.ActualizarContraseña(Contraseña,usuario);
        }


        public string ObtenerNumCaja(string caja)
        {
            return objetoCD.ObtenerNumFactura(caja);
        }


    }
}
