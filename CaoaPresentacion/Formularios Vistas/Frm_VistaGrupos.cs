using CapaDatos;
using CapaNegocio;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CaoaPresentacion.Formularios_Vistas
{

    public partial class Frm_VistaGrupos : Form
    {
        CN_Grupos objetoCN = new CN_Grupos();

        public Frm_VistaGrupos()
        {
            InitializeComponent();
            this.cmbTurnos.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Cargar_ComboDepartamento();
        }

        private void Frm_VistaGrupos_Load(object sender, EventArgs e)
        {
            try
            {

                this.Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema, el error es " + ex);
            }

        }

        private void AgregarBtnDatagridView()
        {
            dataGrupos.Columns.Add(
       new DataGridViewButtonColumn()
       {
           HeaderText = "Seleccionar",
           Name = "Seleccionar",
           Text = "Seleccionar",
           UseColumnTextForButtonValue = true
       });


        }

        public void Cargar_ComboDepartamento()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("Select Id_curso,Nombre_curso from Tbl_Cursos where id_estado = '3' ORDER BY Nombre_curso asc", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Nombre_curso"] = "Selecciona un Curso";
                dt.Rows.InsertAt(fila, 0);

                cmbTurnos.ValueMember = "Id_curso";
                cmbTurnos.DisplayMember = "Nombre_curso";
                cmbTurnos.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema, el error es " + ex);
            }

        }

        private void Mostrar()
        {
            CN_Grupos objetoCN = new CN_Grupos();
            dataGrupos.DataSource = objetoCN.MostrarGrupos(this.cmbTurnos.Text);
        }

        private void cmbTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.AgregarBtnDatagridView();
            this.Mostrar();
        }

        private void dataGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataGrupos.Columns[e.ColumnIndex].Name == "Seleccionar")
                {

                    CacheDatos.Id_Grupo = this.dataGrupos.CurrentRow.Cells["Id_Grupo"].Value.ToString();
                    MessageBox.Show("Grupo Seleccionado Correctamente");
                    this.Hide();
                    CacheDatos.Contador2 = true;


                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema, el Error es " + ex);
            }
        }
    }
}
