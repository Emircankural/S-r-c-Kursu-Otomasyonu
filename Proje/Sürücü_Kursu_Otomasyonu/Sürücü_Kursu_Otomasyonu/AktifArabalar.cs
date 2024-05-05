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

namespace Sürücü_Kursu_Otomasyonu
{
    public partial class AktifArabalar : Form
    {

        MySqlConnection conn = new MySqlConnection("server=localhost;userid=root;password=sanane53;database=okul");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter adapter = new MySqlDataAdapter();

        DataTable dt;


        void veriGetir()
        {
            dt = new DataTable();
            conn.Open();
            adapter = new MySqlDataAdapter("SELECT *FROM araba", conn);

            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
            conn.Close();
        }
        public AktifArabalar()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void AktifArabalar_Load(object sender, EventArgs e)
        {
            veriGetir();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO araba(PLAKA,araba_model,ogretmen) " + "VALUES(@PLAKA,@model,@ogretmen)";
            cmd = new MySqlCommand(sql, conn);
            
            cmd.Parameters.AddWithValue("@PLAKA", textBox1.Text);
            cmd.Parameters.AddWithValue("@model", textBox2.Text);
            cmd.Parameters.AddWithValue("@ogretmen", textBox3.Text);
           



            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            veriGetir();
            MessageBox.Show("Kayıt Eklendi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM araba WHERE PLAKA=@plaka";
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@plaka", textBox1.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            veriGetir();
            MessageBox.Show("Kayıt Silindi");
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE araba" + " SET araba_model=@model,PLAKA=@plaka,ogretmen =@ogretmen"+" WHERE PLAKA =@plaka";
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@plaka", textBox1.Text);
            cmd.Parameters.AddWithValue("@model", textBox2.Text);
            cmd.Parameters.AddWithValue("@ogretmen", textBox3.Text);


            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            veriGetir();
            MessageBox.Show("Kayıt Güncellendi");

        }
    }
}
