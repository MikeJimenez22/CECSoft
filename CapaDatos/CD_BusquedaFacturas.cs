using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CD_BusquedaFacturas
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable MostrarFactura(string NumFactura)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select a.Id_Factura,a.Num_Factura,a.SubTotal,a.Iva,a.Total,b.Descripcion,c.Estado,a.Fecha_factura,a.Nombre_Completo,a.CarnetEstudiantil,a.NIdentificacion,d.Tipo_Pago,d.PagoCon,e.Descripcion,d.ValorMoneda as [T / C],d.TotalEnCordobas,d.MontoTotal_a_Pagar,d.Cambio,d.NReferencia,ISNULL(f.HorayFecha, '-------') as Hora, i.Nombres as [Nombre cajero], i.Apellidos as [Apellidos cajero] from Tbl_Factura_Gnral a join Tbl_TipoMoneda b on a.IdMoneda = b.IdMoneda join Tbl_Estados c on c.Id_estado = a.Id_estado join Tbl_Detalle_Pago d on d.Num_Factura = a.Num_Factura join Tbl_TipoMoneda e  on e.IdMoneda = d.IdMoneda join Tbl_MovimientoCaja f on f.Num_Documento = a.Num_Factura join Tbl_Usuarios g on g.Id_usuario = a.Id_Usuario join Tbl_Empleados h on h.Id_empleado = g.Id_empleado join Tbl_Personas i on i.Id_persona = h.Id_persona  where a.Num_Factura = '" + NumFactura + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

      

        public DataTable MostrarFacturaDetalle(string NumFactura)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select a.Num_Factura,b.Nombre_Arancel,a.Observaciones,b.Precio,c.Descripcion,c.ValorMoneda as [T/C],a.Cantidad,a.Monto,A.Total_en_Cordobas,d.Estado from Factura_Detalle a join Tbl_Aranceles b on a.Id_Arancel = b.Id_Arancel join Tbl_TipoMoneda c on c.IdMoneda = a.IdMoneda join Tbl_Estados d on d.Id_estado = a.Id_estado  where Num_Factura = '" + NumFactura + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }







    }
}
