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
    public class CN_Libros
    {
        CD_Libros ObjetoCD = new CD_Libros();

        public DataTable ListarLibros(string Buscar)
        {
            DataTable tabla = new DataTable();
            tabla = ObjetoCD.ListarLibrosRegistro(Buscar);
            return tabla;
        }


        public void InsertarlibroRegistro(string NombreLibro,
                            string Tomo,
                            string Observaciones,int IdTipoDocumento)
        {
            ObjetoCD.InsertarLibro(NombreLibro,Convert.ToInt32(Tomo),Observaciones,IdTipoDocumento);
        }


        public void AbrirLibro(string IdLibro)
        {
            ObjetoCD.AbrirLibro(Convert.ToInt32(IdLibro));
        }

        public void CerrarLibro(string IdLibro)
        {
            ObjetoCD.CerrarLibro(Convert.ToInt32(IdLibro));
        }

        public void EditarlibroRegistro(string IdLibro,string NombreLibro,
                          string Tomo,
                          string Observaciones)
        {
            ObjetoCD.EditarLibro(Convert.ToInt32(IdLibro),NombreLibro, Convert.ToInt32(Tomo), Observaciones);
        }

        public void AnularLibro(string IdLibro)
        {
            ObjetoCD.AnularLibro(Convert.ToInt32(IdLibro));
        }


        public DataTable CargarLibrosPorTipoDocumento(int IdTipoDocumento)
        {
            DataTable tabla = new DataTable();
            tabla = ObjetoCD.CargarLibrosPorTipoDocumento(IdTipoDocumento);
            return tabla;
        }

        public DataTable ObtenerSiguienteRegistro(int idLibro, int idTipoDocumento)
        {
            return ObjetoCD.ObtenerSiguienteRegistro(idLibro, idTipoDocumento);
        }

        public void InsertarRegistroAcademico(
     string CodigoDocumento,
     int IdTipoDocumento,
     int IdLibro,
     int Folio,
     DateTime FechaDocumento,
     int IdMatricula,
     string NumFactura,
     string NombreCompleto,
     string Cedula,
     string CodigoMatricula,
     string NombreCurso,
     string NombreSucursal,
     DateTime? FechaFinalizacionCurso,
     string Observaciones,
     int IdUsuario,
     out int IdRegistro,
     out int NumeroRegistro,
     out string CodigoDocumentoGenerado,
     out string NombreEstudiante,
     out int FolioGenerado,
     out DateTime FechaDocumentoGenerada,
     out string LibroTomo)
        {
            ObjetoCD.InsertarRegistroAcademico(
                CodigoDocumento,
                IdTipoDocumento,
                IdLibro,
                Folio,
                FechaDocumento,
                IdMatricula,
                NumFactura,
                NombreCompleto,
                Cedula,
                CodigoMatricula,
                NombreCurso,
                NombreSucursal,
                FechaFinalizacionCurso,
                Observaciones,
                IdUsuario,
                out IdRegistro,
                out NumeroRegistro,
                out CodigoDocumentoGenerado,
                out NombreEstudiante,
                out FolioGenerado,
                out FechaDocumentoGenerada,
                out LibroTomo);
        }


        public DataTable ConsultaGeneralRegistroAcademico(string tipoBusqueda, string valorBusqueda)
        {
            return ObjetoCD.ConsultaGeneralRegistroAcademico(tipoBusqueda, valorBusqueda);
        }

        public DataTable ConsultaPorLibroRegistro(int? IdLibro, int? Folio, DateTime? FechaDocumento)
        {
            return ObjetoCD.ConsultaPorLibroRegistro(
                IdLibro,
                Folio,
                FechaDocumento);
        }


        public DataTable CargarLibros()
        {
            DataTable tabla = new DataTable();
            tabla = ObjetoCD.CargarLibros();
            return tabla;
        }

        public void ActualizarRegistroAcademico(
    int IdRegistro,
    string NumFactura,
    string Observaciones)
        {
            ObjetoCD.ActualizarRegistroAcademico(
                IdRegistro,
                NumFactura,
                Observaciones);
        }

        public void AnularRegistroAcademico(
    int IdRegistro,
    string MotivoAnulacion,
    int IdUsuarioAnulacion)
        {
            ObjetoCD.AnularRegistroAcademico(
                IdRegistro,
                MotivoAnulacion,
                IdUsuarioAnulacion);
        }

    }
}
