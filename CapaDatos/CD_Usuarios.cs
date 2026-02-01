using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Usuarios
    {

        private CD_Conexion conexion = new CD_Conexion();


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();




        public DataTable login(string usuario,string contraseña)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SPLogin", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

      

        public DataTable BuscarCajaAsignada(int IdUsuario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select * from Tbl_CajaUsuario where Id_usuario = '" + IdUsuario + "' and Id_estado = '3'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable BuscarUsuarioExiste(string Usuario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select * from Tbl_Usuarios where Usuario = '" + Usuario + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable VerificarEstado(int IdUsuario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select a.Id_usuario,a.Usuario,B.Estado from Tbl_Usuarios a join Tbl_Estados b on a.Id_estado = b.Id_estado WHERE a.Id_usuario = '" + IdUsuario + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }
        

        public DataTable MostrarUsuarios(string usuario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select Usuario from Tbl_Usuarios where Usuario = '" + usuario + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(int idempleado, string usuario, string contraseña, DateTime fechaRegistro, int idestado, int Cambios, int sucursal)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "RegistrarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idempleado", idempleado);
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@contraseña", contraseña);
            comando.Parameters.AddWithValue("@fechaRegistro", fechaRegistro);
            comando.Parameters.AddWithValue("@idestado", idestado);
            comando.Parameters.AddWithValue("@Cambios", Cambios);
            comando.Parameters.AddWithValue("@sucursal", sucursal);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();


        }




        public void Activar(int IdUser)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Update  Tbl_Usuarios set Id_estado = '3', Cambios_Contraseña = Cambios_Contraseña + 1  where Id_usuario = '" + IdUser + "'";
            comando.ExecuteNonQuery();

        }


        public void Inactivar(int IdUser)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Update  Tbl_Usuarios set Id_estado = '4'  where Id_usuario = '" + IdUser + "'";
            comando.ExecuteNonQuery();

        }


        public void InactivarUser(string User)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Update  Tbl_Usuarios set Id_estado = '4'  where Usuario = '" + User + "'";
            comando.ExecuteNonQuery();

        }

        public void EliminarAsignacion(int IdAsignacion)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "delete Tbl_CajaUsuario where IdCajaUsuario = '" + IdAsignacion + "'";
            comando.ExecuteNonQuery();
        }

        public void InactivarCajaUser(int IdCajaUsuario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "update Tbl_CajaUsuario set Id_Estado = '4' where IdCajaUsuario =  '" + IdCajaUsuario + "'";
            comando.ExecuteNonQuery();

        }

        public void ActivarCajaUser(int IdCajaUsuario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "update Tbl_CajaUsuario set Id_Estado = '3' where IdCajaUsuario =  '" + IdCajaUsuario + "'";
            comando.ExecuteNonQuery();

        }


        public void AsignacionCaja(int IdCaja, int IdUsuario, int IdEstado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarCajaUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdCaja", IdCaja);
            comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            comando.Parameters.AddWithValue("@IdEstado", IdEstado);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }


        public DataTable MostraCajasUsuario()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select b.IdCajaUsuario,NombreCaja,c.Usuario,d.Estado,a.IdCaja from Tbl_Cajas a join Tbl_CajaUsuario b on a.IdCaja = b.IdCaja join Tbl_Usuarios c on c.Id_usuario = b.Id_usuario join Tbl_Estados d on d.Id_estado = b.Id_estado";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }



        //****************************************************************************************************
        public DataTable ObtenerUsuarios(int IdEstado)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_ObtenerUsuarios", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdEstado", IdEstado);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }



        public DataTable ObtenerCajasUsuario(int IdUsuario)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_ObtenerCajaUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }



        public DataTable ObtenerRolUsuario(int IdUsuario)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SPObtenerRolUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }



        public void ActualizarContraseña(string contraseña,string usuario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SPActualizarContraseña";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@NuevaContraseña", contraseña);
            comando.Parameters.AddWithValue("@usuario", usuario);
           


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();


        }


        public string ObtenerNumFactura(string caja)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_GenerarNumFactura", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetro de entrada
                    command.Parameters.AddWithValue("@Caja", caja);

                    // Parámetro de salida
                    var outputParam = new SqlParameter("@NumFactura", SqlDbType.VarChar, 20)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputParam);

                    // Ejecutar
                    command.ExecuteNonQuery();

                    // Obtener el valor del parámetro de salida
                    return outputParam.Value.ToString();
                }
            }
        }





    }
}
