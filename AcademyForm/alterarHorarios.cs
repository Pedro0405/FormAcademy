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
    public partial class AlterarHorarios : Form
    {
        public AlterarHorarios()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DalHelper.ObterHorarios();
                dataGridView1.DataSource = dt;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    DalHelper.AddHorario(textBox1.Text);
                    MessageBox.Show("Item Adcionadocom sucesso, atualize a tabela", "sucess", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }catch (Exception ex ) {
                MessageBox.Show(ex.Message);
            }
        }

      

        private void AlterarHorarios_Load(object sender, EventArgs e)
        {

        }

        private void txt_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if(txt_id.Text != "")
                {
                    int id = int.Parse(txt_id.Text);
                    DalHelper.DeleteHoprario(id);
                    MessageBox.Show("deletado com sucesso");
                    txt_id.Clear();
                    DataTable data = new DataTable();
                    data = DalHelper.ObterHorarios();
                    dataGridView1.DataSource = data;
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
