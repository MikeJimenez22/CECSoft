using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class CN_Horarios
    {
        private CD_Horarios objetoCN = new CD_Horarios();

        public DataTable MostrarHorariosPorTurno(string Turno)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCN.MostrarHorarios(Turno);
            return tabla;
        }
    }
}
