using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_AsistenciaEstudiantil
    {

        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public void InsertarAsistencia(DateTime fecha,int IdEmpleado,string HoraRegistro,int IdSeccion,string CodigoAsistencia,string Observaciones,string Horario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "INSERT INTO Tbl_Asistencia (Fecha,Id_empleado,HoraRegistro,IdSeccion,CodigoAsistencia,Observaciones,HoraClases) values (@fecha,@IdEmpleado,@Hora,@IdSeccion,@CodigoAsistencia,@Observaciones,@Horario)";
            

            comando.Parameters.AddWithValue("@fecha",fecha);
            comando.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
            comando.Parameters.AddWithValue("@Hora", HoraRegistro);
            comando.Parameters.AddWithValue("@IdSeccion", IdSeccion);
            comando.Parameters.AddWithValue("@CodigoAsistencia", CodigoAsistencia);
            comando.Parameters.AddWithValue("@Observaciones", Observaciones);
            comando.Parameters.AddWithValue("@Horario",Horario);
           
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }


          public void InsertarAsistenciaEstudiante(int IdMatricula,string CodigoAsistencia,string Estado,string Observaciones)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Insert into Tbl_AsistenciaEstudiante(Id_Matricula, CodigoAsistencia, Estado, Observaciones) values(@IdMatricula, @Codigo, @Estado, @Observaciones)";


            comando.Parameters.AddWithValue("@IdMatricula",IdMatricula);
            comando.Parameters.AddWithValue("@Codigo", CodigoAsistencia);
            comando.Parameters.AddWithValue("@Estado", Estado);
            comando.Parameters.AddWithValue("@Observaciones", Observaciones);
          

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }


        public DataTable Mostrar(string CodigoAsistencia)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = @"select 
            K.CodigoAsistencia,k.Fecha,k.HoraRegistro,l.Seccion,a.Cod_Matricula,b.Cod_carnet,c.Nombres,c.Apellidos,f.Nombre_curso,j.Estado,j.Observaciones,i.Estado as [Estado Matricula]
            from Tbl_Matricula a join Tbl_Estudiantes b on a.Id_estudiante = b.Id_estudiante
            join Tbl_Personas c on b.Id_persona = c.Id_persona join Tbl_Grupos d on a.Id_Grupo = d.Id_Grupo join Tbl_Curso_Turnos e on d.Id_Curso_turno = e.Id_Curso_turno join
            Tbl_Cursos f on  e.Id_curso = f.Id_curso join
            Tbl_Turnos g on e.Id_turno = g.Id_turno join Tbl_Usuarios h on a.Id_usuario = h.Id_usuario join
            Tbl_Estados i on a.Id_estado = i.Id_estado join Tbl_AsistenciaEstudiante j on j.Id_Matricula = a.Id_Matricula
            join Tbl_Asistencia k on k.CodigoAsistencia = j.CodigoAsistencia join Tbl_Seccion l on l.IdSeccion = k.IdSeccion where k.CodigoAsistencia = '"+ CodigoAsistencia +"'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }


        public DataTable MostrarAsistenciaPorFecha(string Fecha)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = @"
            select a.IdAsistencia,a.CodigoAsistencia,d.Nombres,d.Apellidos,a.Fecha,a.HoraRegistro,a.HoraClases,a.Observaciones
            from Tbl_Asistencia a join Tbl_Empleados b on a.Id_empleado = B.Id_empleado join Tbl_Seccion c 
            on c.IdSeccion = A.IdSeccion join Tbl_Personas d on d.Id_persona = b.Id_persona where a.Fecha = '"+ Fecha+"'";

            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }



    }
}
