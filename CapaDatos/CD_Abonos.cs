using System.Data;
using System.Data.SqlClient;
using System;

namespace CapaDatos
{
    public class CD_Abonos
    {
        private CD_Conexion conexion = new CD_Conexion();

        public void InsertarAbono(DateTime fecha, double monto, int idMoneda, int idUsuario, int idDetalleProgramacion, string numFactura, int idEstado, string observaciones, string numProgramacion)
        {
            using (SqlCommand comando = new SqlCommand("InsertarAbonos", conexion.AbrirConexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Fecha", fecha);
                comando.Parameters.AddWithValue("@Monto", monto);
                comando.Parameters.AddWithValue("@IdMoneda", idMoneda);
                comando.Parameters.AddWithValue("@IdUsuario", idUsuario);
                comando.Parameters.AddWithValue("@IdDetalleProgramacion", idDetalleProgramacion);
                comando.Parameters.AddWithValue("@NumFactura", numFactura);
                comando.Parameters.AddWithValue("@IdEstado", idEstado);
                comando.Parameters.AddWithValue("@Observaciones", observaciones);
                comando.Parameters.AddWithValue("@NumProgramacion", numProgramacion);
                comando.ExecuteNonQuery();
            }
            conexion.CerrarConexion();
        }

    

        public DataTable Mostrar(int idProgramacionDetalle)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("MostrarAbonos", connection))
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



        public void ActualizarAbonoCompletado(string facturaActual, string facturaActualizada)
        {
            using (SqlCommand comando = new SqlCommand("ActualizarAbonoCompletado", conexion.AbrirConexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@NumFacturaAnt", facturaActual);
                comando.Parameters.AddWithValue("@NumFacturaAct", facturaActualizada);
                comando.ExecuteNonQuery();
            }
            conexion.CerrarConexion();
        }

        public void AnularAbono(int idAbono)
        {
            using (SqlCommand comando = new SqlCommand("AnularAbono", conexion.AbrirConexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdAbono", idAbono);
                comando.ExecuteNonQuery();
            }
            conexion.CerrarConexion();
        }
    }
}
