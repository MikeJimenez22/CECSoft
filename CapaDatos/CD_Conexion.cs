using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Conexion
    {
        // 🔹 Cambiamos el nombre del campo para evitar conflicto
        private SqlConnection _conexion;

        public CD_Conexion()
        {
            // Leer la cadena de conexión desde App.config
            string cadenaConexion = ConfigurationManager.ConnectionStrings["CecnicSystem"].ConnectionString;
            _conexion = new SqlConnection(cadenaConexion);
        }

        public SqlConnection AbrirConexion()
        {
            if (_conexion.State == ConnectionState.Closed)
                _conexion.Open();
            return _conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (_conexion.State == ConnectionState.Open)
                _conexion.Close();
            return _conexion;
        }

        // ✅ Ahora sí podés usar este nombre
        public SqlConnection Conexion()
        {
            return _conexion;
        }

        public void CambiarConexion(string nuevaCadena)
        {
            // Actualizar la conexión activa en esta clase
            if (_conexion.State == ConnectionState.Open)
                _conexion.Close();

            _conexion.ConnectionString = nuevaCadena;

            // También opcionalmente actualizar el App.config para que persista
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["CecnicSystem"].ConnectionString = nuevaCadena;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}
