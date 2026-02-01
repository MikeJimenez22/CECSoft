using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_egreso
    {
        private CD_Egresos objetoCD = new CD_Egresos();

        public void Insertar(string Num_Egreso, string Monto, string IdMoneda, string Descripcion, string IdUsuario, string Equipo, DateTime Fecha, string Hora)
        {
            objetoCD.Insertar(Num_Egreso, Convert.ToDouble(Monto), Convert.ToInt32(IdMoneda), Descripcion, Convert.ToInt32(IdUsuario), Equipo, Fecha.ToString("yyyy-MM-dd"), Convert.ToDateTime(Hora));
        }

        public DataTable ObtenerNEgreso()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ObtenerCodEgreso();
            return tabla;
        }

        public void AnularEgreso(string Num_Egreso)
        {
            objetoCD.AnularEgreso(Num_Egreso);
        }


    }
}
