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
    public partial class AlterarPlanosForm : Form
    {
        public AlterarPlanosForm()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DalHelper.ObterPlanos();
                dataGridView1.DataSource = dt;

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txt_descricao.Text != "") & (txt_valor.Text != ""))
                {
                    string descricao = txt_descricao.Text;
                    int valpr = int.Parse(txt_valor.Text);

                    DalHelper.AddPlanos(descricao, valpr);
                    MessageBox.Show("Plano inserido com sucesso", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_descricao.Clear();
                    txt_valor.Clear();
                    txt_descricao.Focus();
                }
                else
                {
                    MessageBox.Show("Verifique se todos os campos foram preenchidos", "atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text != "")
                {
                    int id = int.Parse(textBox3.Text);
                   
                    DalHelper.DeletePlanos(id);
                    
                    MessageBox.Show("Plano deletado com sucesso", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox3.Clear();
                    textBox3.Focus();
                }
                else
                {
                    MessageBox.Show("Verifique se o campo id foi preenchido", "atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }
    }
}
