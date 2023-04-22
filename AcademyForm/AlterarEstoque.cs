using csharp_Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace AcademyForm
{
    public partial class AlterarEstoque : Form
    {
        public AlterarEstoque(int id)
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt = DalHelper.SelectImagemEquipamentoForID(id);
            byte[] imagemByte = (byte[])dt.Rows[0].ItemArray[0];
            label3.Text = id.ToString();

            MemoryStream stream = new MemoryStream(imagemByte);
            Image imagem = Image.FromStream(stream);
            pictureBox1.Image = imagem;

            DataTable da = new DataTable();
            da = DalHelper.SelectTudoEstoqueForID(id);
            textBox1.Text = da.Rows[0].ItemArray[1].ToString();
            textBox2.Text = da.Rows[0].ItemArray[2].ToString();
        }

        private void AlterarEstoque_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text != "") & (textBox2.Text != ""))
                {
                    DialogResult = MessageBox.Show("Confirmar alterações?", "atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (DialogResult == DialogResult.Yes)
                    {
                        string descricao = textBox1.Text;
                        int valor = int.Parse(textBox2.Text);
                        int id = int.Parse(label3.Text);
                        byte[] imagemBytes = null;
                        ImageConverter converter = new ImageConverter();
                        imagemBytes = (byte[])converter.ConvertTo(pictureBox1.Image, typeof(byte[]));


                        DalHelper.UpdateEstoque(id, descricao, valor, imagemBytes);
                       MessageBox.Show("Alterqado com sucesso", "uhuul", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
    }
}
