namespace CaoaPresentacion
{
    public class CacheUsuario
    {

        static public string IdUsuario;
        static public string Estado;
        static public string Nombres;
        static public string Apellidos;
        static public string Carnet;
        static public string IdEmpleado;
        static public string Usuario;
        static public string FechaIngreso;
        static public string CodigoCarnet;
        static public string NombresCarnet;
        static public string ApellidosCarnet;
        static public string IdSucursal;
        static public string CodigoDeSesion;

        static public string NombreSucursal;
        static public string DireccionSucursal;

        static public string IdCaja;
        static public string Caja;

        static public string UserTextBox;
        static public string PassTextBox;

        static public string TipoUsuario;

        public void EliminarValores()
        {
            IdUsuario = string.Empty;
            Estado = string.Empty;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Carnet = string.Empty;
            IdEmpleado = string.Empty;
            Usuario = string.Empty;
            FechaIngreso = string.Empty;
        }


    }
}
