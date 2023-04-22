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
    public partial class OutrosLucrosGastos : Form
    {
        public OutrosLucrosGastos()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = DalHelper.ObterLucros();
            dataGridView1.DataSource = dt;
            lb_tb.Text = "Lucros";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = DalHelper.ObterDespesas();
            dataGridView1.DataSource = dt;
            lb_tb.Text = "Despesas";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows[0].Cells["id"].Value != null)
                {
                    if (lb_tb.Text == "Despesas")
                    {
                        
                        int idSelecionado = int.Parse(dataGridView1.SelectedRows[0].Cells["id"].Value.ToString());
                        if (idSelecionado != 0)
                        {
                            DalHelper.DeleteDespesas(idSelecionado);
                            MessageBox.Show("deletado COm sucesso", "suces", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            DataTable dt = new DataTable();
                            dt = DalHelper.ObterDespesas();
                            dataGridView1.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("despesa basica, Não pode ser delertada");
                        }
                    }
                    else if (lb_tb.Text == "Lucros")
                    {
                        int idSelecionado = int.Parse(dataGridView1.SelectedRows[0].Cells["id"].Value.ToString());
                        if (idSelecionado != 0)
                        {
                            DalHelper.DeleteLucros(idSelecionado);
                            MessageBox.Show("deletado com sucesso", "suces", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            DataTable dt = new DataTable();
                            dt = DalHelper.ObterLucros();
                            dataGridView1.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Lucro basica, Não pode ser delertada");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Exiba uma tabela primeiro");
                    }
                   
                }
                else
                {
                    MessageBox.Show("Voc{e precisa selecionar um elemento para efetuar uma exclusão", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Voc{e precisa selecionar um elemento para efetuar uma exclusão");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((groupBox1.Controls.OfType<RadioButton>().Any(x => x.Checked))&(textBox_desc.Text != "")&(textBox_valor.Text != ""))
            {
                string txt;
                txt = groupBox1.Controls.OfType<RadioButton>().
                    SingleOrDefault(RadioButton => RadioButton.Checked).Text;

                if (txt == "Lucro")
                {
                    string tipo = "Lucros";
                    string des = textBox_desc.Text;
                    int valor = int.Parse(textBox_valor.Text);

                    DalHelper.AddLucros(des,valor);
                    MessageBox.Show("Lucro Adcionado com Sucesso", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_desc.Clear();
                    textBox_valor.Clear();
                    radioButton2.Checked = false;

                }
                if(txt == "Despesas")
                {
                    string tipo = "Despesas";
                    string des = textBox_desc.Text;
                    int valor = int.Parse(textBox_valor.Text);

                    DalHelper.AddDespesas(des, valor);
                    MessageBox.Show("Despesa Adcionado com Sucesso", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_desc.Clear();
                    textBox_valor.Clear();
                    radioButton1.Checked = false;
                }
            }
        
            else
            {
                // Nenhum RadioButton dentro do GroupBox foi selecionado.
                MessageBox.Show("Você PReciso adcionar o tipo de Renda e PRencher os campos de descrição e valor", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text != "")
                {
                    string desc = textBox1.Text;
                    DataTable dt = new DataTable();

                    if(lb_tb.Text == "Lucros")
                    {
                        dt = DalHelper.SelectTudoLucrossFordes(desc);
                        dataGridView1.DataSource = dt;

                    }
                    else if(lb_tb.Text == "Despesas")
                    {
                        dt = DalHelper.SelectTudoDespesasFordes(desc);
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Exiba um tipo de tabela para efetuar a busca");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }
    }
}
