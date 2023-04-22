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
    public partial class AlterarTurmaForm : Form
    {
        public AlterarTurmaForm(int id)
        {
            InitializeComponent();

            comboBox1.DataSource = DalHelper.PopularComboBoxbrofessor();
            comboBox1.DisplayMember = "Nome";
            comboBox1.ValueMember = "id";
            comboBox2.DataSource = DalHelper.PopularComboBoxbroHorario();
            comboBox2.DisplayMember = "horario";
            comboBox2.ValueMember = "id";

            label_id.Text = id.ToString();

           
            DataTable dt = new DataTable();
            dt = DalHelper.SelectTurmasForID(id);

            textBox1.Text = dt.Rows[0].ItemArray[1].ToString();
            textBox2.Text = dt.Rows[0].ItemArray[4].ToString();
            comboBox1.Text = dt.Rows[0].ItemArray[2].ToString();
            comboBox2.Text = dt.Rows[0].ItemArray[3].ToString();
            comboBox3.Text = dt.Rows[0].ItemArray[5].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(label_id.Text);
                string descricao = textBox1.Text;
                int idHorario = int.Parse(comboBox2.SelectedValue.ToString());
                string status = comboBox3.Text;
                int idProfessor = int.Parse(comboBox1.SelectedValue.ToString());
                int MaximoAlunos = int.Parse(textBox2.Text);
                if ((comboBox1.Text != "") & (comboBox2.Text != "") & (comboBox3.Text != "") & (textBox1.Text != "") & (textBox2.Text != ""))
                {
                    DalHelper.UpdateTurmas(id,descricao,idProfessor,idHorario,MaximoAlunos,status);
                    MessageBox.Show("Adcionado com sucesso", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos", "aTENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
            catch(Exception ex)
            { 
                MessageBox.Show(ex.Message);
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
