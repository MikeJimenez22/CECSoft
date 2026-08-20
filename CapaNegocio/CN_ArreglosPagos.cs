using CapaDatos;
using System;
using System.Data;


namespace CapaNegocio
{
    public class CN_ArreglosPagos
    {
        private CD_Arreglos objetoCD = new CD_Arreglos();

        public void Insertar(string NumArreglo, DateTime Fecha, string NumProgramacion, string FechaProximaPago, string Observacion, string Autorizado, DateTime FechaAutorizado, string IdUsuario, string NameEquipo, string IdESTADO)
        {
            objetoCD.Insertar(NumArreglo, Fecha.ToString("yyyy-MM-dd"), NumProgramacion, FechaProximaPago, Observacion, Autorizado, FechaAutorizado.ToString("yyyy-MM-dd"), Convert.ToInt32(IdUsuario), NameEquipo, Convert.ToInt32(IdESTADO));
        }



        public DataTable ObtenerNumArreglo()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ObtenerNumArreglo();
            return tabla;
        }


        public DataTable MostrarSolicitudesPendientes()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarSolicitudes();
            return tabla;
        }

        public void ActualizarAutorizado(string IdArreglo)
        {
            objetoCD.EditarEstado(Convert.ToInt32(IdArreglo));
        }

        public void DenegarSolicitud(string IdArreglo)
        {
            objetoCD.DenegegarSolicitud(Convert.ToInt32(IdArreglo));
        }

        
    }
}
