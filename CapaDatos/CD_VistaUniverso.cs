using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CD_VistaUniverso
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();




        public DataTable MostrarPorCarnet(string carnet, int estado)
        {
            DataTable tabla = new DataTable();



            using (SqlCommand comando = new SqlCommand("MostrarMatriculasPorCarnet", conexion.Conexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@TextoBusqueda", carnet);
                comando.Parameters.AddWithValue("@IdEstado", estado);

                comando.CommandTimeout = 60;

                conexion.AbrirConexion();
                tabla.Load(comando.ExecuteReader());
            }


            return tabla;

        }




        public DataTable MostrarPorCodMatricula(string carnet, int estado)
        {
            DataTable tabla = new DataTable();



            using (SqlCommand comando = new SqlCommand("MostrarMatriculasPorCodMatricula", conexion.Conexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@TextoBusqueda", carnet);
                comando.Parameters.AddWithValue("@IdEstado", estado);

                comando.CommandTimeout = 60;

                conexion.AbrirConexion();
                tabla.Load(comando.ExecuteReader());
            }


            return tabla;

        }

        

        public DataTable MostrarPorNombres(string nombre, int estado)
        {
            DataTable tabla = new DataTable();



            using (SqlCommand comando = new SqlCommand("MostrarMatriculasPorNombres", conexion.Conexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@TextoBusqueda", nombre);
                comando.Parameters.AddWithValue("@IdEstado", estado);

                conexion.AbrirConexion();
                tabla.Load(comando.ExecuteReader());
            }


            return tabla;

        }


        public DataTable MostrarPorApellidos(string Apellidos,int estado)
        {
            DataTable tabla = new DataTable();



            using (SqlCommand comando = new SqlCommand("MostrarMatriculasPorApellidos", conexion.Conexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@TextoBusqueda", Apellidos);
                comando.Parameters.AddWithValue("@IdEstado", estado);

                conexion.AbrirConexion();
                tabla.Load(comando.ExecuteReader());
            }


            return tabla;

        }

      



        public DataTable CantidadTotalUniverso()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select COUNT(Id_Matricula) from Tbl_Matricula where Id_estado = '3'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable CantidadTotalUniversoHoy(string fecha)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select COUNT(Id_Matricula) from Tbl_Matricula where Id_estado = '3' AND Fecha_Registro = '" + fecha + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }



        //Metodo Mostrar Persona
        public DataTable MostrarAltas(int IdMatricula)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select Fecha_Reingreso from Tbl_Reingresos where Id_Matricula = '" + IdMatricula + "' order by Fecha_Reingreso Desc";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        //Metodo Mostrar Persona
        public DataTable MostrarBajas(int IdMatricula)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select Motivo_baja,Descripcion,Fecha_Baja from Tbl_Bajas where Id_Matricula  = '" + IdMatricula + "' order by Fecha_Baja desc";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        public DataTable MostrarMatriculasPorFechaEjecutivo(string FechaInicial, string FechaFinal, int Estado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = @"

    SELECT
    a.Id_Matricula,
    a.Cod_Matricula,
    a.Empleado as [Matriculado por],
    a.Fecha as [Fecha Inicio],
    a.Fecha_Registro as [Fecha Registro],
    b.Cod_carnet as [Carnet Estudiantil],
    c.Nombres,
    c.Apellidos,
    C.FechaNacimiento,
    ISNULL((SELECT TOP(1) Numero FROM Tbl_AgendaTelefonica WHERE Tbl_AgendaTelefonica.Id_persona = c.Id_persona ORDER BY Id_Agenda ASC), '----------') AS[Celular 1],
    ISNULL((SELECT TOP(1) Numero FROM Tbl_AgendaTelefonica WHERE Tbl_AgendaTelefonica.Id_persona = c.Id_persona ORDER BY Id_Agenda DESC), '----------') AS[Celular 2],
    c.NombreTutor,
    ISNULL(C.CelularTutor, '----------') AS[Celular Tutor],
    f.Nombre_curso,
    f.TipoCurso,
    f.Duracion,
    g.Turno,
    g.Dias,
    h.Horario,
    ISNULL(n.Nombres, '-') AS[Nombre Docente],
	ISNULL(n.Apellidos, '-') AS[Apellido Docente],
    i.Estado,
	ISNULL(CAST(L.Id_empleado AS varchar(255)), '-') AS[Id Empleado],
	d.Id_Grupo
FROM
    Tbl_Matricula a
    JOIN Tbl_Estudiantes b ON a.Id_estudiante = b.Id_estudiante
    JOIN Tbl_Personas c ON c.Id_persona = b.Id_persona
    JOIN Tbl_Grupos d ON d.Id_Grupo = a.Id_Grupo
    JOIN Tbl_Curso_Turnos e ON e.Id_Curso_turno = d.Id_Curso_turno
    JOIN Tbl_Cursos f ON f.Id_curso = E.Id_curso
    JOIN Tbl_Turnos g ON g.Id_turno = E.Id_turno
    JOIN Tbl_Horarios h ON h.Id_Horario = d.Id_Horario
    JOIN Tbl_Estados i ON i.Id_estado = a.Id_estado
    JOIN Tbl_Empleados j ON j.Id_empleado = d.Id_empleado
    JOIN Tbl_Personas k ON k.Id_persona = j.Id_persona
    LEFT JOIN Tbl_Docente_Matricula l ON l.Cod_Matricula = a.Cod_Matricula

    LEFT JOIN Tbl_Empleados m ON m.Id_empleado = l.Id_empleado

    LEFT JOIN Tbl_Personas n ON n.Id_persona = m.Id_persona
    WHERE
    (a.Fecha_Registro between '" + FechaInicial + "' and '" + FechaFinal + "') AND i.Id_estado = '" + Estado + "' and a.Origen_Matricula = 'Ejecutivo de Venta' ORDER BY  a.Id_Matricula DESC;  ";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        public DataTable MostrarSIEXISTE_REGISTROMATRICULA(string fecha)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM Tbl_HistorialMatriculas where Fecha = '" + fecha + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        public void InsertarREGISTROFECHA(string Fecha, int Total)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_INSERTARHISTORIALMATRICULA";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@fecha", Fecha);
            comando.Parameters.AddWithValue("@Total", Total);



            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }


        public void Actualizar_REGISTROFECHA(string Fecha, int Total)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_ACTUALIZARHISTORIALMATRICULA";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@fecha", Fecha);
            comando.Parameters.AddWithValue("@Total", Total);



            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }



        public DataTable GenerarExpedienteEstudiantil(string CodigoMatricula)
        {
            DataTable tabla = new DataTable();



            using (SqlCommand comando = new SqlCommand("GenerarExpedienteEstudiante", conexion.Conexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@TextoBusqueda", CodigoMatricula);
                comando.CommandTimeout = 60;

                conexion.AbrirConexion();
                tabla.Load(comando.ExecuteReader());
            }


            return tabla;

        }


        public DataTable BuscarMatriculasPorCodigo(string Codigo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "exec MostrarInformacion_Matricula '" + Codigo + "'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable ObtenerFacturaRegistro(string CodMatricula)
        {
            DataTable tabla = new DataTable();



            using (SqlCommand comando = new SqlCommand("ObtenerPrimerFactura", conexion.Conexion()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@CodMatricula", CodMatricula);

                comando.CommandTimeout = 60;

                conexion.AbrirConexion();
                tabla.Load(comando.ExecuteReader());
            }


            return tabla;

        }

        




    }
}
