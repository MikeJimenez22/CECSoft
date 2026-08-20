using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class CN_Moneda
    {

        private CD_Moneda objetoCD = new CD_Moneda();

        public void Editar(double Valor)
        {
            objetoCD.Editar(Valor);
        }

        

        public DataTable ValorMoneda()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarValorMoneda();
            return tabla;

        }

        public DataTable MostrarMonedas()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarMonedas();
            return tabla;

        }


    }
}
