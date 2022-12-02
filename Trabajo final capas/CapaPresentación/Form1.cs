using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresentación
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Método para llenar el datagrid
        private void listar()
        {
            try
            {
                dgvDatos.DataSource = Negocio_Alumno.Listar();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.listar();

        }
    }
}
