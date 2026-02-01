using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Bajas
    {


        private CD_Bajas objetoCD = new CD_Bajas();



        public DataTable MostrarBajas(DateTime FechaInicial, DateTime fechafinal)
        {
            CD_Bajas objetoCD = new CD_Bajas();
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarBajas(FechaInicial.ToString("yyyy-MM-dd"), fechafinal.ToString("yyyy-MM-dd"));
            return tabla;
        }

        public void Insertar(string MotivoBaja, string Descripcion, string FechaBaja, string idMatricula, string IdUsuario, string NombrePC)
        {
            objetoCD.Insertar(MotivoBaja, Descripcion, Convert.ToDateTime(FechaBaja), Convert.ToInt32(idMatricula), Convert.ToInt32(IdUsuario), NombrePC);
        }

        public void DarBaja(string IdMatricula)
        {
            objetoCD.DardeBaja(Convert.ToInt32(IdMatricula));
        }






    }
}
