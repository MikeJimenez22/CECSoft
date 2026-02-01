using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;

public class CustomPrintPreviewForm : Form
{
    private PrintPreviewControl printPreviewControl = new PrintPreviewControl();
    private Button printButton = new Button();
    private Action beforePrintAction;
    private Form frmFacturacion;

    public CustomPrintPreviewForm(PrintDocument document, Action beforePrintAction, Form frmFacturacion)
    {
        this.Text = "Vista de Factura"; // Cambiar el nombre de la ventana
        this.WindowState = FormWindowState.Maximized; // Maximizar la ventana

        this.beforePrintAction = beforePrintAction;
        this.frmFacturacion = frmFacturacion;

        // Configurar tamaño de página personalizado para POS 78
        PaperSize paperSize = new PaperSize("CustomPOS78", 300,700); // 300 (3.15in) x 600 (6in) en hundredths of an inch
        document.DefaultPageSettings.PaperSize = paperSize;
        document.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);

        printPreviewControl.Document = document;
        printPreviewControl.Dock = DockStyle.Fill;
        printPreviewControl.Zoom = 1.0; // Zoom del 100%
        printPreviewControl.AutoZoom = false;
        printButton.Text = "Imprimir";
        printButton.Dock = DockStyle.Top; // Posicionar el botón en la parte superior
        printButton.Font = new Font("Arial", 14); // Cambiar la fuente a Arial de 14 puntos
        printButton.Size = new Size(150, 60); // Ajustar el tamaño del botón (puedes cambiar las dimensiones según tus necesidades)
                                              //printButton.Image = Image.FromFile(@"C:\CECSoft - Sistema CECNIC\CaoaPresentacion\Resources\285657_floppy_guardar_save_icon.png"); // Establecer la imagen del botón
        printButton.ImageAlign = ContentAlignment.MiddleLeft; // Alinear la imagen a la izquierda
        printButton.TextImageRelation = TextImageRelation.ImageBeforeText; // Mostrar la imagen antes del texto
        printButton.Click += PrintButton_Click;




        this.Controls.Add(printPreviewControl);
        this.Controls.Add(printButton);

        // Cerrar frmFacturacion cuando la vista previa se cierra
        this.FormClosed += (s, e) => frmFacturacion.Close();
    }

 
    private void PrintButton_Click(object sender, EventArgs e)
    {
        PrintDocument document = printPreviewControl.Document;
        if (document != null)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = document;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // Ejecutar acción adicional antes de imprimir
                beforePrintAction?.Invoke();

                // Imprimir documento
                document.Print();

                // Cerrar la ventana después de imprimir
                this.Close();
            }
        }
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomPrintPreviewForm));
            this.SuspendLayout();
            // 
            // CustomPrintPreviewForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomPrintPreviewForm";
            this.Load += new System.EventHandler(this.CustomPrintPreviewForm_Load);
            this.ResumeLayout(false);

    }

    private void CustomPrintPreviewForm_Load(object sender, EventArgs e)
    {

    }
}
