using CapaDatos;


namespace CapaNegocio
{
    public class CN_ProcesosFactura
    {
        CD_ProcesosFactura ObjetoCD = new CD_ProcesosFactura();

        public void EjecutarProcesosFactura(string NumFactura)
        {
            ObjetoCD.EjecutarProcesos(NumFactura);
        }


    }
}
