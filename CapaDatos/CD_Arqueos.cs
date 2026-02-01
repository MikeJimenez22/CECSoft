using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Arqueos
    {


        public CD_Conexion conexion = new CD_Conexion();
        //SqlDataReader leer;
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public void Insertar(int IdCaja, double Cantidad, int IdMoneda, int IdUsuario, string Fecha, DateTime Hora)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarArqueo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCaja", IdCaja);
            comando.Parameters.AddWithValue("@Cantidad", Cantidad);
            comando.Parameters.AddWithValue("@IdMoneda", IdMoneda);
            comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            comando.Parameters.AddWithValue("@Fecha", Fecha);
            comando.Parameters.AddWithValue("@Hora", Hora);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }


        public DataTable BuscarMovimientos(string Fecha, int IdCAJA)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec BuscarMovimientos '" + Fecha + "','" + IdCAJA + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        public DataTable BuscarMovimientosTodasLasCajas(string Fecha)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec BuscarPagosTodasLasCajas '" + Fecha + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable BuscarMovimientosrocyros(string Fecha, int IdCAJA)
        {
            // Abrir la conexión
            comando.Connection = conexion.AbrirConexion();

            // Establecer el tipo de comando como StoredProcedure
            comando.CommandType = CommandType.StoredProcedure;

            // Establecer el nombre del procedimiento almacenado
            comando.CommandText = "sp_ObtenerFacturasCanceladas";

            // Limpiar los parámetros previos
            comando.Parameters.Clear();

            // Agregar los parámetros necesarios para el procedimiento almacenado
            comando.Parameters.AddWithValue("@Fecha", Fecha);  // Parámetro Fecha
            comando.Parameters.AddWithValue("@IdCaja", IdCAJA); // Parámetro IdCaja

            // Ejecutar el comando y leer los resultados
            leer = comando.ExecuteReader();
            tabla.Load(leer);

            // Cerrar la conexión
            conexion.CerrarConexion();

            // Devolver el DataTable con los resultados
            return tabla;
        }


        public DataTable BuscarFacturasXCaja(string Fecha, int IdCaja)
        {
            // Abrir la conexión
            comando.Connection = conexion.AbrirConexion();

            // Establecer el tipo de comando como StoredProcedure
            comando.CommandType = CommandType.StoredProcedure;

            // Nombre del procedimiento almacenado
            comando.CommandText = "sp_ObtenerFacturasPorFechaYCaja";

            // Agregar los parámetros necesarios para el procedimiento almacenado
            comando.Parameters.Clear(); // Limpiar parámetros previos
            comando.Parameters.AddWithValue("@Fecha", Fecha); // Agregar el parámetro Fecha
            comando.Parameters.AddWithValue("@IdCaja", IdCaja); // Agregar el parámetro IdCaja

            // Ejecutar el comando y leer los resultados
            leer = comando.ExecuteReader();
            tabla.Load(leer);

            // Cerrar la conexión
            conexion.CerrarConexion();

            // Devolver los datos en un DataTable
            return tabla;
        }




        public DataTable BuscarFacturasXCajaasc(string Fecha, int IdCaja)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = @"
            select a.Fecha_factura,a.Num_Factura,a.Nombre_Completo,a.CarnetEstudiantil,a.NIdentificacion,c.PagoCon,c.MontoTotal_a_Pagar,c.Cambio,c.Tipo_Pago,c.NReferencia,a.SubTotal,a.Iva,d.Tipo_documento,d.Tipo_Movimiento,d.Cantidad,d.FechaRegistro,d.HorayFecha,e.NombreCaja,
            f.Usuario,G.Cod_Carnet as [Carnet Empleado],h.Nombres,h.Apellidos
            from Tbl_Factura_Gnral a
            JOIN Tbl_Detalle_Pago c on c.Num_Factura = a.Num_Factura join Tbl_MovimientoCaja d on d.Num_Documento = a.Num_Factura join Tbl_Cajas e on e.IdCaja = D.IdCaja join Tbl_Usuarios F ON f.Id_usuario = d.Id_usuario
            join Tbl_Empleados g on g.Id_empleado = f.Id_empleado join Tbl_Personas h on h.Id_persona = g.Id_persona
            where a.Id_estado = '6' AND(A.Fecha_factura = '" + Fecha + "') and d.IdCaja = '" + IdCaja + "'  ORDER BY a.Num_Factura asc";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }


        public DataTable MostrarMovimientoXtipo(string Fecha, int IdCaja)
        {
            DataTable tabla = new DataTable();


            using (SqlCommand comando = new SqlCommand("BuscarMovimientosXtipo", conexion.Conexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Fecha", Fecha);
                comando.Parameters.AddWithValue("@IdCaja", IdCaja);

                comando.CommandTimeout = 60;

                conexion.AbrirConexion();
                tabla.Load(comando.ExecuteReader());
            }


            return tabla;

        }


        public DataTable MostrarMovimientoXtipo_Movimiento(string Fecha, int IdCaja)
        {
            DataTable tabla = new DataTable();



            using (SqlCommand comando = new SqlCommand("MostrarMovimientoXTipo_Movimiento", conexion.Conexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Fecha", Fecha);
                comando.Parameters.AddWithValue("@IdCaja", IdCaja);

                comando.CommandTimeout = 60;

                conexion.AbrirConexion();
                tabla.Load(comando.ExecuteReader());
            }


            return tabla;

        }




        public DataTable MostrarMovimientoXRocRos(string Fecha, int IdCaja)
        {
            DataTable tabla = new DataTable();



            using (SqlCommand comando = new SqlCommand("MostrarMovimientoXRosRoc", conexion.Conexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Fecha", Fecha);
                comando.Parameters.AddWithValue("@IdCaja", IdCaja);

                comando.CommandTimeout = 60;

                conexion.AbrirConexion();
                tabla.Load(comando.ExecuteReader());
            }


            return tabla;

        }



        



        public DataTable BuscarMoviemientosGeneralCAJAS(string fechaInicial, string FechaFinal)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = @"select b.Nombre_Arancel,b.Precio as [Valor Arancel],f.Descripcion,F.ValorMoneda,count(b.Nombre_Arancel) as [Cantidad Total],
			(b.Precio * F.ValorMoneda * COUNT(b.Nombre_Arancel)) as Total from Factura_Detalle a
			join Tbl_Aranceles b on a.Id_Arancel = b.Id_Arancel join Tbl_Estados c on 
			c.Id_estado = a.Id_estado join Tbl_Factura_Gnral d on d.Num_Factura = a.Num_Factura
			join Tbl_MovimientoCaja e on e.Num_Documento = d.Num_Factura
			join Tbl_TipoMoneda f on f.IdMoneda = B.IdMoneda
			where c.Id_estado = '5' 
			and (d.Fecha_factura BETWEEN '" + fechaInicial + "' AND '" + FechaFinal + "')  and (b.Id_Arancel <> '11' and b.Id_Arancel <> '12' and b.Id_Arancel <> '14') group by b.Nombre_Arancel,b.Precio,F.Descripcion,f.ValorMoneda";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable BuscarMoviemientosGeneralXCAJAS(string fechaInicial, string FechaFinal, int IdCaja)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = @"select b.Nombre_Arancel,b.Precio as [Valor Arancel],f.Descripcion,F.ValorMoneda,count(b.Nombre_Arancel) as [Cantidad Total],
			(b.Precio * F.ValorMoneda * COUNT(b.Nombre_Arancel)) as Total from Factura_Detalle a
			join Tbl_Aranceles b on a.Id_Arancel = b.Id_Arancel join Tbl_Estados c on 
			c.Id_estado = a.Id_estado join Tbl_Factura_Gnral d on d.Num_Factura = a.Num_Factura
			join Tbl_MovimientoCaja e on e.Num_Documento = d.Num_Factura
			join Tbl_TipoMoneda f on f.IdMoneda = B.IdMoneda
			where c.Id_estado = '5' 
			and (d.Fecha_factura BETWEEN '" + fechaInicial + "' AND '" + FechaFinal + "')  and (b.Id_Arancel <> '11' and b.Id_Arancel <> '12' and b.Id_Arancel <> '14') and e.IdCaja = '" + IdCaja + "'  group by b.Nombre_Arancel,b.Precio,F.Descripcion,f.ValorMoneda";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable BuscarExoneracionPorDepositos(string FechaInicio, string FechaFinal)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec BuscarExoneracionMoraPorDepositoAnticipado '" + FechaInicio + "','" + FechaFinal + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }



        public void ActualizarMoraExonerada(int IdMoraExoneracion, string FechaRevision, string HoraRevision, string Estado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarRevisionExoneracion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdMoraExonerada", IdMoraExoneracion);
            comando.Parameters.AddWithValue("@FechaRevision", FechaRevision);
            comando.Parameters.AddWithValue("@HoraRevision", HoraRevision);
            comando.Parameters.AddWithValue("@Estado", Estado);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }





    }
}
