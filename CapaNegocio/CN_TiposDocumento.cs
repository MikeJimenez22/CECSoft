using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_TiposDocumento
    {
        CD_TiposDocumentos ObjetoCD = new CD_TiposDocumentos();

        public DataTable ListarDocumento(string Buscar)
        {
            DataTable tabla = new DataTable();
            tabla = ObjetoCD.ListarDocumentos(Buscar);
            return tabla;
        }


        public void InsertarDocumento(string NombreDocumento,
                            string Prefijo)
        {
            ObjetoCD.InsertarDocumento(NombreDocumento,Prefijo);
        }

        public void EditarDocumento(string IdDocumento,string NombreDocumento,
                          string Prefijo)
        {
            ObjetoCD.EditarDocumento(Convert.ToInt32(IdDocumento),NombreDocumento, Prefijo);
        }

        public void ActualizarEstado(string IdDocumento)
        {
            ObjetoCD.ActualizarDocumento(Convert.ToInt32(IdDocumento));
        }


        public DataTable CargaTiposDocumentos()
        {
            DataTable tabla = new DataTable();
            tabla = ObjetoCD.CargarTiposDocumentos();
            return tabla;
        }

    }
}
