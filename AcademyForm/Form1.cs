using csharp_Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AcademyForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
           
            janelalogin login = new janelalogin(this);
            login.ShowDialog();
            if (globais.logado)
            {
                pictureBox1.Image = Properties.Resources.cad_aberto;
                label2.Text = globais.nome;
                lb_acesso.Text = globais.acesso.ToString();
            }
            else
            {
                pictureBox1.Image = Properties.Resources.cad_fechado;
                label2.Text = "...";
                lb_acesso.Text = "..";
            }
            

            if (lb_acesso.Text == "0")
            {
                label4.Text = "Desenvolvedor";
            }
            if(lb_acesso.Text == "1")
            {
                label4.Text = "Supervisor";
            }
            if (lb_acesso.Text == "2")
            {
                label4.Text = "Funcionario";
            }
            if (lb_acesso.Text == "3")
            {
                label4.Text = "Cliente";
            }
            if(lb_acesso.Text == "..")
            {
                label4.Text = "deslogado";
            }

            
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (globais.logado)
            {
                if (globais.acesso <= 2)
                {
                    EstoqueForm novo = new EstoqueForm();
                    novo.Show();
                }
                else
                {
                    MessageBox.Show("Area somente para funcionarios", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Precisa que tenha um usuario logado", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (globais.logado)
            {
                if (globais.acesso < 3) 
                { 
                GerenciarClientes novo = new GerenciarClientes();
                novo.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Area somente para funcionarios", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Precisa que tenha um usuario logado", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            globais.logado = false;
            globais.id = 0;
            globais.nome = "...";
            globais.email = "";
            globais.telefone = "";
            globais.acesso = 100;
            globais.cpf = "";
            globais.usuario = "";
            globais.password = "";
            label2.Text = "...";
            label4.Text = "-";
            lb_acesso.Text = "..";
            pictureBox1.Image = Properties.Resources.cad_fechado;
            MessageBox.Show("Deslogado com sucesso");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (globais.logado)
            {
                if (globais.acesso <= 2)
                {
                  TurmaProfForm novo = new TurmaProfForm();
                  novo.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Area somente para funcionarios", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Precisa que tenha um usuario logado", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (globais.logado)
            {
                if (globais.acesso <= 2)
                {
                 abaClientes novo = new abaClientes();
                    novo.Show();
                }
                else
                {
                    MessageBox.Show("Area somente para funcionarios", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Precisa que tenha um usuario logado", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (globais.logado)
            {
                if (globais.acesso <= 1)
                {
                    GestaoForm novo = new GestaoForm();
                    novo.Show();
                }
                else
                {
                    MessageBox.Show("Area somente para supervisores", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Precisa que tenha um usuario logado", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void entrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!globais.logado)
            {
                janelalogin novo = new janelalogin(this);
                novo.ShowDialog();
                if (globais.logado)
                {
                    pictureBox1.Image = Properties.Resources.cad_aberto;
                    label2.Text = globais.nome;
                    lb_acesso.Text = globais.acesso.ToString();
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.cad_fechado;
                    label2.Text = "...";
                    lb_acesso.Text = "..";
                }


                if (lb_acesso.Text == "0")
                {
                    label4.Text = "Desenvolvedor";
                }
                if (lb_acesso.Text == "1")
                {
                    label4.Text = "Supervisor";
                }
                if (lb_acesso.Text == "2")
                {
                    label4.Text = "Funcionario";
                }
                if (lb_acesso.Text == "3")
                {
                    label4.Text = "Cliente";
                }
                if (lb_acesso.Text == "..")
                {
                    label4.Text = "deslogado";
                }

            }
            else
            {
                MessageBox.Show("Usuario ja logado", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

