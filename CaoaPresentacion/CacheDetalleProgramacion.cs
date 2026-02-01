namespace CaoaPresentacion
{
    public class CacheDetalleProgramacion
    {

        //Variables por la Cual le pasamos los  Valores si es un Pago Completo de Mensualidad
        static public string CodigoFacturacion;
        static public string IdArancel;
        static public string IdMoneda;
        static public string ValorMoneda;
        static public string TotalPago;
        static public string Cantidad;
        static public string IdEstado;
        static public string Monto;


        static public bool Contador;

        //Variables por la Cual le pasamos los  Valores si es un Pago por Abono de Mensualidad

        static public string CodigoFacturacionAbono;
        static public string IdArancelAbono;
        static public string IdMonedaAbono;
        static public string ValorMonedaAbono;
        static public string TotalPagoAbono;
        static public string CantidadAbono;
        static public string IdEstadoAbono;
        static public string MontoAbono;

        static public bool Contador2;



        ///////////////////////////////////////////////////////////


        static public string CodigoFacturacionLibreria;
        static public string IdArancelLibreria;
        static public string IdMonedaLibreria;
        static public string ValorMonedaLibreria;
        static public string TotalPagoLibreria;
        static public string CantidadLibreria;
        static public string IdEstadoLibreria;
        static public string MontoLibreria;
        static public string ObservacionLibreria;

        static public bool ContadorLibreria;


        //Variables por la Cual le pasamos los  Valores si es un Descuento en Mensualidad

        static public string CodigoFacturacionDescuento;
        static public string IdArancelDescuento;
        static public string IdMonedaDescuento;
        static public string ValorMonedaDescuento;
        static public string TotalPagoDescuento;
        static public string CantidadDescuento;
        static public string IdEstadoDescuento;
        static public string MontoDescuento;

        static public bool Contador3;


        //Aqui pasamos los datps del Curso

        static public string NombreCurso;
        static public string Dias;
        static public string Horario;

        static public bool Contador4;






        public void LimpiarDatosDetalle()
        {
            CacheDetalleProgramacion.CodigoFacturacion = string.Empty;
            CacheDetalleProgramacion.IdArancel = string.Empty;
            CacheDetalleProgramacion.IdMoneda = string.Empty;
            CacheDetalleProgramacion.ValorMoneda = string.Empty;
            CacheDetalleProgramacion.TotalPago = string.Empty;
            CacheDetalleProgramacion.Cantidad = string.Empty;
            CacheDetalleProgramacion.IdEstado = string.Empty;
            CacheDetalleProgramacion.Monto = string.Empty;

        }

    }
}
