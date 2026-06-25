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
   public class CN_Dashboard
    {
        CD_Dashboard ObjetoCD = new CD_Dashboard();

        public DataTable MostrarDashboard()
        {
            DataTable tabla = new DataTable();
            tabla = ObjetoCD.MostraDashboard();
            return tabla;
        }

        public DataTable MostrarDashboardDiario()
        {
            DataTable tabla = new DataTable();
            tabla = ObjetoCD.MostraDashboardDiario();
            return tabla;
        }

        public DataTable UltimoBackup()
        {
            DataTable tabla = new DataTable();
            tabla = ObjetoCD.UltimoBackup();
            return tabla;
        }

        public DataTable ObtenerCarteraTurnoActual()
        {
            DataTable tabla = new DataTable();
            tabla = ObjetoCD.ObtenerCarteraTurnoActual();
            return tabla;
        }


        public DataTable AsistenciaGeneralDia()
        {
            DataTable tabla = new DataTable();
            tabla = ObjetoCD.AsistenciaGeneralDia();
            return tabla;
        }

    }
}
