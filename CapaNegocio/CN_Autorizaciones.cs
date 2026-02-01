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
    public class CN_Autorizaciones
    {

        private CD_Autorizaciones objetoCD = new CD_Autorizaciones();

        public DataTable ConsultarAutorizacion(string Codigo)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ConsultarAutorizacion(Codigo);
            return tabla;
        }

        public void Insertar(string Fecha,string Motivo,string Codigo,string Autorizado,string IdUsuario)
        {
            objetoCD.Insertar(Convert.ToDateTime(Fecha),Motivo,Codigo,Autorizado,Convert.ToInt32(IdUsuario));
        }
    }
}
