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
                            string Observaciones)
        {
            ObjetoCD.InsertarLibro(NombreLibro,Convert.ToInt32(Tomo),Observaciones);
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

    }
}
