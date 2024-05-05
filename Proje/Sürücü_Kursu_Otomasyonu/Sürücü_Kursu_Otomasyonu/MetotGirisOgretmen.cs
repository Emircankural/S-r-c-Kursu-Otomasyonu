using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sürücü_Kursu_Otomasyonu
{
    internal class MetotGirisOgretmen
    {
        string ConStr = @"server=localhost;userid=root;password=sanane53;database=okul";
        public int KullanıcıKontrol(string kad, string ksifre)
        {
            int sonuc = 0;

            using (var con = new MySqlConnection(ConStr))
            {
                using (var cmd = new MySqlCommand($"SELECT ogretmen_tc,sifre FROM ogretmen WHERE ogretmen_tc ='{kad}' AND sifre ='{ksifre}'", con))
                {
                    try
                    {
                        cmd.Connection.Open();
                        MySqlDataReader dtr = cmd.ExecuteReader();

                        if (dtr.Read())
                        {
                            string d_k = dtr["ogretmen_tc"].ToString();
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
