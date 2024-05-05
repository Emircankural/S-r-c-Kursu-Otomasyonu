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
    public partial class AdminPaneli : Form
    {
        public AdminPaneli()
        {
            InitializeComponent();
        }

        private void AdminPaneli_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            öğrencikayıt öğrencikayıt=new öğrencikayıt();
            öğrencikayıt.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DersEkleÇıkar dersEkleÇıkar=new DersEkleÇıkar();
            dersEkleÇıkar.ShowDialog();
        }

        private void AdminPaneli_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ÖğrenciListesi öğrenciListesi=new ÖğrenciListesi();
            öğrenciListesi.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ÖğretmenListesi öğretmenListesi=new ÖğretmenListesi();
            öğretmenListesi.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AktifArabalar aktifArabalar=new AktifArabalar();
            aktifArabalar.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ÖdemelerListesi ödemelerListesi=new ÖdemelerListesi();
            ödemelerListesi.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DersProgramı dersProgramı= new DersProgramı();
            dersProgramı.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DireksiyonDersiKayıt direksiyonDersiKayıt= new DireksiyonDersiKayıt();
            direksiyonDersiKayıt.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            direksiyondersprogramı direksiyondersprogramı= new direksiyondersprogramı();
            direksiyondersprogramı.ShowDialog();
        }
    }
}
