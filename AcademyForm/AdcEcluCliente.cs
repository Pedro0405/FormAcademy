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
    public partial class AdcEcluUsu : Form
    {
        public AdcEcluUsu()
        {
            InitializeComponent();
            try
            {
                DataTable dt = new DataTable();
                dt = DalHelper.GetUsuarios();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void AdcEcluCliente_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txt_nome.Text;
                string email = txt_email.Text;
                string cpf = maskedTextBox1.Text;
                int acesso = int.Parse(comboBox1.Text);
                string telefone = maskedTextBox2.Text;
                string username = txt_username.Text;
                string senha = txt_senha.Text;

                if (txt_senha.Text == textBox7.Text)
                {
                    try
                    {
                        DalHelper.Add(nome, email, telefone, acesso, cpf, username, senha,0);
                        txt_nome.Clear();
                        txt_email.Clear();
                        maskedTextBox1.Clear();
                        comboBox1.Text = null;
                        maskedTextBox2.Clear();
                        txt_username.Clear();
                        txt_senha.Clear();
                        txt_nome.Focus();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                }
            }
            catch
            {
                MessageBox.Show("preencha todos os campos");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DalHelper.GetUsuarios();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void txt_nome_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Deseja realmente excluir esse usuario?","Atenção",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    DalHelper.Delete(int.Parse(textBox8.Text));
                    MessageBox.Show("EXCLUIDO COM SUCESSO");
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox8.Text;
            if (id != "")
            {
                AlterarCad novo = new AlterarCad(id);
                novo.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_senha_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
