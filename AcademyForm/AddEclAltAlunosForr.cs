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
    public partial class AddEclAltAlunosForr : Form
    {
        public AddEclAltAlunosForr()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt = DalHelper.PopularComboBoxIdDescricaoTurmas();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "descricao";
            comboBox1.ValueMember = "id";

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = DalHelper.ObterTurmasComAlunos();
            dataGridView1.DataSource = dt;
        }

        private void comboBoxTurma_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(lb_id.Text != "-")
                {
                    int idCliente = int.Parse(lb_id.Text);
                    int Idturmapretendia = int.Parse(comboBox1.SelectedValue.ToString());



                    DataTable dt = new DataTable();
                    dt = DalHelper.SelectTudoTurmasForID(Idturmapretendia);
                    
                    int valoraAcrecer = int.Parse(dt.Rows[0].ItemArray[6].ToString());
                    int quantidadeAlunosTurma = int.Parse(dt.Rows[0].ItemArray[7].ToString());

                   
                    DataTable da = new DataTable();
                    da = DalHelper.SelectClienteForID(idCliente);
                    int acrescimodocliente = int.Parse(da.Rows[0].ItemArray[10].ToString());
                    int IDturma1matriculada = int.Parse(da.Rows[0].ItemArray[9].ToString());
                    label4.Text = IDturma1matriculada.ToString();
                    if (IDturma1matriculada == 0)   
                    {
                         quantidadeAlunosTurma = quantidadeAlunosTurma + 1;
                        valoraAcrecer = valoraAcrecer + acrescimodocliente;
                        DalHelper.InserirAlunoEmTurma(idCliente, Idturmapretendia);
                        DalHelper.UpdateAcrescimo(idCliente,valoraAcrecer);
                        DalHelper.UpdateQuantidadeAlunos(Idturmapretendia, quantidadeAlunosTurma);
                       
                        MessageBox.Show("Inserido em turma com sucesso", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DialogResult = MessageBox.Show("Aluno ja está em uma turma, deseja cadastrar em outra?", "atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if(DialogResult == DialogResult.Yes)
                        {
                            valoraAcrecer = valoraAcrecer + acrescimodocliente;
                            DalHelper.InserirAlunoEmTurma2(idCliente, Idturmapretendia);
                            DalHelper.UpdateAcrescimo(idCliente, valoraAcrecer);
                            DalHelper.UpdateQuantidadeAlunos(Idturmapretendia, quantidadeAlunosTurma);

                            MessageBox.Show("Inserido em turma com sucesso", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Tudo bem, até a proxima", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                    }
                }
                else
                {
                    MessageBox.Show("Pesquise por um cliente primeiro","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
             
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string cpf = maskedTextBoxcpf.Text;
            DataTable dt = new DataTable();
            dt = DalHelper.SelectClientePorCPF(cpf);
            if (dt.Rows.Count == 1)
            {
                lb_nome.Text = dt.Rows[0].ItemArray[1].ToString();
                lb_email.Text = dt.Rows[0].ItemArray[2].ToString();
                lb_plano.Text = dt.Rows[0].ItemArray[5].ToString();
                lb_telefone.Text = dt.Rows[0].ItemArray[3].ToString();
                lb_id.Text = dt.Rows[0].ItemArray[0].ToString();
            }

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void AddEclAltAlunosForr_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(maskedTextBox1.Text != "")
            {
                string cpf = maskedTextBox1.Text;

                ExcluirAluno novo = new ExcluirAluno(cpf);
                novo.ShowDialog();
            }
        }
    }
}
