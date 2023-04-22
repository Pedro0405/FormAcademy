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
    public partial class AlterarCadClitente : Form
    {
        public AlterarCadClitente(string id)
        {
            InitializeComponent();
            DataTable da = new DataTable();
            da = DalHelper.PopularComboBoxPlanos();

            comboBox1.DataSource = da;
            comboBox1.DisplayMember = "descricao";
            comboBox1.ValueMember = "valor";
            label2.Text = id;
            DataTable dt = new DataTable();
            dt = DalHelper.SelectClienteForID(int.Parse(id));

            textBox1.Text = dt.Rows[0].ItemArray[1].ToString();
            textBox2.Text = dt.Rows[0].ItemArray[2].ToString();
            maskedTextBox1.Text = dt.Rows[0].ItemArray[3].ToString();
            maskedTextBox2.Text = dt.Rows[0].ItemArray[4].ToString();
            
            comboBox1.Text = dt.Rows[0].ItemArray[5].ToString();
            comboBox2.Text = dt.Rows[0].ItemArray[7].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DalHelper.UpdateClientes(int.Parse(label2.Text), textBox1.Text, textBox2.Text, maskedTextBox1.Text, comboBox1.Text, maskedTextBox2.Text, comboBox2.Text);
                MessageBox.Show("Cadastro de cliente atualizado com sucesaso", "sucess", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
