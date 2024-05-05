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
    public partial class DersEkleÇıkar : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;userid=root;password=sanane53;database=okul");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter adapter = new MySqlDataAdapter();

        DataTable dt;
        void veriGetir()
        {
            dt = new DataTable();
            conn.Open();
            adapter = new MySqlDataAdapter("SELECT *FROM ders_programi", conn);

            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
            conn.Close();
        }
        void veriGetirOgretmen()
        {
            dt = new DataTable();
            conn.Open();
            adapter = new MySqlDataAdapter("SELECT *FROM ogretmen", conn);

            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
            conn.Close();
        }
        public DersEkleÇıkar()
        {
            InitializeComponent();
        }

        private void DersEkleÇıkar_Load(object sender, EventArgs e)
        {
            veriGetir();
            string connectionString = "server=localhost;user=root;database=okul;password=sanane53;";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Veritabanından veri almak için sorgunuzu hazırlayın ve bir MySqlCommand nesnesi oluşturun.
                string query = "SELECT * FROM ogrenci ";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                // Verileri MySQL veritabanından bir MySqlDataReader kullanarak okuyun.
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // Verileri bir DataTable'a yükleyin.
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    // DataGridView kontrolüne DataTable'ı atayın.
                    dataGridView2.DataSource = dataTable;
                }


            }
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Veritabanından veri almak için sorgunuzu hazırlayın ve bir MySqlCommand nesnesi oluşturun.
                string query = "SELECT * FROM ogretmen ";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                // Verileri MySQL veritabanından bir MySqlDataReader kullanarak okuyun.
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // Verileri bir DataTable'a yükleyin.
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    // DataGridView kontrolüne DataTable'ı atayın.
                    dataGridView3.DataSource = dataTable;
                }


            }
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Veritabanından veri almak için sorgunuzu hazırlayın ve bir MySqlCommand nesnesi oluşturun.
                string query = "SELECT * FROM ders ";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                // Verileri MySQL veritabanından bir MySqlDataReader kullanarak okuyun.
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // Verileri bir DataTable'a yükleyin.
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    // DataGridView kontrolüne DataTable'ı atayın.
                    dataGridView4.DataSource = dataTable;
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string maxIdQuery = "SELECT MAX(ders_programi_id) FROM ders_programi";
            int currentMaxId = 0;

            using (var getMaxIdCommand = new MySqlCommand(maxIdQuery, conn))
            {
                conn.Open();
                var result = getMaxIdCommand.ExecuteScalar();
                conn.Close();

                if (result != null && result != DBNull.Value)
                {
                    currentMaxId = Convert.ToInt32(result);
                }
            }

            
            int nextId = currentMaxId + 1;

           
            string sql = "INSERT INTO ders_programi(ogretmen_TC, ogrenci_TC, ders_programi_id, ders_id, tarih, saat) " +
                         "VALUES (@ogretmen_tc, @ogrenci_tc, @ders_programi_id, @ders_id, @tarih, @saat)";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ogretmen_tc", textBox3.Text);
                cmd.Parameters.AddWithValue("@ogrenci_tc", textBox1.Text);
                cmd.Parameters.AddWithValue("@ders_programi_id", textBox4.Text);
                string tarih = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("@tarih", tarih); 
                cmd.Parameters.AddWithValue("@saat", textBox5.Text);
                int dersId;
                if (int.TryParse(textBox2.Text, out dersId))
                {
                   
                    cmd.Parameters.AddWithValue("@ders_id", dersId);
                }
                else
                {
                    
                    MessageBox.Show("Ders ID geçersiz.");
                    return; 
                }

                conn.Open();

                cmd.ExecuteNonQuery();
                conn.Close();
            }

            // İşlem başarıyla tamamlandıktan sonra gerekli diğer adımları gerçekleştirin
            // Örneğin, veriGetir() metodu çağrılabilir ve bir mesaj kutusu gösterilebilir.
            veriGetir();
            MessageBox.Show("Kayıt Eklendi");

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string getMaxIdQuery = "SELECT MAX(ders_programi_id) FROM ders_programi";
            int lastInsertedId = 0;

            using (var getLastIdCommand = new MySqlCommand(getMaxIdQuery, conn))
            {
                conn.Open();
                var result = getLastIdCommand.ExecuteScalar();
                conn.Close();

                if (result != null && result != DBNull.Value)
                {
                    lastInsertedId = Convert.ToInt32(result);
                }
            }

            // Silinecek kaydın ders_programi_id değeri olarak en son eklenenin bir önceki değeri kullanılabilir.
            int idToDelete = lastInsertedId - 1;

            // Şimdi bu id ile kaydı silebiliriz.
            string sql = "DELETE FROM ders_programi WHERE ders_programi_id=@id";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", textBox4.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            // Veri yeniden getirilir ve bir mesaj kutusu gösterilir.
            veriGetir();
            MessageBox.Show("Kayıt Silindi");
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
            
    }
}
