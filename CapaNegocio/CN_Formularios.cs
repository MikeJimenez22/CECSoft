using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class CN_Formularios
    {
        private CD_Formularios objetoCD = new CD_Formularios();

        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarFormularios();
            return tabla;
        }
        
    }
}
