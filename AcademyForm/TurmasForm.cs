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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AcademyForm
{
    public partial class TurmasForm : Form
    {
        public TurmasForm()
        {
            InitializeComponent();
            
            comboBox3.DataSource = DalHelper.PopularComboBoxbrofessor();
            comboBox3.DisplayMember = "Nome";
            comboBox3.ValueMember= "id";
            comboBox1.DataSource = DalHelper.PopularComboBoxbroHorario();
            comboBox1.DisplayMember= "horario";
            comboBox1.ValueMember= "id";

            comboBox4.DataSource = DalHelper.PopularComboBoxIdTurmas();
            comboBox4.DisplayMember = "id";
            comboBox4.ValueMember = "id";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DalHelper.ObterTurma();
                dataGridView1.DataSource= dt;

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                                if((comboBox1.Text != "")&(comboBox2.Text != "")&(comboBox3.Text != "")&(textBox1.Text != "")&(textBox2.Text != "")&(txt_valor.Text != ""))
                                {
                    string descricao = textBox1.Text;
                    int idHorario = int.Parse(comboBox1.SelectedValue.ToString());
                    string status = comboBox2.Text;
                    int idProfessor = int.Parse(comboBox3.SelectedValue.ToString());
                    int MaximoAlunos = int.Parse(textBox2.Text);
                    int valor = int.Parse(txt_valor.Text);
                    DalHelper.AddTurmas(descricao, idProfessor, idHorario, MaximoAlunos, status, valor, 0);
                                    MessageBox.Show("Adcionado com sucesso", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "";
                    textBox1.Clear();
                    textBox2.Clear();
                                 
                                }
                                else
                                {
                                    MessageBox.Show("Preencha todos os campos", "aTENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                  return;
                                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(comboBox4.Text != "")
                {
                    if (comboBox4.Text == "0")
                    {
                        MessageBox.Show("Voce não pode excluir a turma 0");
                    }
                    else
                    {
                        int id = int.Parse(comboBox4.Text);
                        DalHelper.DeleteTurmas(id);
                        MessageBox.Show("DELETADO COM SUCESSO", "SUCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBox4.Text = "";
                    }

                }
                else
                {
                    MessageBox.Show("Selecione um id", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
              
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {if (comboBox4.Text != "")
            {
                if (comboBox4.Text != "0")
                {


                    int id = int.Parse(comboBox4.Text);
                    AlterarTurmaForm novo = new AlterarTurmaForm(id);
                    novo.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Membro não pode ser alterado");
                }
            }
            
        }
    }
}
