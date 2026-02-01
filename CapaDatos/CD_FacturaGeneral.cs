using System;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_FacturaGeneral
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

    
        public void ActualizarDetallesFacturaApendiente(int IdEstado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_ActualizarDetallesEnProceso";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdEstado", IdEstado);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }



        public DataTable MostrarAbonosFactura(string NumFactura)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select a.Id_Abono,a.Fecha,a.Num_Factura,a.Monto,b.Descripcion,C.Estado from Tbl_Abonos a join Tbl_TipoMoneda b on a.IdMoneda = b.IdMoneda join Tbl_Estados c on c.Id_estado = a.Id_estado where a.Num_Factura = '" + NumFactura + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable MostrarMensualidadesFactura(string NumFactura)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select* from Tbl_Factura_Mensualidades where Codigo = '" + NumFactura + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        public DataTable BuscarMoviemientosHoy(string FechaFactura, int IdCaja)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select b.Nombre_Arancel,count(b.Nombre_Arancel) as [Cantidad Total] from Factura_Detalle a join Tbl_Aranceles b on a.Id_Arancel = b.Id_Arancel join Tbl_Estados c on c.Id_estado = a.Id_estado join Tbl_Factura_Gnral d on d.Num_Factura = a.Num_Factura join Tbl_MovimientoCaja e on e.Num_Documento = d.Num_Factura where c.Id_estado = '5' and d.Fecha_factura = '" + FechaFactura + "' and e.IdCaja = '" + IdCaja + "' group by b.Nombre_Arancel";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable CalcularVentaLibreriaTotal(string FechaFactura)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select ISNULL(sum(a.Monto),0) as [Venta total] from Factura_Detalle a join Tbl_Aranceles b on a.Id_Arancel = b.Id_Arancel join Tbl_Estados c on c.Id_estado = a.Id_estado join Tbl_Factura_Gnral d on d.Num_Factura = a.Num_Factura  where c.Id_estado = '5' and d.Fecha_factura = '" + FechaFactura + "'  and b.Id_Arancel = '14' ";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


    }
}
