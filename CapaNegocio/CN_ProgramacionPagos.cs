using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_ProgramacionPagos
    {

        private CD_ProgramaionPagos objetoCD = new CD_ProgramaionPagos();

        public void Insertar(string NumProgramacion, string CodigoMatricula, string IdArancel, string DiasPago, string TotalMonto, string IdMoneda, string DiaVencimiento, string Mora, string IdEstado, string Saldo)
        {
            objetoCD.Insertar(NumProgramacion, CodigoMatricula, Convert.ToInt32(IdArancel), Convert.ToInt32(DiasPago), Convert.ToDouble(TotalMonto), Convert.ToInt32(IdMoneda), Convert.ToInt32(DiaVencimiento), Convert.ToInt32(Mora), Convert.ToInt32(IdEstado), Convert.ToDouble(Saldo));
        }


        public DataTable MostrarNumeroProgramacion()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.ObtenerNumeroProgramacion();
            return tabla;
        }

        
    }
}
