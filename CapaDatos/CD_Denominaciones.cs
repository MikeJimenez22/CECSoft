using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Denominaciones
    {


        private CD_Conexion conexion = new CD_Conexion();
        //SqlDataReader leer;
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

     


     

        //Metodo Mostrar Persona
        public DataTable MostrarFacturaInicial(string Fecha, int IdCaja)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select top(1) a.Num_Documento,a.Cantidad,b.Descripcion from Tbl_MovimientoCaja a join Tbl_TipoMoneda b on a.IdMoneda = b.IdMoneda join Tbl_Usuarios c on a.Id_usuario = c.Id_usuario join Tbl_Cajas d on a.IdCaja = d.IdCaja where Tipo_Movimiento = 'ENTRADA' and a.FechaRegistro = '" + Fecha + "' and a.IdCaja = '" + IdCaja + "' order by IdMovimiento_Caja asc";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable MostrarFacturaFinal(string Fecha, int IdCaja)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select top(1) a.Num_Documento,a.Cantidad,b.Descripcion from Tbl_MovimientoCaja a join Tbl_TipoMoneda b on a.IdMoneda = b.IdMoneda join Tbl_Usuarios c on a.Id_usuario = c.Id_usuario join Tbl_Cajas d on a.IdCaja = d.IdCaja where Tipo_Movimiento = 'ENTRADA' and a.FechaRegistro = '" + Fecha + "' and a.IdCaja = '" + IdCaja + "' order by IdMovimiento_Caja desc";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


       





    }
}
