using System.Data;
using System.Data.SqlClient;
using System;


namespace CapaDatos
{
    public class CD_Factura
    {

        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();



        public void Insertar(
     string Num_Factura,
     string FormaPago,
     double Subtotal,
     double Iva,
     double Total,
     int IdMoneda,
     int IdEstado,
     int IdUsuario,
     string NombreEquipo,
     DateTime FechaFacturacion,
     string NombreCompleto,
     string Carnet,
     string Nidentificacion,
     int? IdMatricula)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_Insertar_FacturaGnral";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Clear();

            comando.Parameters.AddWithValue("@Num_Factura", Num_Factura);
            comando.Parameters.AddWithValue("@Forma_Pago", FormaPago);
            comando.Parameters.AddWithValue("@SubTotal", Subtotal);
            comando.Parameters.AddWithValue("@Iva", Iva);
            comando.Parameters.AddWithValue("@Total", Total);
            comando.Parameters.AddWithValue("@IdMoneda", IdMoneda);
            comando.Parameters.AddWithValue("@Id_estado", IdEstado);
            comando.Parameters.AddWithValue("@Id_Usuario", IdUsuario);
            comando.Parameters.AddWithValue("@NombreEquipo", NombreEquipo);
            comando.Parameters.AddWithValue("@Fecha_factura", FechaFacturacion);
            comando.Parameters.AddWithValue("@Nombre_Completo", NombreCompleto);
            comando.Parameters.AddWithValue("@CarnetEstudiantil", Carnet);
            comando.Parameters.AddWithValue("@NIdentificacion", Nidentificacion);

            // Si existe matrícula envía el ID.
            // Si no existe, envía NULL a SQL Server.
            comando.Parameters.AddWithValue(
                "@Id_Matricula",
                IdMatricula.HasValue
                    ? (object)IdMatricula.Value
                    : DBNull.Value
            );

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }







        public void InsertarPagoDetalle(string NumeroFactura, string TipoPago, double PagoCon, int IdMoneda, double ValorMoneda, double TotalCordobas, double MontoPagar, double cambio, string NumeroReferencia)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarDetalleFacturaPago";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@numFactura", NumeroFactura);
            comando.Parameters.AddWithValue("@tipoPago", TipoPago);
            comando.Parameters.AddWithValue("@pagoCon", PagoCon);
            comando.Parameters.AddWithValue("@IdMoneda", IdMoneda);
            comando.Parameters.AddWithValue("@valorMoneda", ValorMoneda);
            comando.Parameters.AddWithValue("@TotalCordobas", TotalCordobas);
            comando.Parameters.AddWithValue("@MontoApagar", MontoPagar);
            comando.Parameters.AddWithValue("@Cambio", cambio);
            comando.Parameters.AddWithValue("@Nreferencia", NumeroReferencia);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }
        


       

        public DataTable MostrarFacturasEstudiante(string CarnetEstudiantil, int? IdMatricula)
        {
            DataTable tabla = new DataTable();

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_ObtenerFacturasEstudiante";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Clear();

            comando.Parameters.AddWithValue(
                "@CarnetEstudiantil",
                string.IsNullOrWhiteSpace(CarnetEstudiantil)
                    ? (object)DBNull.Value
                    : CarnetEstudiantil
            );

            comando.Parameters.AddWithValue(
                "@Id_Matricula",
                IdMatricula.HasValue
                    ? (object)IdMatricula.Value
                    : DBNull.Value
            );

            leer = comando.ExecuteReader();

            tabla.Load(leer);

            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return tabla;
        }

      
        /*****************************************************************************************************************************************************/
        //                                  GENERAR NUMERO DE FACTURA Y CONSECUTIVO CON RESPECTO A LA CAJA                                               //
      
        public void InsertarMovimientoCaja(string TipoDocumento, string NumDocumento, string TipoMoviento, double Cantidad, int IdMoneda, DateTime FechaRegistro, int IdUsuario, int IdCaja, string HorayFecha)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Insertar_Movimiento";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@TipoDocumento", TipoDocumento);
            comando.Parameters.AddWithValue("@NumDocumento", NumDocumento);
            comando.Parameters.AddWithValue("@TipoMovimiento", TipoMoviento);
            comando.Parameters.AddWithValue("@Cantidad", Cantidad);
            comando.Parameters.AddWithValue("@IdMoneda", IdMoneda);
            comando.Parameters.AddWithValue("@FechaRegistro", FechaRegistro);
            comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            comando.Parameters.AddWithValue("@IdCaja", IdCaja);
            comando.Parameters.AddWithValue("@HorayFecha", HorayFecha);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }


        public void CambiarEstadoEnProceso(int codigo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MODIFICAR_ESTADO_ENPROCESO";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdDetalleProgramacion", codigo);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void CambiarEstadoaCompletado(int codigo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MODIFICAR_ESTADO_PROGRAMACIONDETALLE";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdDetalleProgramacion", codigo);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }



        public void CambiarEstadoaPendiente(int codigo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MODIFICAR_ESTADO_PENDIENTE";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdDetalleProgramacion", codigo);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }




        public DataTable MostrarPagosEstudiante(string CodMatricula)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_MostrarPagosEstudiante", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodMatricula", CodMatricula);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }


        public DataSet ObtenerFacturasPorFechaYCaja(
        DateTime FechaDesde,
        DateTime FechaHasta,
        int IdCaja)
        {
            DataSet ds = new DataSet();

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_ObtenerFacturasPorFechaYCaja";
            comando.CommandType = CommandType.StoredProcedure;

            comando.CommandTimeout = 120;

            comando.Parameters.Clear();

            comando.Parameters.Add("@FechaDesde", SqlDbType.Date).Value = FechaDesde.Date;
            comando.Parameters.Add("@FechaHasta", SqlDbType.Date).Value = FechaHasta.Date;
            comando.Parameters.Add("@IdCaja", SqlDbType.Int).Value = IdCaja;

            SqlDataAdapter adaptador = new SqlDataAdapter(comando);

            adaptador.Fill(ds);

            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return ds;
        }




    }
}
