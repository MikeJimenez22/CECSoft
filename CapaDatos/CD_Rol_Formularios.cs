using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Rol_Formularios
    {


        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();


        //Metodo Insertar Persona
        public void Insertar(int IdRol, int IdFormulario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Insertar_RolFormulario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdRol", IdRol);
            comando.Parameters.AddWithValue("@IdFormulario", IdFormulario);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }
        
        public DataTable Mostrar_FormulariosxRol(string TextoBuscar)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select a.Id_Rol_Formularios,b.Descripcion,c.NombreFormulario,d.Estado from Tbl_Rol_Formulario a join Tbl_Roles b on a.IdRol = b.IdRol join Tbl_Formularios c on c.IdFormularioSistema = a.IdFormularioSistema join Tbl_Estados d on d.Id_estado = a.Id_estado where b.Descripcion like '" + TextoBuscar + "' + '%'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable Mostrar_FormulariosxRol_Estado(string TextoBuscar)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select d.Estado from Tbl_Rol_Formulario a join Tbl_Roles b on a.IdRol = b.IdRol join Tbl_Formularios c on c.IdFormularioSistema = a.IdFormularioSistema join Tbl_Estados d on d.Id_estado = a.Id_estado where b.Descripcion = '" + TextoBuscar + "' ";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void ModificarEstado(int IdRolFormulario, int Estado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarEstado_Rol_Formulario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", IdRolFormulario);
            comando.Parameters.AddWithValue("@Estado", Estado);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }





    }
}
