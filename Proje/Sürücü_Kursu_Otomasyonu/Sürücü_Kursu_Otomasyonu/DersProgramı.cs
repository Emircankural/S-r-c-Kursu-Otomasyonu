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
    public partial class DersProgramı : Form
    {
        public DersProgramı()
        {
            InitializeComponent();
        }

        private void DersProgramı_Load(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;database=okul;password=sanane53;";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Veritabanından veri almak için sorgunuzu hazırlayın ve bir MySqlCommand nesnesi oluşturun.
                string query = "SELECT * FROM ders_programi ";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                // Verileri MySQL veritabanından bir MySqlDataReader kullanarak okuyun.
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // Verileri bir DataTable'a yükleyin.
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    // DataGridView kontrolüne DataTable'ı atayın.
                    dataGridView1.DataSource = dataTable;
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
                    dataGridView2.DataSource = dataTable;
                }

            }
        }
    }
}
