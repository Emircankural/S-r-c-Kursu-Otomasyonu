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
    public partial class öğrencikayıt : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;userid=root;password=sanane53;database=okul");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataTable dt;
        string cinsiyet;
        public öğrencikayıt()
        {
            InitializeComponent();
        }
        void veriGetir()
        {
            dt= new DataTable();    
            conn.Open();
            adapter=new MySqlDataAdapter("SELECT *FROM ogrenci",conn);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyet = "Erkek";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO ogrenci(ogrenci_tc,ad,soyad,cinsiyet,dog_tarih,telno,ehliyet_tur) "+"VALUES(@ogrenci_tc,@ad,@soyad,@cinsiyet,@dog_tarih,@telno,@ehliyet_tur)";
            cmd=new MySqlCommand(sql,conn);
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox4.Text);
            cmd.Parameters.AddWithValue("@ogrenci_tc", textBox2.Text);
            cmd.Parameters.AddWithValue("@telno", textBox3.Text);
            cmd.Parameters.AddWithValue("@cinsiyet",cinsiyet);
            cmd.Parameters.AddWithValue("@dog_tarih", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@ehliyet_tur", comboBox1.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            veriGetir();
            MessageBox.Show("Kayıt Eklendi");

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyet = "Kadın";
        }

        private void öğrencikayıt_Load(object sender, EventArgs e)
        {
            veriGetir();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                string cins = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                if (cins == "Erkek")
                    radioButton1.Checked = true;
                else
                {
                    radioButton2.Checked = true;
                }
                dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            }
            catch 
            {

                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM ogrenci WHERE ogrenci_tc=@tc";
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@tc", textBox2.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            veriGetir();
            MessageBox.Show("Kayıt Silindi");


        }
    }
}
