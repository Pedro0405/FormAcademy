using csharp_Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AcademyForm
{
    public partial class AlterarCad : Form
    {
        public AlterarCad(string id)
        {
            InitializeComponent();
          DataTable dt = new DataTable();
         label2.Text = id;
            try
            {
             dt = DalHelper.SelectForID(id);
                
                textBox1.Text = dt.Rows[0].ItemArray[1].ToString();
                textBox2.Text = dt.Rows[0].ItemArray[2].ToString();
                maskedTextBox1.Text = dt.Rows[0].ItemArray[3].ToString();
                maskedTextBox2.Text = dt.Rows[0].ItemArray[5].ToString();
                comboBox1.Text = dt.Rows[0].ItemArray[4].ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(label2.Text);
                string nome = textBox1.Text;
                string email = textBox2.Text;
                string cpf = maskedTextBox2.Text;
                int acesso = int.Parse(comboBox1.Text);
                string telefone = maskedTextBox1.Text;
                DalHelper.Update(id, nome, email, telefone, acesso, cpf);
                MessageBox.Show("Alteração concluida com sucesso", "SUCESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(globais.acesso > 1)
            {
                MessageBox.Show("Acesso não permitido para alterar esse valor"); 
            }
        }
    }
}
