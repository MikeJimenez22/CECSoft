using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Detalle_Programacion
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        //Metodo Insertar Persona
        public void Insertar(string NumProgramacion, DateTime FechaProgramada, string Concepto, double MontoMensualidad, int IdMoneda, DateTime FechaVencimiento, int Mora, int IdEstado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarDetalle_Programacion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Num_programacion", NumProgramacion);
            comando.Parameters.AddWithValue("@fechaProgramada", FechaProgramada);
            comando.Parameters.AddWithValue("@concepto", Concepto);
            comando.Parameters.AddWithValue("@Monto", MontoMensualidad);
            comando.Parameters.AddWithValue("@IdMoneda", IdMoneda);
            comando.Parameters.AddWithValue("@FechaVencimiento", FechaVencimiento);
            comando.Parameters.AddWithValue("@Mora", Mora);
            comando.Parameters.AddWithValue("@Idestado", IdEstado);



            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }




        public DataTable BuscarDetalles_de_Pagos(string carnet)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_DetallePagos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NumProgramacion", carnet);


                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }




        public void Editar(int IdDetalleProgramacion)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "update Tbl_Detalle_Programacion set Id_estado = '6' where Id_Detalle_Programacion = '" + IdDetalleProgramacion + "'";
            comando.ExecuteNonQuery();

        }

  

      

      

        public void CambiarFecha(string FechaNueva, int IdDetalle)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "update Tbl_Detalle_Programacion set Fecha_Vencimiento =  '" + FechaNueva + "'  where Id_Detalle_Programacion = '" + IdDetalle + "'";
            comando.ExecuteNonQuery();
        }


        public void EliminarMora(int IdDetalleProgramacion)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ELIMINARMORA";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdDetalleProgramacion", IdDetalleProgramacion);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }
      

        public DataTable ObtenerPrimerDetalleProgramacion(string NumProgramacion)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("ObtenerPrimerDetalleProgramacion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NumProgramacion", NumProgramacion);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }


     
        public void ActualizarMora(int Mora, int IdDetallePago)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarMoraPago";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Mora", Mora);
            comando.Parameters.AddWithValue("@IdDetallePago", IdDetallePago);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }


        public void ActualizarHistorialPago(string CodMatricula,int IdMoneda,int Monto)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_ActualizarHistorialPago";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CodMatricula", CodMatricula);
            comando.Parameters.AddWithValue("@IdMoneda", IdMoneda);
            comando.Parameters.AddWithValue("@Monto", Monto);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }


        public void ModificarMensualidad(int IdDetalleProgramacion,decimal Monto)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_ModificarMensualidad";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdDetalleProgramacion", IdDetalleProgramacion);
            comando.Parameters.AddWithValue("@Monto", Monto);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }




    }
}

