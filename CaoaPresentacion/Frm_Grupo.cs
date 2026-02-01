using CapaDatos;
using CapaNegocio;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CaoaPresentacion
{
    public partial class Frm_Grupo : Form
    {


        public Frm_Grupo()
        {
            InitializeComponent();
            this.Cargar_Cursos();
            this.Cargar_Estados();
            this.Cargar_Turnos();
            this.Cargar_CursosTurno();
            this.cmbTurnos.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbEstados.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTurno.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCursos.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        bool Accion = false;



        private void Frm_Grupo_Load(object sender, EventArgs e)
        {
            try
            {
                this.AgregarBtnDatagridView();
                this.AgregarBtnDatagridViewEmpleados();
                this.AgregarBtnDatagridViewHorarios();
                this.AgregarBtnDatagridViewEstados();
                this.AgregarBtnDatagridViewCursosTurno();
                this.tabControl1.SelectedIndex = 0;
                this.Accion = false;
                ConfigurarControles(Accion);
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarBtnDatagridView()
        {
            dataGrupos.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Editar",
                Name = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true

            });

            DataGridViewColumn columna = dataGrupos.Columns["Editar"];

            // Establece el ancho deseado para la columna (en píxeles)
            columna.Width = 50;
        }

        private void AgregarBtnDatagridViewEmpleados()
        {
            dataEmpleados.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Seleccionar",
                Name = "Seleccionar",
                Text = "Seleccionar",
                UseColumnTextForButtonValue = true

            });

            DataGridViewColumn columna = dataEmpleados.Columns["Seleccionar"];
            // Establece el ancho deseado para la columna (en píxeles)
            columna.Width = 50;
        }

        private void AgregarBtnDatagridViewHorarios()
        {
            dataHorarios.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Seleccionar",
                Name = "Seleccionar",
                Text = "Seleccionar",
                UseColumnTextForButtonValue = true

            });

            DataGridViewColumn columna = dataHorarios.Columns["Seleccionar"];
            // Establece el ancho deseado para la columna (en píxeles)
            columna.Width = 50;
        }

        private void AgregarBtnDatagridViewEstados()
        {
            dataEstados.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Seleccionar",
                Name = "Seleccionar",
                Text = "Seleccionar",
                UseColumnTextForButtonValue = true

            });

            DataGridViewColumn columna = dataEstados.Columns["Seleccionar"];
            // Establece el ancho deseado para la columna (en píxeles)
            columna.Width = 50;
        }

        private void AgregarBtnDatagridViewCursosTurno()
        {
            dataCursosTurnos.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Seleccionar",
                Name = "Seleccionar",
                Text = "Seleccionar",
                UseColumnTextForButtonValue = true

            });

            DataGridViewColumn columna = dataCursosTurnos.Columns["Seleccionar"];
            // Establece el ancho deseado para la columna (en píxeles)
            columna.Width = 50;
        }

        public void Cargar_Cursos()
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


        public void Cargar_CursosTurno()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("Select Id_curso,Nombre_curso from Tbl_Cursos", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Nombre_curso"] = "Selecciona un Curso";
                dt.Rows.InsertAt(fila, 0);

                cmbCursos.ValueMember = "Id_curso";
                cmbCursos.DisplayMember = "Nombre_curso";
                cmbCursos.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema, el error es " + ex);
            }
        }


        public void Cargar_Estados()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("select Id_estado,Estado from Tbl_Estados where Id_estado = 3 or Id_estado = 4", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Estado"] = "Selecciona un Estado";
                dt.Rows.InsertAt(fila, 0);

                cmbEstados.ValueMember = "Id_estado";
                cmbEstados.DisplayMember = "Estado";
                cmbEstados.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema, el error es " + ex);
            }
        }

        public void Cargar_Turnos()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("select Id_turno,Dias from Tbl_Turnos where Id_estado = '3'", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["Dias"] = "Selecciona un dia";
                dt.Rows.InsertAt(fila, 0);

                cmbTurno.ValueMember = "Id_turno";
                cmbTurno.DisplayMember = "Dias";
                cmbTurno.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema, el error es " + ex);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbTurnos.Text == "Selecciona un Curso")
                {
                    MessageBox.Show("Error, selecciona un curso", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (this.cmbEstados.Text == "Selecciona un Estado")
                {
                    MessageBox.Show("Error, selecciona un estado", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CN_Grupos objetoCN = new CN_Grupos();
                    this.dataGrupos.DataSource = objetoCN.MostrarPorGrupoPorEstado(this.cmbEstados.Text, this.cmbTurnos.Text);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarDocentesActivos()
        {
            CN_Empleados objetoCN = new CN_Empleados();
            this.dataEmpleados.DataSource = objetoCN.MostrarDocentesActivos();
        }

        private void MostrarEstados()
        {
            CN_Estados objetoCN = new CN_Estados();
            this.dataEstados.DataSource = objetoCN.MostrarEstados();
        }

        private void dataGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (this.dataGrupos.Columns[e.ColumnIndex].Name == "Editar")
                {

                    this.txtIdGrupo.Text = this.dataGrupos.CurrentRow.Cells["Id_Grupo"].Value.ToString();
                    this.txtNombreCurso.Text = this.dataGrupos.CurrentRow.Cells["Nombre_curso"].Value.ToString();
                    this.txtNombres.Text = this.dataGrupos.CurrentRow.Cells["Nombres"].Value.ToString();
                    this.txtApellidos.Text = this.dataGrupos.CurrentRow.Cells["Apellidos"].Value.ToString();
                    this.txtCedula.Text = this.dataGrupos.CurrentRow.Cells["Cedula"].Value.ToString();
                    this.txtTipoEmpleado.Text = this.dataGrupos.CurrentRow.Cells["Tipo_Empleado"].Value.ToString();
                    this.txtDuracion.Text = this.dataGrupos.CurrentRow.Cells["Duracion"].Value.ToString();
                    this.txtTurno.Text = this.dataGrupos.CurrentRow.Cells["Turno"].Value.ToString();
                    this.txtPrecio.Text = this.dataGrupos.CurrentRow.Cells["Precio"].Value.ToString();
                    this.txtSimboloMoneda.Text = this.dataGrupos.CurrentRow.Cells["Simbolo"].Value.ToString();
                    this.txtEstado.Text = this.dataGrupos.CurrentRow.Cells["Estado"].Value.ToString();
                    this.txtHorario.Text = this.dataGrupos.CurrentRow.Cells["Horario"].Value.ToString();
                    this.txtIdCursoTurno.Text = this.dataGrupos.CurrentRow.Cells["Id_Curso_turno"].Value.ToString();
                    this.txtIdHorario.Text = this.dataGrupos.CurrentRow.Cells["Id_Horario"].Value.ToString();
                    this.txtIdDocente.Text = this.dataGrupos.CurrentRow.Cells["Id_empleado"].Value.ToString();
                    this.txtIdEstado.Text = this.dataGrupos.CurrentRow.Cells["Id_estado"].Value.ToString();

                    this.Accion = false;
                    ConfigurarControles(Accion);
                    string text = txtEstado.Text;
                    this.CambiarColorEstado(text);


                    this.tabControl1.SelectedIndex = 1;



                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void CambiarColorEstado(string text)
        {
            // Cambia el color del panel basado en el texto
            switch (text)
            {
                case "Activo":
                    panelEstado.BackColor = Color.Green;
                    break;
                case "Inactivo":
                    panelEstado.BackColor = Color.Red;
                    break;

                default:
                    panelEstado.BackColor = Color.Gray; // Color predeterminado
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Accion = true;
                this.LimpiarControles();
                ConfigurarControles(Accion);
                this.tabControl1.SelectedIndex = 1;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarControles(bool Estado)
        {
            if (Estado == false)
            {
                this.btnCursoTurno.Enabled = false;
                this.btnDocente.Enabled = true;
                this.btnTurn.Enabled = true;
                this.btnEstadoGrupo.Enabled = true;
            }
            else if (Estado == true)
            {
                this.btnCursoTurno.Enabled = true;
                this.btnDocente.Enabled = true;
                this.btnTurn.Enabled = true;
                this.btnEstadoGrupo.Enabled = false;
                this.txtIdEstado.Text = "3";
                this.txtEstado.Text = "Activo";
                string text = txtEstado.Text;
                this.CambiarColorEstado(text);
            }
        }

        private void btnDocente_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarDocentesActivos();
                this.tabControl1.SelectedIndex = 2;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (this.dataEmpleados.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                    this.txtNombres.Text = this.dataEmpleados.CurrentRow.Cells["Nombres"].Value.ToString();
                    this.txtApellidos.Text = this.dataEmpleados.CurrentRow.Cells["Apellidos"].Value.ToString();
                    this.txtCedula.Text = this.dataEmpleados.CurrentRow.Cells["Cedula"].Value.ToString();
                    this.txtTipoEmpleado.Text = this.dataEmpleados.CurrentRow.Cells["Tipo_Empleado"].Value.ToString();
                    this.txtIdDocente.Text = this.dataEmpleados.CurrentRow.Cells["Id_empleado"].Value.ToString();


                    this.tabControl1.SelectedIndex = 1;
                    MessageBox.Show("Docente seleccionado correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarHorarios_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbTurno.Text == "Selecciona un dia")
                {
                    MessageBox.Show("Error, seleccione un dia", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    CN_Horarios objetoCN = new CN_Horarios();
                    this.dataHorarios.DataSource = objetoCN.MostrarHorariosPorTurno(this.cmbTurno.Text);
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("Error de Sistema " + EX, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataHorarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (this.dataHorarios.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                    //this.txtNombres.Text = this.dataEmpleados.CurrentRow.Cells["Nombres"].Value.ToString();
                    this.txtTurno.Text = this.dataHorarios.CurrentRow.Cells["Turno"].Value.ToString();
                    this.txtHorario.Text = this.dataHorarios.CurrentRow.Cells["Horario"].Value.ToString();
                    this.txtIdHorario.Text = this.dataHorarios.CurrentRow.Cells["Id_Horario"].Value.ToString();

                    this.tabControl1.SelectedIndex = 1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTurn_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 3;
        }

        private void btnEstadoGrupo_Click(object sender, EventArgs e)
        {
            this.MostrarEstados();
            this.tabControl1.SelectedIndex = 4;
        }

        private void dataEstados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (this.dataHorarios.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                    //this.txtNombres.Text = this.dataEmpleados.CurrentRow.Cells["Nombres"].Value.ToString();
                    this.txtEstado.Text = this.dataEstados.CurrentRow.Cells["Estado"].Value.ToString();
                    this.txtIdEstado.Text = this.dataEstados.CurrentRow.Cells["Id_estado"].Value.ToString();

                    this.tabControl1.SelectedIndex = 1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Accion == false) // para Actualizar un grupo
                {
                    CN_Grupos objetoCN = new CN_Grupos();
                    objetoCN.ActualizarGrupo(this.txtIdGrupo.Text, this.txtIdHorario.Text, this.txtIdDocente.Text, this.txtIdEstado.Text);
                    MessageBox.Show("Grupo Actualizado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.tabControl1.SelectedIndex = 0;
                    this.Accion = false;
                    this.LimpiarControles();
                }
                else if (Accion == true) // para crear un nuevo grupo
                {
                    if (this.txtIdCursoTurno.Text == string.Empty)
                    {
                        MessageBox.Show("Seleccione el curso", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (this.txtIdDocente.Text == string.Empty)
                    {
                        MessageBox.Show("Seleccione el Docente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (this.txtHorario.Text == string.Empty)
                    {
                        MessageBox.Show("Seleccione el Horario", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        CN_Grupos objetoCN = new CN_Grupos();
                        objetoCN.CrearNuevoGrupo(this.txtIdCursoTurno.Text, this.txtIdHorario.Text, this.txtIdDocente.Text, this.txtIdEstado.Text);
                        MessageBox.Show("Grupo Creado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.tabControl1.SelectedIndex = 0;
                        this.Accion = false;
                        this.LimpiarControles();
                    }

                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("Error de Sistema" + EX, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarControles()
        {

            this.txtIdGrupo.Text = string.Empty;
            this.txtIdCursoTurno.Text = string.Empty;
            this.txtNombreCurso.Text = string.Empty;
            this.txtIdDocente.Text = string.Empty;
            this.txtNombres.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            this.txtCedula.Text = string.Empty;
            this.txtTipoEmpleado.Text = string.Empty;
            this.txtDuracion.Text = string.Empty;
            this.txtIdHorario.Text = string.Empty;
            this.txtTurno.Text = string.Empty;
            this.txtHorario.Text = string.Empty;
            this.txtSimboloMoneda.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;
            this.txtIdEstado.Text = string.Empty;
            this.txtEstado.Text = string.Empty;

        }

        private void btnCursosPorTurno_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbCursos.Text == "Selecciona un Curso")
                {
                    MessageBox.Show("Error, selecciona un curso", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CN_Cursos_Turnos objetoCN = new CN_Cursos_Turnos();
                    this.dataCursosTurnos.DataSource = objetoCN.MostrarCursosTurnos(this.cmbCursos.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataCursosTurnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (this.dataCursosTurnos.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                    this.txtIdCursoTurno.Text = this.dataCursosTurnos.CurrentRow.Cells["Id_Curso_turno"].Value.ToString();
                    this.txtNombreCurso.Text = this.dataCursosTurnos.CurrentRow.Cells["Nombre_curso"].Value.ToString();
                    this.txtDuracion.Text = this.dataCursosTurnos.CurrentRow.Cells["Duracion"].Value.ToString();
                    this.txtPrecio.Text = this.dataCursosTurnos.CurrentRow.Cells["Precio"].Value.ToString();
                    this.txtSimboloMoneda.Text = this.dataCursosTurnos.CurrentRow.Cells["Simbolo"].Value.ToString();
                    this.cmbTurno.Text = this.dataCursosTurnos.CurrentRow.Cells["Dias"].Value.ToString();
                    this.cmbTurno.Enabled = false;

                    this.tabControl1.SelectedIndex = 1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Sistema " + ex, "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCursoTurno_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 5;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                this.Accion = false;
                this.tabControl1.SelectedIndex = 0;
                this.LimpiarControles();
                this.ConfigurarControles(Accion);
                this.CambiarColorEstado("");
                this.Cargar_CursosTurno();
                this.Cargar_Estados();
                this.Cargar_Turnos();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
