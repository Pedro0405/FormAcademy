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
    public partial class janelalogin : Form
    {
         Form form;
        public janelalogin(Form f)
        {
            form = f;
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
               
                MessageBox.Show("Usuario ou senha precisam ser informados", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                
                DataTable dataTable= new DataTable();
                dataTable = DalHelper.obterusuario(textBox1.Text,textBox2.Text);
                if(dataTable.Rows.Count == 1)
                {
                    globais.logado = true;
                    globais.id = Int32.Parse(dataTable.Rows[0].ItemArray[0].ToString());
                    globais.nome = dataTable.Rows[0].ItemArray[1].ToString();
                    globais.email = dataTable.Rows[0].ItemArray[2].ToString();
                    globais.telefone = dataTable.Rows[0].ItemArray[3].ToString();
                    globais.acesso = int.Parse(dataTable.Rows[0].ItemArray[4].ToString());
                    globais.cpf = dataTable.Rows[0].ItemArray[5].ToString();
                    globais.usuario = textBox1.Text;
                    globais.password = textBox2.Text;
                    MessageBox.Show("Logado coo sucesso", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario Invalido", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
              
                
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

       
    }
}
