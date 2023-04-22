using csharp_Sqlite;
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
    public partial class VizualizarUsuarios : Form
    {
        public VizualizarUsuarios()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt = DalHelper.GetUsuarios();
            dataGridView1.DataSource= dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    DataTable dt = new DataTable();
                    dt = DalHelper.SelectForID(textBox2.Text);
                    dataGridView1.DataSource = dt;
                }
                if(textBox2.Text == "")
                {
                    DataTable dt = new DataTable();
                    dt = DalHelper.SelectFornNome(textBox1.Text);
                    dataGridView1.DataSource = dt;
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
