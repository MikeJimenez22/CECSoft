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
    public class CN_Asistencia
    {
        CD_AsistenciaEstudiantil objetoCD = new CD_AsistenciaEstudiantil();

        public void InsertarAsistencia(string Fecha, string IdEmpleado, string HoraRegistro, string IdSeccion, string CodigoAsistencia, string Observaciones,string Horario)
        {
            objetoCD.InsertarAsistencia(Convert.ToDateTime(Fecha), Convert.ToInt32(IdEmpleado), HoraRegistro, Convert.ToInt32(IdSeccion), CodigoAsistencia, Observaciones,Horario);
        }

        public DataTable Mostrar(string CodigoAsistencia)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar(CodigoAsistencia);
            return tabla;
        }


        public DataTable MostrarAsistenciaPorFecha(DateTime Fecha)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarAsistenciaPorFecha(Fecha.ToString("yyyy-MM-dd"));
            return tabla;
        }



        public void InsertarAsistenciaEstudiante(string IdMatricula,string CodigoAsistencia,string Estado,string Observaciones)
        {
            objetoCD.InsertarAsistenciaEstudiante(Convert.ToInt32(IdMatricula),CodigoAsistencia,Estado,Observaciones);
        }


    }
}
    