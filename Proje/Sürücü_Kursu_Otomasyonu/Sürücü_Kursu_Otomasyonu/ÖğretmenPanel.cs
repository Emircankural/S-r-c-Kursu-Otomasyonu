using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sürücü_Kursu_Otomasyonu
{
    public partial class ÖğretmenPanel : Form
    {
        public ÖğretmenPanel()
        {
            InitializeComponent();
        }

        private void ÖğretmenPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            direksiyondersprogramı direksiyondersprogramı=new direksiyondersprogramı();
            direksiyondersprogramı.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DersProgramı dersProgramı =new DersProgramı();
            dersProgramı.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Öğretmenlistesiö öğretmenlistesiö=new Öğretmenlistesiö();
            öğretmenlistesiö.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            öğretmenarabalistesi öğretmenarabalistesi = new öğretmenarabalistesi();
            öğretmenarabalistesi.ShowDialog();
        }
    }
}
