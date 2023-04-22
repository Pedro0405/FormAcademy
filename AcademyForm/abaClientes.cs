using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademyForm
{
    public partial class abaClientes : Form
    {
        public abaClientes()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cadExcluirCliente novo = new cadExcluirCliente();
            novo.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VizualizarClientes novo = new VizualizarClientes();
            novo.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Efetuarpag novo = new Efetuarpag();
            novo.Show();
            this.Close();
        }
    }
}
