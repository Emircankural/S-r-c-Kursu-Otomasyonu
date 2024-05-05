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
    public partial class Öğretmen_Giriş : Form
    {
        MetotGirisOgretmen mtt = new MetotGirisOgretmen();
        public Öğretmen_Giriş()
        {
            InitializeComponent();
        }

        private void Öğretmen_Giriş_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ÖğretmenPanel ogretmen=new ÖğretmenPanel();
            
            


            if (mtt.KullanıcıKontrol(textBox1.Text, textBox2.Text) == 1)
            {
                ogretmen.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Yapılamadı Kullanıcı Adı Veya Şifre Hatalı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState==CheckState.Checked) 
            {
                textBox2.UseSystemPasswordChar = true; 
            }
            else if (checkBox1.CheckState==CheckState.Unchecked)
            {
                textBox2.UseSystemPasswordChar=false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
