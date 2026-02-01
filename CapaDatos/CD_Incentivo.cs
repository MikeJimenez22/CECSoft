using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Incentivo
    {

        private CD_Conexion conexion = new CD_Conexion();


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();



        public void CambiarValorIncentivo(int Valor)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ModificarIncentivo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@valor", Valor);



            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }



     


        public DataTable MostrarUniversoPorFechaEjecutivo(string FechaInicial, string FechaFinal, int IdEstado)
        {
            DataTable tabla = new DataTable();



            using (SqlCommand comando = new SqlCommand("MostrarMatriculasPorFechaEjecutivoDatos", conexion.Conexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@fechaInicial", FechaInicial);
                comando.Parameters.AddWithValue("@fechaFinal", FechaFinal);
                comando.Parameters.AddWithValue("@IdEstado", IdEstado);

                conexion.AbrirConexion();
                tabla.Load(comando.ExecuteReader());
            }


            return tabla;

        }


    


        public DataTable MostrarMatriculasAgrupadas(string FechaInicial, string FechaFinal, int IdEstado)
        {
            DataTable tabla = new DataTable();



            using (SqlCommand comando = new SqlCommand("CalcularIncentivo", conexion.Conexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@FechaInicial", FechaInicial);
                comando.Parameters.AddWithValue("@FechaFinal", FechaFinal);
                comando.Parameters.AddWithValue("@IdEstado", IdEstado);

                conexion.AbrirConexion();
                tabla.Load(comando.ExecuteReader());
            }


            return tabla;

        }


       



        public DataTable MostrarPagoIncentivoTotal(string FechaInicial, string FechaFinal, int Estado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = @"select Empleado,COUNT(Empleado) AS [Cantidad],ISNULL((select Valor from Tbl_Incentivo),'0') as [Monto Incentivo],(COUNT(Empleado)*(select Valor from Tbl_Incentivo)) as [Total] from Tbl_Matricula 
            where Fecha_Registro Between '" + FechaInicial + "' and '" + FechaFinal + "' and Origen_Matricula = 'Ejecutivo de Venta' and Id_estado = '" + Estado + "'group by Empleado";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }




    }
}
