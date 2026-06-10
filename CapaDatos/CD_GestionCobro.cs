using System.Data;
using System.Data.SqlClient;
using System;

namespace CapaDatos
{
   public class CD_GestionCobro
    {
        private CD_Conexion conexion = new CD_Conexion();

        public void InsertarGestionCobro(
          int idDetalleProgramacion,
          string tipoGestion,
          string resultado,
          string comentario,
          DateTime? fechaPromesaPago,
          DateTime? fechaProximaGestion,
          int idUsuario)
        {
            using (SqlCommand comando = new SqlCommand("SP_RegistrarGestionCobro", conexion.AbrirConexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id_Detalle_Programacion", idDetalleProgramacion);
                comando.Parameters.AddWithValue("@TipoGestion", tipoGestion);
                comando.Parameters.AddWithValue("@Resultado", resultado);
                comando.Parameters.AddWithValue("@Comentario", comentario);

                if (fechaPromesaPago.HasValue)
                    comando.Parameters.AddWithValue("@FechaPromesaPago", fechaPromesaPago.Value);
                else
                    comando.Parameters.AddWithValue("@FechaPromesaPago", DBNull.Value);

                if (fechaProximaGestion.HasValue)
                    comando.Parameters.AddWithValue("@FechaProximaGestion", fechaProximaGestion.Value);
                else
                    comando.Parameters.AddWithValue("@FechaProximaGestion", DBNull.Value);

                comando.Parameters.AddWithValue("@Id_usuario", idUsuario);

                comando.ExecuteNonQuery();
            }

            conexion.CerrarConexion();
        }

    }
}
