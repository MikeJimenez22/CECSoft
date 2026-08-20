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

        

        public DataTable GenerarExpediente(string CodigoMatricula)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.GenerarExpedienteEstudiantil(CodigoMatricula);
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
