using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_FacturaDetalle
    {


        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();


        //Metodo Insertar Persona
        public void Insertar(string NumFactura, int IdArancel, int IdMoneda, double ValorMoneda, double TotalEnCordobas, int Cantidad, int IdEstado, double Monto, string observaciones)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarFacturaDetalle";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@numFactura", NumFactura);
            comando.Parameters.AddWithValue("@Idarancel", IdArancel);
            comando.Parameters.AddWithValue("@IdMoneda", IdMoneda);
            comando.Parameters.AddWithValue("@ValorMoneda", ValorMoneda);
            comando.Parameters.AddWithValue("@TotalCordobas", TotalEnCordobas);
            comando.Parameters.AddWithValue("@Cantidad", Cantidad);
            comando.Parameters.AddWithValue("@IdEstado", IdEstado);
            comando.Parameters.AddWithValue("@monto", Monto);
            comando.Parameters.AddWithValue("@observaciones", observaciones);



            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public DataTable Mostrarcompletados(string NumFactura)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select a.Id_Factura_Detalle, b.Nombre_Arancel, a.Cantidad, a.Monto, c.Simbolo, a.Total_en_Cordobas, a.Observaciones, d.Estado from Factura_Detalle a join Tbl_Aranceles b on a.Id_Arancel = b.Id_Arancel join Tbl_TipoMoneda c on c.IdMoneda = a.IdMoneda join Tbl_Estados d on d.Id_estado = a.Id_estado  where a.Num_Factura like '" + NumFactura + "' + '%' and a.Id_estado = '5'   and b.Nombre_Arancel != 'MENSUALIDAD' AND b.Nombre_Arancel != 'EXAMEN' and b.Nombre_Arancel != 'EXAMEN DE REPROGRAMACION' and b.Nombre_Arancel != 'MATRICULA' and b.Nombre_Arancel != 'REINGRESO' and b.Nombre_Arancel != 'TRASLADO' and b.Nombre_Arancel != 'ABONO DE MENSUALIDAD' and b.Nombre_Arancel != 'FOTO DIPLOMA' and b.Nombre_Arancel != 'VENTA LIBRERIA' ";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }





        public DataTable MostrarDetallesCompletados(string NumFactura)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select a.Id_Factura_Detalle,b.Nombre_Arancel,a.Cantidad,a.Monto,c.Simbolo,a.Total_en_Cordobas,a.Observaciones,d.Estado from Factura_Detalle a join Tbl_Aranceles b  on a.Id_Arancel = b.Id_Arancel join Tbl_TipoMoneda c on c.IdMoneda = a.IdMoneda join Tbl_Estados d on d.Id_estado = a.Id_estado where a.Num_Factura = '" + NumFactura + "'  and a.Id_estado = '5'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        public void Eliminar(int Id_detalle)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = " Delete Factura_Detalle where Id_Factura_Detalle = '" + Id_detalle + "'";
            comando.ExecuteNonQuery();
        }

        public void CompletarPago(int Id_detalle_factura)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "update Factura_Detalle set Id_estado = '5' where Id_Factura_Detalle = '" + Id_detalle_factura + "'";
            comando.ExecuteNonQuery();
        }





        public DataTable MostrarRocYROS(string CodFactura)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select a.Num_Factura,a.Total_en_Cordobas,b.Nombre_Arancel,b.Tipo,a.Observaciones,C.Estado from Factura_Detalle a join Tbl_Aranceles b on a.Id_Arancel = b.Id_Arancel join Tbl_Estados c on c.Id_estado = a.Id_estado where a.Num_Factura like '" + CodFactura + "' + '%' and c.Id_estado = '5'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }



    }
}
