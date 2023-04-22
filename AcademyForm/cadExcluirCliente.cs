using csharp_Sqlite;
using System;
using System.CodeDom;
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
    public partial class cadExcluirCliente : Form
    {
        public cadExcluirCliente()
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            dt = DalHelper.PopularComboBoxPlanos();
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "descricao";
            comboBox2.ValueMember= "valor";
            


        }
        

       

        private void button2_Click(object sender, EventArgs e)
        {
            string nome = txt_nome.Text;
            string email = txt_email.Text;
            string cpf = maskedTextBox1.Text;
            string telefone = maskedTextBox2.Text;
            string plano = comboBox2.SelectedValue.ToString();
            string datavalidade = comboBox1.Text;
            int pago = 0;
            try
            {
                if (plano != "")
                    if   (nome != "") 
                        if(cpf != "") 
                            if(telefone != "")
                                if (email != "")
                {
                    DalHelper.AddClientes(nome, email, telefone, cpf, plano, pago, datavalidade,0,0,0);
                    MessageBox.Show("Adcionado com sucesso", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_nome.Clear();
                    txt_email.Clear();
                    maskedTextBox1.Clear();
                    maskedTextBox2.Clear();
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos", "aTENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
              

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime hoje = DateTime.Now.Date;
                int mesAtual = hoje.Month;

                DataTable dt = new DataTable();
                dt = DalHelper.ObterClientes();
                dataGridView1.DataSource = dt;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    // Verifica se a célula "mespagamento" tem um valor antes de tentar convertê-la
                    if (row.Cells["mespagamento"].Value != null)
                    {
                        int mesPagamento = Convert.ToInt32(row.Cells["mespagamento"].Value.ToString());
                        int id = Convert.ToInt32(row.Cells["id"].Value);
                        int diavencimento = Convert.ToInt32(row.Cells["datavalidade"].Value);
                        int foipago = Convert.ToInt32(row.Cells["pago"].Value);
                        if ((mesPagamento != mesAtual)&&(globais.diahoje > diavencimento))
                        {
                            row.Cells["pago"].Value = "0";
                            DalHelper.Efetuarpag(id, 0);
                        }
                        else
                        {
                            row.Cells["pago"].Value = "1";
                            DalHelper.Efetuarpag(id, 1);
                        }

                        if (row.Cells["pago"].Value != null)
                        {
                            if (row.Cells["pago"].Value.ToString() == "1")
                            {
                                row.Cells["pago"].Style.BackColor = Color.Green;
                                row.Cells["pago"].Style.ForeColor = Color.White;
                            }
                            else
                            {
                                row.Cells["pago"].Style.BackColor = Color.Red;
                                row.Cells["pago"].Style.ForeColor = Color.White;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox8.Text);
                if (id != 0)
                {
                    DalHelper.DeleteCliente(id);
                    MessageBox.Show("Deletado com sucesso", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("cliente base, não pode ser excluido");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "")
            { 
                if (textBox8.Text == "0")
                {
                    MessageBox.Show("error");
                }
                else
                {


                    AlterarCadClitente novo = new AlterarCadClitente(textBox8.Text);
                    novo.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("dIGITE O ID DO CLIENTE", "aTENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cadExcluirCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
