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
    public partial class TurmaProfForm : Form
    {
        public TurmaProfForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProfessorsForm novo = new ProfessorsForm();
            novo.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TurmasForm novo = new TurmasForm(); 
            novo.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddEclAltAlunosForr novo = new AddEclAltAlunosForr();
            novo.Show();
            this.Close();
        }
    }
}
