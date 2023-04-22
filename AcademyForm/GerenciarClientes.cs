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
    public partial class GerenciarClientes : Form
    {
        public GerenciarClientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (globais.acesso < 2)
            {
                this.Close();
                AdcEcluUsu novo = new AdcEcluUsu();
                novo.Show();
                
            }
            else
            {
                MessageBox.Show("Tela disponivel apenas para supervisores","erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VizualizarUsuarios NOVO = new VizualizarUsuarios();
            NOVO.Show();
            Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
