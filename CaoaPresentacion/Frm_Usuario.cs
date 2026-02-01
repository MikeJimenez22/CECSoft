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
using Utils;

namespace CaoaPresentacion
{
    public partial class Frm_Usuario : Form
    {
        public Frm_Usuario()
        {
            InitializeComponent();
            this.cmbEstados.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSucursales.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CargarSucursales();
            DataGridViewConfigurator.Configure(this.dataUsuarios,this.dataEmpleados);
        }

        string IdEstado;

        private void Frm_Usuario_Load(object sender, EventArgs e)
        {
            try
            {
                this.IdEstado = "3";

                this.CargaInicial();
                this.AgregarColumnaConIcono();
                this.MostrarEmpleadosActivos();
                this.ObtenerUsuarios(IdEstado);
                MostrarRequisitos(txtContraseña.Text);


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargaInicial()
        {
            try
            {
                this.cmbEstados.Text = "Activos";
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.ObtenerUsuarios(IdEstado);
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerUsuarios(string IdEstado)
        {
            try
            {
                CN_Usuarios objetoCN = new CN_Usuarios();
                this.dataUsuarios.DataSource = objetoCN.ObtenerUsuariosPorEstado(IdEstado);


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbEstados.Text == "Activos")
                {
                    this.IdEstado = "3";
                }else if (this.cmbEstados.Text == "Inactivos")
                {
                    this.IdEstado = "4";
                }
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
                dataUsuarios.Columns.Add(btnColumna);


                // Agregar columna de botón
                DataGridViewButtonColumn btnAceptar = new DataGridViewButtonColumn();
                btnAceptar.HeaderText = "Seleccionar";
                btnAceptar.Name = "Seleccionar";
                btnAceptar.Text = ""; // El texto no se usará porque dibujaremos un ícono
                btnAceptar.UseColumnTextForButtonValue = false;
                dataEmpleados.Columns.Add(btnAceptar);

                // Evento para pintar el botón con un ícono
                dataUsuarios.CellPainting += dataUsuarios_CellPainting;
                dataEmpleados.CellPainting += dataEmpleados_CellPainting;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataUsuarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataUsuarios.Columns["Actualizar"].Index && e.RowIndex >= 0)
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

           
        }


        private void dataEmpleados_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            


            if (e.ColumnIndex == dataEmpleados.Columns["Seleccionar"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Cargar el ícono desde recursos (recomendado) o archivo
                Bitmap icon = Properties.Resources._728898_page_folder_add_plus_file_icon; // Usa tu recurso de imagen
                int iconWidth = 16;
                int iconHeight = 16;

                // Posición centrada en la celda
                int x = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                e.Graphics.DrawImage(icon, new Rectangle(x, y, iconWidth, iconHeight));
                e.Handled = true; // Indica que la celda está completamente pintada
            }



        }

        private void dataUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Evitar clic en encabezado
                {
                    CN_Usuarios objetoCN = new CN_Usuarios();

                    // Detectar columna presionada
                    if (e.ColumnIndex == dataUsuarios.Columns["Actualizar"].Index)
                    {
                        string Estado = this.dataUsuarios.CurrentRow.Cells["Estado"].Value.ToString();
                        
                        if (Estado == "Activo")
                        {
                            objetoCN.Inactivar(this.dataUsuarios.CurrentRow.Cells["Id_usuario"].Value.ToString());
                            MessageBox.Show("Usuario Inactivado Correctamente", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.ObtenerUsuarios(IdEstado);
                        }
                        else if (Estado == "Inactivo")
                        {
                            
                            objetoCN.Activar(this.dataUsuarios.CurrentRow.Cells["Id_usuario"].Value.ToString());
                            MessageBox.Show("Usuario Activado Correctamente","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            this.ObtenerUsuarios(IdEstado);
                        }
                    }
                }
                
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
                this.tabControl1.SelectedIndex = 1;

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedIndex = 2;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                bool hayError = false;

                // Limpiar errores antes de validar
                errorProvider1.Clear();

                if (string.IsNullOrWhiteSpace(txtIdEmpleado.Text))
                {
                    errorProvider1.SetError(txtNombres, "Selecciona un usuario");
                    hayError = true;
                }

                if (string.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    errorProvider1.SetError(txtUsuario, "Selecciona un usuario");
                    hayError = true;
                }

                if (string.IsNullOrWhiteSpace(txtContraseña.Text))
                {
                    errorProvider1.SetError(txtContraseña, "Selecciona una contraseña");
                    hayError = true;
                }

                if (cmbSucursales.Text == "Selecciona una sucursal")
                {
                    errorProvider1.SetError(cmbSucursales, "Selecciona una sucursal");
                    hayError = true;
                }

                if (hayError)
                {
                    MessageBox.Show("Por favor corrige los errores antes de continuar", "SISTEMA CECNIC",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Evita continuar si hay errores
                }

                DataTable tabla = new DataTable();
                CN_Usuarios objetoCN = new CN_Usuarios();
                tabla = objetoCN.MostrarUsuarios(this.txtUsuario.Text);
                if (tabla.Rows.Count != 0)
                {
                    MessageBox.Show("Este Usuario Ya existe, Ingrese otro Por favor");

                }
                else if(tabla.Rows.Count == 0)
                {
                    if (ValidarContraseña(this.txtContraseña.Text, this.txtContraseña) == true)
                    {
                        string fechaActual = DateTime.Now.ToShortDateString();
                        objetoCN.Insertar(this.txtIdEmpleado.Text,this.txtUsuario.Text,this.txtContraseña.Text,fechaActual,"3","0",this.cmbSucursales.SelectedValue.ToString());
                        MessageBox.Show("Usuario Guardado Correctamente","SISTEMA CECNIC",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        this.Hide();
                        Frm_Usuario frm = new Frm_Usuario();
                        frm.Show();
                        
                    }
                   

                }


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void MostrarRequisitos(string contraseña)
        {
            
            
            // Validaciones
            bool largo = contraseña.Length >= 5;
            bool mayuscula = contraseña.Any(char.IsUpper);
            bool minuscula = contraseña.Any(char.IsLower);
            bool numero = contraseña.Any(char.IsDigit);
            bool especial = contraseña.Any(c => "!@#$%^&*()_+-=[]{}|;:,.<>?".Contains(c));
            bool sinEspacios = !contraseña.Contains(" ");
            bool sinConsecutivos = !TieneNumerosConsecutivos(contraseña);

            // Construimos el checklist con ✔ ❌ y colores en varias líneas
            lblRequisitos.Text =
                $"{(largo ? "✅" : "❌")} Mínimo 5 caracteres{Environment.NewLine}" +
                $"{(mayuscula ? "✅" : "❌")} Una letra mayúscula{Environment.NewLine}" +
                $"{(minuscula ? "✅" : "❌")} Una letra minúscula{Environment.NewLine}" +
                $"{(numero ? "✅" : "❌")} Un número{Environment.NewLine}" +
                $"{(especial ? "✅" : "❌")} Un carácter especial (!@#$...){Environment.NewLine}" +
                $"{(sinEspacios ? "✅" : "❌")} Sin espacios{Environment.NewLine}" +
                $"{(sinConsecutivos ? "✅" : "❌")} Sin números consecutivos";
        }

        private bool TieneNumerosConsecutivos(string texto)
        {
            int consecutivosAsc = 1;
            int consecutivosDesc = 1;

            for (int i = 1; i < texto.Length; i++)
            {
                if (char.IsDigit(texto[i]) && char.IsDigit(texto[i - 1]))
                {
                    int actual = (int)char.GetNumericValue(texto[i]);
                    int anterior = (int)char.GetNumericValue(texto[i - 1]);

                    if (actual == anterior + 1) // Ascendente (1,2)
                    {
                        consecutivosAsc++;
                        consecutivosDesc = 1;
                    }
                    else if (actual == anterior - 1) // Descendente (3,2)
                    {
                        consecutivosDesc++;
                        consecutivosAsc = 1;
                    }
                    else
                    {
                        consecutivosAsc = 1;
                        consecutivosDesc = 1;
                    }

                    if (consecutivosAsc >= 3 || consecutivosDesc >= 3)
                    {
                        return true; // Hay 3 o más números consecutivos
                    }
                }
                else
                {
                    consecutivosAsc = 1;
                    consecutivosDesc = 1;
                }
            }

            return false; // No hay números consecutivos
        }



        private bool ValidarContraseña(string contraseña, Control control)
        {
            // Limpiamos errores previos para ese control
            errorProvider1.SetError(control, "");

            if (string.IsNullOrWhiteSpace(contraseña))
            {
                errorProvider1.SetError(control, "La contraseña es obligatoria.");
                return false;
            }

            if (contraseña.Length < 5)
            {
                errorProvider1.SetError(control, "Debe tener al menos 5 caracteres.");
                return false;
            }

            if (!contraseña.Any(char.IsUpper))
            {
                errorProvider1.SetError(control, "Debe contener al menos una letra mayúscula.");
                return false;
            }

            if (!contraseña.Any(char.IsLower))
            {
                errorProvider1.SetError(control, "Debe contener al menos una letra minúscula.");
                return false;
            }

            if (!contraseña.Any(char.IsDigit))
            {
                errorProvider1.SetError(control, "Debe contener al menos un número.");
                return false;
            }

            if (!contraseña.Any(c => "!@#$%^&*()_+-=[]{}|;:,.<>?".Contains(c)))
            {
                errorProvider1.SetError(control, "Debe contener al menos un carácter especial.");
                return false;
            }

            if (contraseña.Contains(" "))
            {
                errorProvider1.SetError(control, "No se permiten espacios en blanco.");
                return false;
            }

            // ✅ Validar que no haya números consecutivos
            if (TieneNumerosConsecutivos2(contraseña))
            {
                errorProvider1.SetError(control, "No debe contener números consecutivos (ej. 123 o 4567).");
                return false;
            }

            return true; // ✅ La contraseña cumple todas las condiciones
        }

        private bool TieneNumerosConsecutivos2(string texto)
        {
            int consecutivosAsc = 1;
            int consecutivosDesc = 1;

            for (int i = 1; i < texto.Length; i++)
            {
                if (char.IsDigit(texto[i]) && char.IsDigit(texto[i - 1]))
                {
                    int actual = (int)char.GetNumericValue(texto[i]);
                    int anterior = (int)char.GetNumericValue(texto[i - 1]);

                    if (actual == anterior + 1)
                    {
                        consecutivosAsc++;
                        consecutivosDesc = 1; // reset descendente
                    }
                    else if (actual == anterior - 1)
                    {
                        consecutivosDesc++;
                        consecutivosAsc = 1; // reset ascendente
                    }
                    else
                    {
                        consecutivosAsc = 1;
                        consecutivosDesc = 1;
                    }

                    if (consecutivosAsc >= 3 || consecutivosDesc >= 3)
                    {
                        return true; // Hay una secuencia de al menos 3 números consecutivos
                    }
                }
                else
                {
                    consecutivosAsc = 1;
                    consecutivosDesc = 1;
                }
            }

            return false;
        }


        private void CargarSucursales()
        {
            try
            {
                CD_Conexion conexion = new CD_Conexion();
                conexion.AbrirConexion();
                SqlCommand cmd = new SqlCommand("select Id_sucursal,NombreSucursal from TblSucursales", conexion.Conexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.CerrarConexion();

                DataRow fila = dt.NewRow();
                fila["NombreSucursal"] = "Selecciona una sucursal";
                dt.Rows.InsertAt(fila, 0);

                cmbSucursales.ValueMember = "Id_sucursal";
                cmbSucursales.DisplayMember = "NombreSucursal";
                cmbSucursales.DataSource = dt;

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarEmpleadosActivos()
        {
            try
            {
                CN_Empleados objetoCN = new CN_Empleados();
                this.dataEmpleados.DataSource = objetoCN.Mostrar();
                this.dataEmpleados.Columns["Id_empleado"].Visible = false;
                this.dataEmpleados.Columns["Id_estado"].Visible = false;
                this.dataEmpleados.Columns["Id_persona"].Visible = false;

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
                if (e.RowIndex >= 0) // Evitar clic en encabezado
                {
                  

                    // Detectar columna presionada
                    if (e.ColumnIndex == dataEmpleados.Columns["Seleccionar"].Index)
                    {
                        // string Estado = this.dataUsuarios.CurrentRow.Cells["Estado"].Value.ToString();
                        this.txtNombres.Text = this.dataEmpleados.CurrentRow.Cells["Nombres"].Value.ToString();
                        this.txtApellidos.Text = this.dataEmpleados.CurrentRow.Cells["Apellidos"].Value.ToString();
                        this.txtCarnet.Text = this.dataEmpleados.CurrentRow.Cells["Cod_Carnet"].Value.ToString();
                        this.txtIdEmpleado.Text = this.dataEmpleados.CurrentRow.Cells["Id_empleado"].Value.ToString();

                        
                    }
                }

                this.tabControl1.SelectedIndex = 1;

            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 1;
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            MostrarRequisitos(txtContraseña.Text);
        }
    }
}
