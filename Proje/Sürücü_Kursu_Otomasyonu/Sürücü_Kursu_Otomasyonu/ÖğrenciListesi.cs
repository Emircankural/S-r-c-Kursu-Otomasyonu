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
    public partial class ÖğrenciListesi : Form
    {
        string dbconstr="server=localhost;userid=root;password=sanane53;database=okul";
        public ÖğrenciListesi()
        {
            InitializeComponent();
        }

        private void ÖğrenciListesi_Load(object sender, EventArgs e)
        {
            using (var baglan = new MySqlConnection(dbconstr))
            {
                using (var adap = new MySqlDataAdapter("SELECT * FROM ogrenci", baglan))
                {
                    try
                    {
                        baglan.Open();
                        DataTable dt = new DataTable(); 
                        adap.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception)
                    {

                        
                    }
                }
            }
        }
    }
}
