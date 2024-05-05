using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Sürücü_Kursu_Otomasyonu
{
    public partial class AdminGiriş : Form
    {

        Metot mtt = new Metot();

        public AdminGiriş()
        {
            InitializeComponent();
        }

        private void AdminGiriş_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            AdminPaneli adminPaneli = new AdminPaneli();


            if (mtt.KullanıcıKontrol(textBox1.Text, textBox2.Text) == 1)
            {
                adminPaneli.Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show("Giriş Yapılamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        } 

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else if (checkBox1.CheckState == CheckState.Unchecked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void AdminGiriş_Load(object sender, EventArgs e)
        {

        }
    }
}
