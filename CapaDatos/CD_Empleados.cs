using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Empleados
    {


        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

  
        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec SP_MostrarEmpleadosActivos";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }



        public DataTable MostrarInactivos()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec SP_MostrarEmpleadosInactivos";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        public DataTable UltimoRegistro()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select TOP(1) Id_empleado from Tbl_Empleados order by Id_empleado desc ";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        //Metodo Insertar Persona
        public void Insertar(int IdPersona, string Carnet, string Inss, string EstadoCvil, DateTime FechaIngreso, DateTime FechaSalida, int IdEstado, string TipoEmpleado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "RegistrarEmpleado";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idpersona", IdPersona);
            comando.Parameters.AddWithValue("@carnet", Carnet);
            comando.Parameters.AddWithValue("@inss", Inss);
            comando.Parameters.AddWithValue("@estado", EstadoCvil);
            comando.Parameters.AddWithValue("@fechaingreso", FechaIngreso);
            comando.Parameters.AddWithValue("@fechasalida", FechaSalida);
            comando.Parameters.AddWithValue("@idestado", IdEstado);
            comando.Parameters.AddWithValue("@TipoEmpleado", TipoEmpleado);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(int IdEmpleado, int IdPersona, string Carnet, string Inss, string EstadoCvil, DateTime FechaIngreso, DateTime FechaSalida, int IdEstado, string TipoEmpleado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarEmpleado";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idempleado", IdEmpleado);
            comando.Parameters.AddWithValue("@idpersona", IdPersona);
            comando.Parameters.AddWithValue("@carnet", Carnet);
            comando.Parameters.AddWithValue("@inss", Inss);
            comando.Parameters.AddWithValue("@estado", EstadoCvil);
            comando.Parameters.AddWithValue("@fechaingreso", FechaIngreso);
            comando.Parameters.AddWithValue("@fechasalida", FechaSalida);
            comando.Parameters.AddWithValue("@idestado", IdEstado);
            comando.Parameters.AddWithValue("@TipoEmpleado", TipoEmpleado);
            
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        
        


        //Metodo Insertar Persona
        public void ModificarEstado(int IdEmpleado, int IdEstado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ModificarEstadoEmpleado";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
            comando.Parameters.AddWithValue("@IdEstado", IdEstado);



            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public DataTable MostrarDocentesActivos()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarDocentesActivos";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


      



    }
}
