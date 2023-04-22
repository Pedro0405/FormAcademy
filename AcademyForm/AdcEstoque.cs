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

namespace AcademyForm
{
    public partial class AdcEstoque : Form
    {
        public AdcEstoque()
        {
            InitializeComponent();
           
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Cria uma instância do OpenFileDialog
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Define os tipos de arquivo permitidos
            openFileDialog1.Filter = "Arquivos de imagem (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            // Exibe o diálogo OpenFileDialog
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Carrega a imagem selecionada no PictureBox
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 2. Converter a imagem do PictureBox em um array de bytes
                byte[] imagemBytes = null;
                if ((pictureBox1.Image != null) & (textBox1.Text != "") & (textBox2.Text != ""))
                {
                    ImageConverter converter = new ImageConverter();
                    imagemBytes = (byte[])converter.ConvertTo(pictureBox1.Image, typeof(byte[]));
                    string descricao = textBox1.Text;
                    int Valor = int.Parse(textBox2.Text);
                    DalHelper.AddEstoqueComImagem(descricao, Valor, imagemBytes);
                    MessageBox.Show("Equipamento salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Preencha todos os Dados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o equipamento: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
