using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CN_Empleados
    {
        private CD_Empleados objetoCD = new CD_Empleados();

        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        
        public DataTable MostrarInactivos()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarInactivos();
            return tabla;
        }

        public DataTable UltimoRegistro()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.UltimoRegistro();
            return tabla;
        }

        public void InsertarEmpleado(string Id_Persona, string Cod_Carnet, string Inss, string Estado_Civil, string FechaIngreso, string FechaFinalizacion, string IdEstado, string TipoEmpledao)
        {
            objetoCD.Insertar(Convert.ToInt32(Id_Persona), Cod_Carnet, Inss, Estado_Civil, Convert.ToDateTime(FechaIngreso), Convert.ToDateTime(FechaFinalizacion), Convert.ToInt32(IdEstado), TipoEmpledao);
        }

        public void EditarEmpleado(string Id_Empleado, string Id_Persona, string Cod_Carnet, string Inss, string Estado_Civil, string FechaIngreso, string FechaFinalizacion, string IdEstado, string TipoEmpleado)
        {
            objetoCD.Editar(Convert.ToInt32(Id_Empleado), Convert.ToInt32(Id_Persona), Cod_Carnet, Inss, Estado_Civil, Convert.ToDateTime(FechaIngreso), Convert.ToDateTime(FechaFinalizacion), Convert.ToInt32(IdEstado), TipoEmpleado);
        }

   
        public void ModificarEstado(string IdEmpleado, string IDestado)
        {
            objetoCD.ModificarEstado(Convert.ToInt32(IdEmpleado), Convert.ToInt32(IDestado));
        }

        public DataTable MostrarDocentesActivos()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarDocentesActivos();
            return tabla;
        }

        public DataTable MostrarDocentes(int IdEstado)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarDocente(IdEstado);
            return tabla;
        }


    }
}
