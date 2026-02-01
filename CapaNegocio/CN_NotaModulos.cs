using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_NotaModulos
    {

        private CD_NotasModular objetoCD = new CD_NotasModular();

       

        public void InsertarActaNota(string CodigoActa,string FechaRegistro,string HoraRegistro,string IdUsuario,string IpComputadora,string NombrePC,string Docente,string Observaciones)
        {
            objetoCD.InsertarActaNota(CodigoActa,Convert.ToDateTime(FechaRegistro),Convert.ToDateTime(HoraRegistro),Convert.ToInt32(IdUsuario),IpComputadora,NombrePC,Docente,Observaciones);
        }

        public void InsertarNotasEstudiante(string IdMatricula, string Modulo, string Curso, string Nota, string fechaRegistro, string HoraRegistro, string Observaciones, string CodigoActa, string Estado)
        {
            objetoCD.InsertarNotasEstudiante(Convert.ToInt32(IdMatricula),Modulo,Curso,Convert.ToInt32(Nota),Convert.ToDateTime(fechaRegistro),Convert.ToDateTime(HoraRegistro),Observaciones,CodigoActa,Estado);
        }

        public DataTable MostrarNotaEstudiante(string IdMatricula)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarNotasEstudante(Convert.ToInt32(IdMatricula));
            return tabla;
        }





    }
}
