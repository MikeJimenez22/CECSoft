using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Utils;


namespace CaoaPresentacion
{
    public partial class Frm_CuentasporCobrar : Form
    {
        CN_CarterayCobro objetoCN = new CN_CarterayCobro();
        string Estado;
        string date1;
        string date2;
        DataTable TablCelulares = new DataTable();
      






        public Frm_CuentasporCobrar()
        {
            InitializeComponent();

            dataCartera.RowPrePaint += dataCartera_RowPrePaint;
            this.cmbbusquedaMes.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbbusquedaAño.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            DataGridViewConfigurator.Configure(this.dataCartera,this.dataEstadisticasCartera);
        }

        
        private void Frm_CuentasporCobrar_Load(object sender, EventArgs e)
        {
            try
            {

                this.CargarCombos();
                ObtenerMesyAño();

                this.radioButton2.Checked = true;
                this.comboBox1.Text = "Regular";


            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }



        
        private void BuscarEntre_fechas(DateTime fecha1, DateTime fecha2)
        {
            CN_CarterayCobro objetoCN = new CN_CarterayCobro();
            string Turno = this.comboBox1.Text;

            this.dataCartera.DataSource = objetoCN.MostrarPorFechas(fecha1.ToShortDateString(), fecha2.ToShortDateString(), this.Estado, Turno);
            this.lbltotal.Text = Convert.ToString(dataCartera.Rows.Count);
     
        }


        private void BuscarEntre_fechasgeneral(DateTime fecha1, DateTime fecha2)
        {
            CN_CarterayCobro objetoCN = new CN_CarterayCobro();

            this.dataCartera.DataSource = objetoCN.MostrarCarteraGeneral(fecha1.ToShortDateString(), fecha2.ToShortDateString(), this.Estado);
            this.lbltotal.Text = Convert.ToString(dataCartera.Rows.Count);
       
        }

        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.Estado = "Completado";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.Estado = "Pendiente";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            date1 = dateTimePicker1.Text;
        }


        private void dateTimePicker2_ValueChanged_1(object sender, EventArgs e)
        {
            date2 = dateTimePicker2.Text;
        }

      

      

        private void CargarCombos()
        {
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            cmbbusquedaMes.Items.AddRange(meses);

            // Agregar años al ComboBox (ejemplo de 2020 a 2030)
            for (int año = 2020; año <= 2030; año++)
            {
                cmbbusquedaAño.Items.Add(año.ToString());
            }

            // Seleccionar el primer mes y año por defecto
            cmbbusquedaMes.SelectedIndex = 0;
            cmbbusquedaAño.SelectedIndex = 0;
        }

        private void ActualizarFechaSeleccionada()
        {
            if (cmbbusquedaMes.SelectedIndex != -1 && cmbbusquedaAño.SelectedIndex != -1)
            {
                string mesSeleccionado = cmbbusquedaMes.SelectedItem.ToString();
                int numeroMes = DateTime.ParseExact(mesSeleccionado, "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month;
                int añoSeleccionado = int.Parse(cmbbusquedaAño.SelectedItem.ToString());

                // Obtener el primer día del mes
                DateTime primerDiaMes = new DateTime(añoSeleccionado, numeroMes, 1);

                // Obtener el último día del mes
                DateTime ultimoDiaMes = primerDiaMes.AddMonths(1).AddDays(-1);
                
                // Pasamos directamente los objetos DateTime al método BusquedaCartera
                this.BusquedaCartera(primerDiaMes, ultimoDiaMes);
                this.MostrarEstadisticas(primerDiaMes.ToShortDateString(),ultimoDiaMes.ToShortDateString());
            }
        }



        private void BusquedaCartera(DateTime fechaInicial, DateTime fechaFinal)
        {
            try
            {
                if (this.comboBox1.Text == "Todos")
                {
                    this.BuscarEntre_fechasgeneral(fechaInicial, fechaFinal);
                }
                else if (this.comboBox1.Text != "Todos")
                {
                    this.BuscarEntre_fechas(fechaInicial, fechaFinal);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void dataCartera_Paint(object sender, PaintEventArgs e)
        {
            this.dataCartera.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }






        private void dataCartera_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                // Obtener la fila actual del DataGridView
                DataGridViewRow row = dataCartera.Rows[e.RowIndex];

                // Verificar la condición deseada (aquí se usa la columna "Estado" como ejemplo)
                string estado = row.Cells["Total Abonos"].Value.ToString();
                if (estado == "0")
                {
                    // Aplicar estilo a la fila completa
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (estado == "1")
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }



            }
            catch (Exception)
            {
                MessageBox.Show("Error de sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ObtenerMesyAño()
        {
            DateTime fechaActual = DateTime.Now;

            // Obtener el mes actual
            int mesActual = fechaActual.Month;


            switch (mesActual)
            {
                case 1:
                    cmbbusquedaMes.Text = "Enero";
                    cmbbusquedaAño.Text = fechaActual.Year.ToString();
                    break;

                case 2:
                    cmbbusquedaMes.Text = "Febrero";
                    cmbbusquedaAño.Text = fechaActual.Year.ToString();
                    break;

                case 3:
                    cmbbusquedaMes.Text = "Marzo";
                    cmbbusquedaAño.Text = fechaActual.Year.ToString();
                    break;

                case 4:
                    cmbbusquedaMes.Text = "Abril";
                    cmbbusquedaAño.Text = fechaActual.Year.ToString();
                    break;


                case 5:
                    cmbbusquedaMes.Text = "Mayo";
                    cmbbusquedaAño.Text = fechaActual.Year.ToString();
                    break;


                case 6:
                    cmbbusquedaMes.Text = "Junio";
                    cmbbusquedaAño.Text = fechaActual.Year.ToString();
                    break;

                case 7:
                    cmbbusquedaMes.Text = "Julio";
                    cmbbusquedaAño.Text = fechaActual.Year.ToString();
                    break;

                case 8:
                    cmbbusquedaMes.Text = "Agosto";
                    cmbbusquedaAño.Text = fechaActual.Year.ToString();
                    break;


                case 9:
                    cmbbusquedaMes.Text = "Septiembre";
                    cmbbusquedaAño.Text = fechaActual.Year.ToString();
                    break;

                case 10:
                    cmbbusquedaMes.Text = "Octubre";
                    cmbbusquedaAño.Text = fechaActual.Year.ToString();
                    break;

                case 11:
                    cmbbusquedaMes.Text = "Noviembre";
                    cmbbusquedaAño.Text = fechaActual.Year.ToString();
                    break;

                case 12:
                    cmbbusquedaMes.Text = "Diciembre";
                    cmbbusquedaAño.Text = fechaActual.Year.ToString();
                    break;

            }


        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                ActualizarFechaSeleccionada();
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema ", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarEstadisticas(string FechaInicio,string FechaFinal)
        {
            try
            {
                CN_CarterayCobro objetoCN = new CN_CarterayCobro();
                this.dataEstadisticasCartera.DataSource = objetoCN.MostrarCarteraEstadisticas(FechaInicio,FechaFinal);
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedTab = TabEstadisticas;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedTab = TabBusqueda;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de Sistema", "SISTEMA CECNIC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

