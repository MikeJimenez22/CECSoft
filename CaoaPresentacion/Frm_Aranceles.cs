using CapaDatos;
using CapaNegocio;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CaoaPresentacion
{
    public partial class Frm_Aranceles : Form
    {
        public Frm_Aranceles()
        {
            InitializeComponent();

            this.cmbIdeEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTipoMoneda.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;

            this.Cargar_ComboMoneda();
            this.Cargar_ComboEstados();

        }

        CD_Conexion conexion = new CD_Conexion();

        CN_Aranceles objetoCN = new CN_Aranceles();


        bool Editar = false;
        string IdArancel;

        private void Frm_Aranceles_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            

            this.cmbTipo.Text = "ROC";
        }


        public void Cargar_ComboMoneda()
        {
            try
            {

                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("Select IdMoneda,Simbolo from Tbl_TipoMoneda", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Simbolo"] = "Selecciona una Moneda";
                dt.Rows.InsertAt(fila, 0);

                cmbTipoMoneda.ValueMember = "IdMoneda";
                cmbTipoMoneda.DisplayMember = "Simbolo";
                cmbTipoMoneda.DataSource = dt;


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Cargar_ComboEstados()
        {
            try
            {

                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("Select Id_estado,Estado from Tbl_Estados where Id_estado ='3' or Id_estado = '4' ", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Estado"] = "Selecciona el estado del Arancel";
                dt.Rows.InsertAt(fila, 0);

                cmbIdeEstado.ValueMember = "Id_estado";
                cmbIdeEstado.DisplayMember = "Estado";
                cmbIdeEstado.DataSource = dt;


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void Mostrar()
        {
            CN_Aranceles objetoCN = new CN_Aranceles();
            this.dataAranceles.DataSource = objetoCN.Mostrar();

        }

        private void dataAranceles_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataAranceles.Rows.Count == 0)
                {
                    MessageBox.Show("No hay ningun Registro en la Tabla");
                }
                else if (this.dataAranceles.Rows.Count != 0)
                {
                    this.txtNombreArancel.Text = this.dataAranceles.CurrentRow.Cells["Nombre_Arancel"].Value.ToString();
                    this.txtPrecioArancel.Text = this.dataAranceles.CurrentRow.Cells["Precio"].Value.ToString();
                    this.cmbTipoMoneda.Text = this.dataAranceles.CurrentRow.Cells["Simbolo"].Value.ToString();
                    this.cmbIdeEstado.Text = this.dataAranceles.CurrentRow.Cells["Estado"].Value.ToString();
                    this.IdArancel = this.dataAranceles.CurrentRow.Cells["Id_Arancel"].Value.ToString();
                    this.cmbTipo.Text = this.dataAranceles.CurrentRow.Cells["Tipo"].Value.ToString();


                    this.Editar = true;
                    this.tabControl1.SelectedIndex = 1;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error de sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Editar == false)
                {
                    if (this.txtNombreArancel.Text == string.Empty)
                    {
                        MessageBox.Show("El campo Nombre se encuentra Vacio");
                    }
                    else
                    {
                        objetoCN.InsertarArancel(this.txtNombreArancel.Text, this.txtPrecioArancel.Text, this.cmbTipoMoneda.SelectedValue.ToString(), this.cmbIdeEstado.SelectedValue.ToString(), this.cmbTipo.Text);
                        MessageBox.Show("Se ha registrado Correctamente el Aramcel", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Limpiar();
                        this.Mostrar();
                        this.tabControl1.SelectedIndex = 0;
                    }

                }
                else if (Editar == true)
                {
                    objetoCN.EditarArancel(IdArancel, this.txtNombreArancel.Text, this.txtPrecioArancel.Text, this.cmbTipoMoneda.SelectedValue.ToString(), this.cmbIdeEstado.SelectedValue.ToString(), this.cmbTipo.Text);
                    MessageBox.Show("Se ha modificado Correctamente el Arancel", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Limpiar();
                    this.Mostrar();
                    this.tabControl1.SelectedIndex = 0;

                    Editar = false;

                }


            }
            catch (Exception)
            {
                MessageBox.Show("Error de sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }


        private void Limpiar()
        {
            this.txtNombreArancel.Text = string.Empty;
            this.txtPrecioArancel.Text = string.Empty;
            this.Cargar_ComboEstados();
            this.Cargar_ComboMoneda();
            this.cmbTipo.Text = "ROC";

        }
    }
}
