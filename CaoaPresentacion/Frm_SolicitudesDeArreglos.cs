using CapaDatos;
using CapaNegocio;
using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;


namespace CaoaPresentacion
{
    public partial class Frm_SolicitudesDeArreglos : Form
    {
        CN_ArreglosPagos objetoCN = new CN_ArreglosPagos();
        CN_Detalle_Programacion objetoCN2 = new CN_Detalle_Programacion();
        string NumProgramacion;
        string FechaPago;
        string FechaFormateada;
        string IdArreglo;
        CD_Conexion conexion = new CD_Conexion();

        public Frm_SolicitudesDeArreglos()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        private void AgregarBtnDatagridView()
        {
            dataSolicitudes.Columns.Add(
       new DataGridViewButtonColumn()
       {
           HeaderText = "Aprobar Solicitudes",
           Name = "Ok",
           Text = "Ok",
           UseColumnTextForButtonValue = true
       });


        }

        private void Frm_SolicitudesDeArreglos_Load(object sender, EventArgs e)
        {
            this.AgregarBtnDatagridView();
            this.MostrarSolicitudes();
        

        }

        private void MostrarSolicitudes()
        {
            CN_ArreglosPagos objetoCN = new CN_ArreglosPagos();
            this.dataSolicitudes.DataSource = objetoCN.MostrarSolicitudesPendientes();
        }

        private void dataSolicitudes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataSolicitudes.Columns[e.ColumnIndex].Name == "Ok")
            {
                NumProgramacion = this.dataSolicitudes.CurrentRow.Cells["Num_programacion"].Value.ToString();

                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cm = new SqlCommand("select d.Nombres,d.Apellidos,c.Cod_carnet from Tbl_ProgramacionPago a join Tbl_Matricula b on a.Cod_Matricula = b.Cod_Matricula join Tbl_Estudiantes c on c.Id_estudiante = b.Id_estudiante join Tbl_Personas d on d.Id_persona = c.Id_persona where a.Num_programacion = '" + NumProgramacion + "' ", conexion.Conexion());
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read() == true)
                {
                    this.txtNombreEstudiante.Text = dr["Nombres"].ToString();
                    this.txtApellidosEstudiante.Text = dr["Apellidos"].ToString();
                    this.txtCarnetEstudiante.Text = dr["Cod_carnet"].ToString();

                }
                conexion.CerrarConexion();

                this.txtObservaciones.Text = this.dataSolicitudes.CurrentRow.Cells["Observacion"].Value.ToString();
                this.MostrarNotas();

                FechaPago = this.dataSolicitudes.CurrentRow.Cells["Fecha_ProximaPago"].Value.ToString();
                IdArreglo = this.dataSolicitudes.CurrentRow.Cells["Id_Arreglo"].Value.ToString();
                this.txtIdArreglo.Text = this.dataSolicitudes.CurrentRow.Cells["Id_Arreglo"].Value.ToString();
            }
        }

        private void MostrarNotas()
        {
            CN_Detalle_Programacion objetoCN = new CN_Detalle_Programacion();
            this.datadetalles.DataSource = objetoCN.BuscarDetallesPagos(NumProgramacion);

        }

        private void MostrarDetalleVacio()
        {
            CN_Detalle_Programacion objetoCN = new CN_Detalle_Programacion();
            this.datadetalles.DataSource = objetoCN.BuscarDetallesPagos("");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (DataGridViewRow row in datadetalles.Rows)
                {
                    string fecha = Convert.ToDateTime(row.Cells["Fecha_Vencimiento"].Value.ToString()).ToShortDateString();
                    DateTime Fecha2 = Convert.ToDateTime(fecha);


                    /*en este fragmento de codigo obtenemos el ultimo dia del Mes Actual */
                    DateTime today = Fecha2;
                    int endOfMonth = new DateTime(today.Year, today.Month, 1).AddMonths(1).AddDays(-1).Day;
                    //fin de codigo

                    string Codigo = row.Cells["Id_Detalle_Programacion"].Value.ToString();


                    CultureInfo ci = new CultureInfo("es-ES");

                    int FechaPagara = Convert.ToInt32(FechaPago);

                    if (FechaPagara > endOfMonth)
                    {
                        FechaFormateada = endOfMonth + "/" + Fecha2.ToString("MM", ci) + "/" + Fecha2.ToString("yyyy", ci);
                        objetoCN2.CambiarFecha(Convert.ToDateTime(FechaFormateada), Codigo);

                    }
                    else if (FechaPagara <= endOfMonth)
                    {
                        FechaFormateada = FechaPagara + "/" + Fecha2.ToString("MM", ci) + "/" + Fecha2.ToString("yyyy", ci);
                        objetoCN2.CambiarFecha(Convert.ToDateTime(FechaFormateada), Codigo);

                    }

                    this.objetoCN.ActualizarAutorizado(IdArreglo);

                    this.MostrarSolicitudes();
                    this.Limpiar();


                }

                MessageBox.Show("Se han Modificado las Fechas de pago para los dias " + FechaPago + " de Cada Mes, si no Cumple tendra que cancelar Mora", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.MostrarDetalleVacio();


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.objetoCN.DenegarSolicitud(this.txtIdArreglo.Text);
                MessageBox.Show("Solicitud Denegada", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.MostrarSolicitudes();

                this.MostrarDetalleVacio();

                this.Limpiar();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            this.txtNombreEstudiante.Text = string.Empty;
            this.txtCarnetEstudiante.Text = string.Empty;
            this.txtApellidosEstudiante.Text = string.Empty;
            this.txtObservaciones.Text = string.Empty;
        }
    }
}
