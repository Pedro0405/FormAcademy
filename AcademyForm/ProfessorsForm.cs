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
    public partial class ProfessorsForm : Form
    {
        public ProfessorsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DalHelper.ObterProffesores();
                dataGridView1.DataSource = dt;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
        }

        private void ProfessorsForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txt_nome.Text != "")&(txt_email.Text != "")&(maskedTextBox1.Text != ""))
                {
                    string nome = txt_nome.Text;
                    string email = txt_email.Text;
                    string telefone = maskedTextBox1.Text;
                    int salario = int.Parse(textBox1.Text);
                    DalHelper.AddProfessores(nome, email, telefone, salario);
                    MessageBox.Show("Professor adcionado com sucesso", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_nome.Clear();
                    txt_email.Clear();
                    maskedTextBox1.Clear();
                    txt_nome.Focus();
                }
                else
                {
                    MessageBox.Show("Preencha tdos os campos para poder adcionar um professor", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(txt_id.Text != "")
                {
                    int id = int.Parse(txt_id.Text);
                    if (id != 1)
                    {
                        DalHelper.DeleteProfessores(id);
                        MessageBox.Show("Professor excluido com sucesso", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }else
                    {
                        MessageBox.Show("Professor inexistente");
                    }
                    txt_id.Clear();

                }
                else
                {
                    MessageBox.Show("Preencha tdos os campos para poder excluir um professor", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }
    }
}
