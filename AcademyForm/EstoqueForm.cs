using csharp_Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademyForm
{
    public partial class EstoqueForm : Form
    {
        public EstoqueForm()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt = DalHelper.ObterEstoque();
            dataGridView1.DataSource = dt;
       
          
        }
       

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdcEstoque novo = new AdcEstoque();
            novo.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int idEquipamento = int.Parse(dataGridView1.SelectedRows[0].Cells["id"].Value.ToString());
                    DialogResult = MessageBox.Show("Deseja alterar item selecionao?", "atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {

                        AlterarEstoque novo = new AlterarEstoque(idEquipamento);
                        novo.Show();

                    }
                
                }

                }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
            
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int idEquipamento = int.Parse(dataGridView1.SelectedRows[0].Cells["id"].Value.ToString());
                    DataTable da = new DataTable();
                    da = DalHelper.SelectImagemEquipamentoForID(idEquipamento);

                    byte[] imagemBytes = (byte[])da.Rows[0].ItemArray[0];

                    MemoryStream stream = new MemoryStream(imagemBytes);
                    Image imagem = Image.FromStream(stream);
                    pictureBox1.Image = imagem;
                }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView1.SelectedRows.Count > 0)
                {
                    DialogResult = MessageBox.Show("tem crteza que deseja excluir o item selecionado?", "atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(DialogResult == DialogResult.Yes)
                    {
                        int idEquipamento = int.Parse(dataGridView1.SelectedRows[0].Cells["id"].Value.ToString());
                        DalHelper.DeleteEstoque(idEquipamento);
                        MessageBox.Show("Contato excluido cpom sucesso", "atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataTable dt = new DataTable();
                        dt = DalHelper.ObterEstoque();
                        dataGridView1.DataSource = dt;
                    }
                 
                }
                else
                {
                    //nenhum item selecionado
                }
            }catch(Exception wx)
            {
                MessageBox.Show(wx.Message);
                
               
            }
        }

        private void EstoqueForm_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
