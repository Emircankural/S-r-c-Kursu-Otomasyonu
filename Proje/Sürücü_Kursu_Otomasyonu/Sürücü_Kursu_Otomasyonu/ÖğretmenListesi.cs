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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Sürücü_Kursu_Otomasyonu
{
    public partial class ÖğretmenListesi : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;userid=root;password=sanane53;database=okul");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        
        DataTable dt;
        
        void veriGetir()
        {
            dt = new DataTable();
            conn.Open();
            adapter = new MySqlDataAdapter("SELECT *FROM ogretmen", conn);
            
            adapter.Fill(dt);
            
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        public ÖğretmenListesi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string sql = "INSERT INTO ogretmen(ogretmen_TC, ad, soyad, sifre, telno, PLAKA) " +
             "VALUES (@ogretmen_TC, @ad, @soyad, @sifre, @telno,@plaka)";

            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox5.Text);
            cmd.Parameters.AddWithValue("@ogretmen_TC", textBox2.Text);
            cmd.Parameters.AddWithValue("@telno", textBox4.Text);
            cmd.Parameters.AddWithValue("@sifre", textBox3.Text);
            
            cmd.Parameters.AddWithValue("@plaka", textBox6.Text); 





            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            veriGetir();
            MessageBox.Show("Kayıt Eklendi");

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string sql = "DELETE FROM ogretmen WHERE ogretmen_TC=@tc";
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@tc", textBox2.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            veriGetir();
            MessageBox.Show("Kayıt Silindi");
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();


            }
            catch
            {


            }
        }

        private void ÖğretmenListesi_Load(object sender, EventArgs e)
        {
            veriGetir();
        }
    }
}
