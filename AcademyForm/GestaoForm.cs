using csharp_Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademyForm
{
    public partial class GestaoForm : Form
    {
        public GestaoForm()
        {
            InitializeComponent();
        }
            


        private void button2_Click(object sender, EventArgs e)
        {
            AlterarHorarios novo = new AlterarHorarios();
            novo.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        public void button7_Click(object sender, EventArgs e)
        {
            label5.Text = globais.QuantidadeCliente.ToString();
            

            DataTable dt = new DataTable();
            dt = DalHelper.RetornaSomaPaga();
            if (dt.Rows.Count > 0)
            {
                int pAGOPLANO = int.Parse(dt.Rows[0].ItemArray[0].ToString());
                lb_plano.Text = pAGOPLANO.ToString();
            }


            DataTable DA = new DataTable();
            DA = DalHelper.RetornaSomaPagaAcrescimo();
            if (DA.Rows.Count > 0)
            {
                int ACRESCIMOPAGO = int.Parse(DA.Rows[0].ItemArray[0].ToString());
                lb_acrescimo.Text = ACRESCIMOPAGO.ToString();
            }

            DataTable ds = new DataTable();
            ds = DalHelper.RetornaSomaPagaSalario();
            if (ds.Rows.Count > 0) {
                int salario = int.Parse(ds.Rows[0].ItemArray[0].ToString());
                lb_professores.Text = salario.ToString();
            }

            DataTable du = new DataTable();
            du = DalHelper.RetornaSomaPagaSalarioUsers();
            if (du.Rows.Count > 0) 
            {
                int salarioUser = int.Parse(du.Rows[0].ItemArray[0].ToString());
                lb_usuarios.Text = salarioUser.ToString();
            }

            DataTable dd = new DataTable();
            dd = DalHelper.RetornaSomaPagaOutrasDespesas();
            if (dd.Rows.Count > 0)
            {
                int outrasDespesas = int.Parse(dd.Rows[0].ItemArray[0].ToString());
                lb_custos.Text = outrasDespesas.ToString();
            }

            DataTable dl = new DataTable();
            dl = DalHelper.RetornaSomaPagaOurtosLucros();
            if(dl.Rows.Count > 0)
            {
                int Outroslucros = int.Parse(dl.Rows[0].ItemArray[0].ToString());
                lb_OutrosLucros.Text = Outroslucros.ToString();
            }




        


                

              
                
                int SalarioTotal = int.Parse(lb_professores.Text) + int.Parse(lb_usuarios.Text);
                lb_salario.Text = SalarioTotal.ToString();
               
                int renda = int.Parse(lb_acrescimo.Text) + int.Parse(lb_plano.Text) + int.Parse(lb_OutrosLucros.Text);
                label6.Text = renda.ToString();
                int DespesaTotal = int.Parse(lb_professores.Text) + int.Parse(lb_usuarios.Text) + int.Parse(lb_custos.Text);
                int lucro = renda - DespesaTotal;
                label7.Text = lucro.ToString();
                if (lucro < 0)
                {
                    label7.ForeColor = Color.Red;
                }
                DataTable dados = new DataTable();
                dados = DalHelper.ObterDespesas();
                dataGridView1.DataSource = dados;
            

        }

        private void GestaoForm_Load(object sender, EventArgs e)
        {
         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AlterarPlanosForm novo = new AlterarPlanosForm();
            novo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                GestaoSalario novo = new GestaoSalario();
                novo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OutrosLucrosGastos novo =new OutrosLucrosGastos();
            novo.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
