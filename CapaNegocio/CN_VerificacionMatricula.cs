using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class CN_VerificacionMatricula
    {
        CD_VerificacionMatricula objetoCD = new CD_VerificacionMatricula();


        public DataTable VerificacionSiCanceloMatricula(string CarnetEstudiante)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.VerificarSiTieneMatriculaCANCELADA(CarnetEstudiante);
            return tabla;
        }

     

    }
}
