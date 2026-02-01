using System;
using System.Drawing;
using System.Windows.Forms;

namespace Utils
{
    public static class DataGridViewConfigurator
    {
        public static void Configure(params DataGridView[] dataGrids)
        {
            foreach (var dgv in dataGrids)
            {
                // Encabezados de columna
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Regular);
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(63, 81, 181);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.EnableHeadersVisualStyles = false;

                // Filas
                dgv.DefaultCellStyle.Font = new Font("Arial", 8);
                dgv.DefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);
                dgv.DefaultCellStyle.BackColor = Color.White;
                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(144, 202, 249);
                dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

                // Alternancia de colores en las filas
                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

                // Propiedades adicionales
                dgv.BorderStyle = BorderStyle.None;
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgv.AllowUserToAddRows = false;
                dgv.RowHeadersVisible = false;
                dgv.GridColor = Color.FromArgb(224, 224, 224);

                // Fijar el alto de las filas
                dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None; // Evita el ajuste automático del alto
                dgv.RowTemplate.Height = 25; // Establece una altura fija para las filas (cambia 25 al valor que desees)
                dgv.AllowUserToResizeRows = false; // Desactiva la opción de que el usuario cambie el alto de las filas


            }
        }
    }
}
