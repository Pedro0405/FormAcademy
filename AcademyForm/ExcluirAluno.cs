using csharp_Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademyForm
{
    public partial class ExcluirAluno : Form
    {
        public ExcluirAluno(string cpf)
        {
            InitializeComponent();
            try
            {
                lb_cpf.Text = cpf;

                DataTable dt = new DataTable();
                dt = DalHelper.SelectClientePorCPF(cpf);
                if (dt.Rows.Count > 0)
                {
                    string nome = dt.Rows[0].ItemArray[1].ToString();
                    int id = int.Parse(dt.Rows[0].ItemArray[0].ToString());
                    lb_nome.Text = nome;
                    lb_idCliente.Text = id.ToString();

                    int idTurma1 = int.Parse(dt.Rows[0].ItemArray[9].ToString());
                    int idTurma2 = int.Parse(dt.Rows[0].ItemArray[11].ToString());
                    lb_id1.Text = idTurma1.ToString();
                    lb_id2.Text = idTurma2.ToString();





                    DataTable da1 = new DataTable();
                    da1 = DalHelper.SelectTudoTurmasForID(idTurma1);
                    string descricao1 = da1.Rows[0].ItemArray[1].ToString();
                    lb_desc1.Text = descricao1;

                    DataTable da2 = new DataTable();
                    da2 = DalHelper.SelectTudoTurmasForID(idTurma2);
                    string descricao2 = da2.Rows[0].ItemArray[1].ToString();
                    lb_desc2.Text = descricao2;
                }
                else
                {
                    MessageBox.Show("0 linhas");
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    int idTurmaPretendida = int.Parse(textBox1.Text);
                    int idCliente = int.Parse(lb_idCliente.Text);
                    // SE FOR A TURMA 1
                    if (idTurmaPretendida == int.Parse(lb_id1.Text))
                    {
                       
                        DataTable dc = new DataTable();
                        dc = DalHelper.SelectClienteForID(idCliente);
                        int acrescimo = int.Parse(dc.Rows[0].ItemArray[10].ToString());

                        DataTable dt = new DataTable();
                        dt = DalHelper.SelectTudoTurmasForID(idTurmaPretendida);
                        int quantidadeAlunos1 = int.Parse(dt.Rows[0].ItemArray[7].ToString());
                        int valor1 = int.Parse(dt.Rows[0].ItemArray[6].ToString());
                        quantidadeAlunos1 = quantidadeAlunos1 - 1;
                        acrescimo = acrescimo - valor1;
                        DalHelper.InserirAlunoEmTurma(idCliente, 0);
                        DalHelper.UpdateQuantidadeAlunos(idTurmaPretendida, quantidadeAlunos1);
                        DalHelper.UpdateAcrescimo(idCliente, acrescimo);
                        MessageBox.Show("Aluno excluido de turma com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                    else if(idTurmaPretendida == int.Parse(lb_id2.Text)) //SE O ESCOLIDO FOR A SEGUNDA TURMA
                    {
                     
                        DataTable dc = new DataTable();
                        dc = DalHelper.SelectClienteForID(idCliente);
                        int acrescimo = int.Parse(dc.Rows[0].ItemArray[10].ToString());

                        DataTable dt = new DataTable();
                        dt = DalHelper.SelectTudoTurmasForID(idTurmaPretendida);
                        int quantidadeAlunos1 = int.Parse(dt.Rows[0].ItemArray[7].ToString());
                        int valor1 = int.Parse(dt.Rows[0].ItemArray[6].ToString());

                        quantidadeAlunos1 = quantidadeAlunos1 - 1;
                        acrescimo = acrescimo - valor1;

                        DalHelper.InserirAlunoEmTurma2(idCliente, 0);
                        DalHelper.UpdateQuantidadeAlunos(idTurmaPretendida, quantidadeAlunos1);
                        DalHelper.UpdateAcrescimo(idCliente, acrescimo);
                        MessageBox.Show("Aluno excluido de turma com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ID invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     
                    }


                }
                else
                {
                    MessageBox.Show("Selecione um id", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
          
            
            
        }

        private void ExcluirAluno_Load(object sender, EventArgs e)
        {

        }
    }
}
