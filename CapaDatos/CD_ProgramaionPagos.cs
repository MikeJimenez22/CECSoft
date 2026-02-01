using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_ProgramaionPagos
    {

        private CD_Conexion conexion = new CD_Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        //Metodo Insertar Persona
        public void Insertar(string NumProgramaion, string CodMatricula, int IdArancel, int DiasPago, double TotalMonto, int IdMoneda, int DiaVencimiento, int Mora, int IdEstado, double Saldo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarProgramacionPagos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@numProgramacion", NumProgramaion);
            comando.Parameters.AddWithValue("@CodMatricula", CodMatricula);
            comando.Parameters.AddWithValue("@IdArancel", IdArancel);
            comando.Parameters.AddWithValue("@DiasPago", DiasPago);
            comando.Parameters.AddWithValue("@Total_Monto", TotalMonto);
            comando.Parameters.AddWithValue("@IdMoneda", IdMoneda);
            comando.Parameters.AddWithValue("@diaVencimiento", DiaVencimiento);
            comando.Parameters.AddWithValue("@Mora", Mora);
            comando.Parameters.AddWithValue("@IdEstado", IdEstado);
            comando.Parameters.AddWithValue("@saldo", Saldo);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }


        public DataTable ObtenerNumeroProgramacion()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec Generar_Num_Programacion";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        public DataTable VerPendientes(DateTime FechaInicial, DateTime FechaFinal)
        {
            DataTable tabla = new DataTable();

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ObtenerUltimoPagoPorMatricula";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@FechaInicial", FechaInicial);
            comando.Parameters.AddWithValue("@FechaFinal", FechaFinal);

            leer = comando.ExecuteReader();
            tabla.Load(leer);

            conexion.CerrarConexion();
            return tabla;
        }




    }
}
