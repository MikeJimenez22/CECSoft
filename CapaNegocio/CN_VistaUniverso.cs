using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_VistaUniverso
    {
        CD_VistaUniverso objetoCD = new CD_VistaUniverso();

        public DataTable MostrarPorCarnet(string Carnet, string Idestado)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarPorCarnet(Carnet, Convert.ToInt32(Idestado));
            return tabla;
        }
        
        public DataTable MostrarPorCodMatricula(string Carnet, string Idestado)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarPorCodMatricula(Carnet, Convert.ToInt32(Idestado));
            return tabla;
        }
        
        public DataTable MostrarPorNombre(string Nombre, string Idestado)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarPorNombres(Nombre, Convert.ToInt32(Idestado));
            return tabla;
        }
        
        public DataTable MostrarPorApellidos(string Nombre, string Idestado)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarPorApellidos(Nombre,Convert.ToInt32(Idestado));
            return tabla;
        }


























        public DataTable CalcularCantidadActualUniverso()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.CantidadTotalUniverso();
            return tabla;
        }

        public DataTable CalcularCantidadActualUniversoHoy(DateTime fecha)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.CantidadTotalUniversoHoy(fecha.ToString("yyyy-MM-dd"));
            return tabla;
        }


        public DataTable MostrarUniversoPorDia(DateTime FechaInicial, DateTime fechafinal, string IdEstado)
        {
            CD_VistaUniverso objetoCD = new CD_VistaUniverso();
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarUniversoPorFecha(FechaInicial.ToString("yyyy-MM-dd"), fechafinal.ToString("yyyy-MM-dd"), Convert.ToInt32(IdEstado));
            return tabla;
        }


      


        public DataTable MostrarAltas(string IdMatricula)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarAltas(Convert.ToInt32(IdMatricula));
            return tabla;
        }

        public DataTable MostrarBajas(string IdMatricula)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarBajas(Convert.ToInt32(IdMatricula));
            return tabla;
        }


        public DataTable VERIFICARREGISTRO_MATRICULAS(DateTime fecha)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarSIEXISTE_REGISTROMATRICULA(fecha.ToString("yyyy-MM-dd"));
            return tabla;
        }


        public void InsertarREGISTROFECHA(DateTime Fecha, string total)
        {
            objetoCD.InsertarREGISTROFECHA(Fecha.ToString("yyyy-MM-dd"), Convert.ToInt32(total));
        }

        public void ActualizarREGISTROFECHA(DateTime Fecha, string total)
        {
            objetoCD.Actualizar_REGISTROFECHA(Fecha.ToString("yyyy-MM-dd"), Convert.ToInt32(total));
        }

        public DataTable GenerarExpediente(string CodigoMatricula)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.GenerarExpedienteEstudiantil(CodigoMatricula);
            return tabla;
        }

       
       


        public DataTable MostrarMatriculasPorCodigo(string CodigoMat)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.BuscarMatriculasPorCodigo(CodigoMat);
            return tabla;
        }

        public DataTable ObtenerFacturaInicio(string CodMatricula)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ObtenerFacturaRegistro(CodMatricula);
            return tabla;
        }



    }
}
