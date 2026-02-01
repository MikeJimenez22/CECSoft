using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class CN_Estados
    {
        CD_Estados objetoCD = new CD_Estados();

        public DataTable MostrarEstados()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarEstados();
            return tabla;
        }

    }
}
