using csharp_Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademyForm
{
    public partial class VizualizarClientes : Form
    {
        public VizualizarClientes()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt = DalHelper.ObterClientes();
            dataGridView1.DataSource= dt;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome = textBox1.Text;
            DataTable dt = new DataTable();
            dt = DalHelper.SelectClientePorNome(nome);
            dataGridView1.DataSource = dt;
        }
    }
}
