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

  

        public void Insertar(string Num_Factura, string FormaPago, double Subtotal, double Iva, double Total, int IdMoneda, int IdEstado, int IdUsuario, string NombreEquipo, DateTime FechaFacturacion, string NombreCompleto, string Carnet, string Nidentificacion)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_Insertar_FacturaGnral";
            comando.CommandType = CommandType.StoredProcedure;
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


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }


        public void ModificarDatos_Factura(string Nombre, string Carnet, string Nidentificacion, string Num_Factura)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ModificarDatos_Factura";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@NombreCompleto", Nombre);
            comando.Parameters.AddWithValue("@Carnet", Carnet);
            comando.Parameters.AddWithValue("@NIdentificacion", Nidentificacion);
            comando.Parameters.AddWithValue("@NFactura", Num_Factura);



            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

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
        


        public DataTable MostrarfACTURAScompletadasEstudiante(string Carnet)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select a.Num_Factura,a.Fecha_factura,b.Tipo_Pago,b.PagoCon,c.Descripcion,b.TotalEnCordobas,b.MontoTotal_a_Pagar,b.Cambio,d.Usuario  from Tbl_Factura_Gnral a join Tbl_Detalle_Pago b on a.Num_Factura = b.Num_Factura join Tbl_TipoMoneda c on c.IdMoneda = B.IdMoneda join Tbl_Usuarios d on d.Id_usuario = a.Id_Usuario  where a.CarnetEstudiantil = '" + Carnet + "' and a.Id_estado = '6' order by a.Id_Factura DESC ";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable MostrarfACTURASDetalle(string NumFactura)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select a.Num_Factura,B.Nombre_Arancel,c.Descripcion,a.Total_en_Cordobas,a.Cantidad,a.Monto,a.Observaciones from Factura_Detalle  a join Tbl_Aranceles b on a.Id_Arancel = B.Id_Arancel JOIN Tbl_TipoMoneda c on c.IdMoneda = b.IdMoneda WHERE a.Id_estado = '5' and Num_Factura = '" + NumFactura + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        /*****************************************************************************************************************************************************/
        //                                  GENERAR NUMERO DE FACTURA Y CONSECUTIVO CON RESPECTO A LA CAJA                                               //
      
        public DataTable BuscarPorFechasFacturas(string FechaInicial, string FechaFinal, int IdCaja)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec MostrarFacturascompletas '" + IdCaja + "','" + FechaInicial + "','" + FechaFinal + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

  
   



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





    }
}
