using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_ConexionesUsuarios
    {
        CD_ConexionesUsuarios objeto = new CD_ConexionesUsuarios();

        public void InsertarConexionesUsuarios(string CodConexion, string FechaIngreso, string HoraIngreso, string NombrePC, string IpComputadora, string IdUsuario)
        {
            objeto.InsertarConexion(CodConexion, Convert.ToDateTime(FechaIngreso), Convert.ToDateTime(HoraIngreso), NombrePC, IpComputadora, Convert.ToInt32(IdUsuario));
        }

        public DataTable MostrarConexionesUsuarios(string Usuario)
        {
            DataTable tabla = new DataTable();
            tabla = objeto.MostrarConexionPorUsuario(Usuario);
            return tabla;
        }

        public void DesconectarConexion(string FechaSalida, string HoraSalida, string CodigoConexion)
        {
            objeto.DesconectarSesion(Convert.ToDateTime(FechaSalida), Convert.ToDateTime(HoraSalida), CodigoConexion);
        }

        public void ActualizarConexiones(string IdUsuario)
        {
            objeto.ActualizarConexionesUsuario(Convert.ToInt32(IdUsuario));
        }

        public DataTable MostrarIdUsuario(string Usuario)
        {
            DataTable tabla = new DataTable();
            tabla = objeto.MostrarIdUsuario(Usuario);
            return tabla;
        }

    }
}
