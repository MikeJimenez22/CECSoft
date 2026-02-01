using CapaDatos;
using System.Data;


namespace CapaNegocio
{
    public class CN_ActualizacionDatos
    {
        CD_ActualizandoDatos objetoCD = new CD_ActualizandoDatos();

        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarDetallesPagoAbonado();
            return tabla;
        }

    }
}
