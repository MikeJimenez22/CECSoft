using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapaNegocio;
using CapaDatos;
namespace CaoaPresentacion
{
    public partial class FrmCursos_turno : Form
    {
        public FrmCursos_turno()
        {
            InitializeComponent();
            this.cmbEstados.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCurso.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTurnos.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMoneda.DropDownStyle = ComboBoxStyle.DropDownList;

            this.CargarCombobox();
        }

        string IdEstado;
        bool Guardar = false;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarCursoTurno();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void MostrarCursoTurno()
        {
            try
            {
                CN_Cursos_Turnos objetoCN = new CN_Cursos_Turnos();
                this.dataCursoTurno.DataSource = objetoCN.MostrarCursoTurnoPorEstado(IdEstado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " +ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbEstados.Text == "Activos")
                {
                    IdEstado = "3";
                }else if (this.cmbEstados.Text == "Inactivos")
                {
                    IdEstado = "4";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmCursos_turno_Load(object sender, EventArgs e)
        {
            try
            {
                this.cmbEstados.Text = "Activos";
                this.AgregarColumnaConIcono();
                this.MostrarCursoTurno();
                this.dataCursoTurno.Columns["Id_Curso_turno"].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarColumnaConIcono()
        {
            try
            {
                // Agregar columna de botón
                DataGridViewButtonColumn btnColumna = new DataGridViewButtonColumn();
                btnColumna.HeaderText = "Actualizar estado";
                btnColumna.Name = "Actualizar";
                btnColumna.Text = ""; // El texto no se usará porque dibujaremos un ícono
                btnColumna.UseColumnTextForButtonValue = false;
                dataCursoTurno.Columns.Add(btnColumna);

                // Agregar columna de botón
                DataGridViewButtonColumn btnColumna2 = new DataGridViewButtonColumn();
                btnColumna2.HeaderText = "Editar";
                btnColumna2.Name = "Editar";
                btnColumna2.Text = ""; // El texto no se usará porque dibujaremos un ícono
                btnColumna2.UseColumnTextForButtonValue = false;
                dataCursoTurno.Columns.Add(btnColumna2);


                // Evento para pintar el botón con un ícono
                dataCursoTurno.CellPainting += datacursosTurno_CellPainting;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void datacursosTurno_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataCursoTurno.Columns["Actualizar"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Cargar el ícono desde recursos (recomendado) o archivo
                Bitmap icon = Properties.Resources._118839_applications_system_applications_system; // Usa tu recurso de imagen
                int iconWidth = 16;
                int iconHeight = 16;

                // Posición centrada en la celda
                int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));
                e.Handled = true; // Indica que la celda está completamente pintada
            }

            if (e.ColumnIndex == dataCursoTurno.Columns["Editar"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Cargar el ícono desde recursos (recomendado) o archivo
                Bitmap icon = Properties.Resources._473629_configure_options_preferences_repair_settings_icon; // Usa tu recurso de imagen
                int iconWidth = 16;
                int iconHeight = 16;

                // Posición centrada en la celda
                int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));
                e.Handled = true; // Indica que la celda está completamente pintada
            }

        }

        private void dataCursoTurno_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Evitar clic en encabezado
                {


                    // Detectar columna presionada
                    if (e.ColumnIndex == dataCursoTurno.Columns["Actualizar"].Index)
                    {
                        string Estado = this.dataCursoTurno.CurrentRow.Cells["Estado"].Value.ToString();
                        string IdCursoTurno = this.dataCursoTurno.CurrentRow.Cells["Id_Curso_turno"].Value.ToString();

                        if (Estado == "Activo")
                        {
                            CN_Cursos_Turnos objetoCN = new CN_Cursos_Turnos();
                            objetoCN.ActualizarEstadoCurso(IdCursoTurno,"4");
                            MessageBox.Show("Registro Inactivado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.MostrarCursoTurno();
                        }
                        else if (Estado == "Inactivo")
                        {
                            CN_Cursos_Turnos objetoCN = new CN_Cursos_Turnos();
                            objetoCN.ActualizarEstadoCurso(IdCursoTurno, "3");
                            MessageBox.Show("Registro Activado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.MostrarCursoTurno();
                        }
                    }else if (e.ColumnIndex == dataCursoTurno.Columns["Editar"].Index)
                    {
                        this.Guardar = false;
                        this.txtIdCursoTurno.Text = this.dataCursoTurno.CurrentRow.Cells["Id_Curso_turno"].Value.ToString();
                        this.cmbCurso.Text = this.dataCursoTurno.CurrentRow.Cells["Nombre_curso"].Value.ToString();
                        string Turno = this.dataCursoTurno.CurrentRow.Cells["Turno"].Value.ToString();
                        string Dias = this.dataCursoTurno.CurrentRow.Cells["Dias"].Value.ToString();
                        this.cmbTurnos.Text = Turno + "-" + Dias;
                        this.cmbMoneda.Text = this.dataCursoTurno.CurrentRow.Cells["Descripcion"].Value.ToString();
                        this.txtPrecio.Text = this.dataCursoTurno.CurrentRow.Cells["Precio"].Value.ToString();
                        this.tabControl1.SelectedIndex = 1;
                       
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void Cargar_Cursos()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("select Id_curso,Nombre_curso from Tbl_Cursos where id_estado = 3 order by Nombre_curso ASC", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Nombre_curso"] = "Selecciona un Curso";
                dt.Rows.InsertAt(fila, 0);

                cmbCurso.ValueMember = "Id_curso";
                cmbCurso.DisplayMember = "Nombre_curso";
                cmbCurso.DataSource = dt;


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public void Cargar_Turnos()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("select Id_turno,CONCAT(Turno,'-',Dias) as Turno  from Tbl_Turnos where Id_estado = 3", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Turno"] = "Selecciona un Turno";
                dt.Rows.InsertAt(fila, 0);

                cmbTurnos.ValueMember = "Id_turno";
                cmbTurnos.DisplayMember = "Turno";
                cmbTurnos.DataSource = dt;


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        
                 public void Cargar_Moneda()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("select IdMoneda, Descripcion from Tbl_TipoMoneda", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Descripcion"] = "Selecciona una Moneda";
                dt.Rows.InsertAt(fila, 0);

                cmbMoneda.ValueMember = "IdMoneda";
                cmbMoneda.DisplayMember = "Descripcion";
                cmbMoneda.DataSource = dt;

                
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnNuevoRol_Click(object sender, EventArgs e)
        {
            try
            {
                this.Guardar = true;
                this.CargarCombobox();
                this.tabControl1.SelectedIndex = 1;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCombobox()
        {
            try
            {
                this.Cargar_Cursos();
                this.Cargar_Moneda();
                this.Cargar_Turnos();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.CargarCombobox();
            this.txtPrecio.Text = string.Empty;
            this.tabControl1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Guardar == true)
                {
                    CN_Cursos_Turnos objetoCN = new CN_Cursos_Turnos();
                    objetoCN.InsertarCursoTurno(this.cmbCurso.SelectedValue.ToString(),this.cmbTurnos.SelectedValue.ToString(),this.txtPrecio.Text,"3",this.cmbMoneda.SelectedValue.ToString());
                    MessageBox.Show("Registrado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.MostrarCursoTurno();
                    this.CargarCombobox();
                    this.txtPrecio.Text = string.Empty;
                    this.tabControl1.SelectedIndex = 0;
                 
                }else if (Guardar == false)
                {
                    CN_Cursos_Turnos objetoCN = new CN_Cursos_Turnos();
                    objetoCN.Editar(this.txtIdCursoTurno.Text,this.cmbCurso.SelectedValue.ToString(),this.cmbTurnos.SelectedValue.ToString(),this.txtPrecio.Text,this.cmbMoneda.SelectedValue.ToString());
                    MessageBox.Show("Editado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.MostrarCursoTurno();
                    this.CargarCombobox();
                    this.txtPrecio.Text = string.Empty;
                    this.tabControl1.SelectedIndex = 0;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
