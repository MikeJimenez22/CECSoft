using System;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CD_CarterayCobro
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();





        //Metodo Mostrar Persona


        public DataTable BuscarPorFechas(DateTime FechaInicial, DateTime FechaFinal, string Estado, string Turno)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("BuscarCarteraPorTurno", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FechaInicio", FechaInicial);
                    command.Parameters.AddWithValue("@FechaFinal", FechaFinal);
                    command.Parameters.AddWithValue("@Estado", Estado);
                    command.Parameters.AddWithValue("@Turno", Turno);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }


        public DataTable BuscarGeneral(DateTime FechaInicial, DateTime FechaFinal, string Estado)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("BuscarCarteraGeneral", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FechaInicio", FechaInicial);
                    command.Parameters.AddWithValue("@FechaFinal", FechaFinal);
                    command.Parameters.AddWithValue("@Estado", Estado);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }


        public DataTable ConsultarCarteraAcademica(DateTime fechaInicial,
                                           DateTime fechaFinal,
                                           string estado,
                                           string turno)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SP_ConsultarCarteraAcademica", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FechaInicio", fechaInicial);
                    command.Parameters.AddWithValue("@FechaFinal", fechaFinal);
                    command.Parameters.AddWithValue("@Estado", estado);
                    command.Parameters.AddWithValue("@Turno", turno);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }











        public DataTable BuscarPorFechaListaCelulares(string FechaInicial, string FechaFinal, string Estado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select p.tipo_medio,p.Compañia,p.Numero,LOWER(j.Nombres),LOWER(j.Apellidos),c.Fecha from Tbl_Detalle_Programacion a join Tbl_ProgramacionPago b on a.Num_programacion = b.Num_programacion join Tbl_Matricula c on c.Cod_Matricula = b.Cod_Matricula join Tbl_Grupos d on d.Id_Grupo = c.Id_Grupo join Tbl_Curso_Turnos e on e.Id_Curso_turno = d.Id_Curso_turno join Tbl_Cursos f on f.Id_curso = e.Id_curso join Tbl_Turnos g on g.Id_turno = e.Id_turno join Tbl_Horarios h on h.Id_Horario = d.Id_Horario join Tbl_Estudiantes i on i.Id_estudiante = c.Id_estudiante join Tbl_Personas j on j.Id_persona = i.Id_persona join TblSucursales k on k.Id_sucursal = i.Id_sucursal  join Tbl_Estados m on m.Id_estado = a.Id_estado join Tbl_TipoMoneda n on n.IdMoneda = a.IdMoneda join Tbl_Estados ñ on ñ.Id_estado = c.Id_estado join Tbl_AgendaTelefonica p on p.Id_persona = j.Id_persona where (a.Fecha_Programada BETWEEN '" + FechaInicial + "' AND '" + FechaFinal + "') AND (m.Estado = '" + Estado + "') and c.Id_estado = '3'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public DataTable MostrarCarteraGeneral(DateTime FechaInicio,DateTime FechaFinal)
        {
            using (var connection = conexion.AbrirConexion())
            {
                using (var command = new SqlCommand("SPMostrarCarteraPorTurnoGeneral", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                    command.Parameters.AddWithValue("@FechaFinal", FechaFinal);

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }

    }
}
