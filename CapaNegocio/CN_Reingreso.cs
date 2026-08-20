using CapaDatos;
using System;

namespace CapaNegocio
{
    public class CN_Reingreso
    {
        CD_Reingresos objetoCD = new CD_Reingresos();


        public void InsertarReingreso(string FechaReingreso, string IdMatricula, string IdUsuario, string NombrePC)
        {
            objetoCD.InsertarReingreso(Convert.ToDateTime(FechaReingreso), Convert.ToInt32(IdMatricula), Convert.ToInt32(IdUsuario), NombrePC);
        }

        public void ActivarEstudiante(string IdMatricula)
        {
            objetoCD.AtivarEstudiante(Convert.ToInt32(IdMatricula));
        }

    }
}
