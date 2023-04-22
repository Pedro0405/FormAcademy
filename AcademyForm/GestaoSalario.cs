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
    public partial class GestaoSalario : Form
    {
        public GestaoSalario()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt = DalHelper.ObterNomeEsalrioUsuarios();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text != "")
                {
                    string id = textBox1.Text;
                    DataTable dt = new DataTable();
                    dt = DalHelper.SelectForID(id);

                    lb_nome.Text = dt.Rows[0].ItemArray[1].ToString();
                    lb_email.Text = dt.Rows[0].ItemArray[2].ToString();
                    lb_id.Text = dt.Rows[0].ItemArray[0].ToString();
                    lb_cpf.Text = dt.Rows[0].ItemArray[5].ToString();
                    textBox1.Clear();
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox2.Text != "")
                {
                    if (lb_id.Text != "-")
                    {
                        int id = int.Parse(lb_id.Text);
                        int salario = int.Parse(textBox2.Text);
                        DalHelper.UpdateSalarioUser(id, salario);
                        MessageBox.Show("Salario inserido com sucesso", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Digite um valor para alterar salario", "opss", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }catch(Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void GestaoSalario_Load(object sender, EventArgs e)
        {

        }
    }
}
