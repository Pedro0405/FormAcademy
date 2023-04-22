using csharp_Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademyForm
{
    public partial class Efetuarpag : Form
    {
        public Efetuarpag()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                if(maskedTextBox1.Text != "")
                {
                  
                    
                        DataTable dt = new DataTable();
                        dt = DalHelper.SelectClientePorCPF(maskedTextBox1.Text);
                        dataGridView1.DataSource = dt;
                    
                    
                    
                        
                       
                    

                }

            }catch(Exception ex)
            {
                MessageBox.Show("Usuario não encontrado");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                
                    
                    int meshoje = DateTime.Now.Month;

                    int id = int.Parse(textBox2.Text);
                    if (textBox2.Text == string.Empty)
                    {
                        MessageBox.Show("Selecio9ne um id na caixa de texto ao lado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    else
                    {
                        DalHelper.Efetuarpag(id, 1);
                        MessageBox.Show("PPagamento efetuado om sucesso", "sucess", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        DalHelper.ObterDataPAg(id, meshoje);
                 
                }


                
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                

            }
        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
