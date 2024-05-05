using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sürücü_Kursu_Otomasyonu
{
    internal class Metot
    {
        string ConStr = @"server=localhost;userid=root;password=sanane53;database=okul";
        public int KullanıcıKontrol(string kad , string ksifre)
        {
            int sonuc = 0;

            using (var con=new MySqlConnection(ConStr))
            {
                using (var cmd = new MySqlCommand($"SELECT admin_id,sifre FROM admin WHERE admin_id ='{kad}' AND sifre ='{ksifre}'", con))
                {
                    try
                    {
                        cmd.Connection.Open();
                        MySqlDataReader dtr = cmd.ExecuteReader();

                        if (dtr.Read()) 
                        {
                            string d_k = dtr["admin_id"].ToString();
                            string d_s = dtr["sifre"].ToString();
                            if (d_k == kad && d_s == ksifre)
                            {
                                sonuc = 1;
                            }
                            else 
                            {
                                sonuc = 0;
                            }
                        }
                    }
                    catch 
                    {

                        sonuc = 0;
                    }
                }
            }



                return sonuc;
        }
    }
}
