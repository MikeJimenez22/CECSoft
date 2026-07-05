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


        public DataTable MostrarHistorialGestion(int idProgramacionDetalle)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("MostrarHistorialGestionCobro", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdDetalleProgramacion", idProgramacionDetalle);


                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }


        public DataTable ValidarDuplicados(int idProgramacionDetalle)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_ValidarDuplicadosGestionCobro", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdDetalleProgramacion", idProgramacionDetalle);


                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

        public DataTable ObtenerUltimas5GestionesCobro()
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_Ultimas5GestionesCobro", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    


                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

        public DataTable BuscarGestionesPorRango(DateTime FechaInicio,DateTime FechaFinal)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_ReporteGestionesCobro", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", FechaFinal);


                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }


        public DataTable GestionesProgramadasHoy()
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_ReporteGestionesParaHoy", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;


                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

        public DataTable BuscarCarteraPorDetalle(int IdDetalleProgramacion)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("BuscarCarteraPorDetalle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id_Detalle_Programacion", IdDetalleProgramacion);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

    }
}
