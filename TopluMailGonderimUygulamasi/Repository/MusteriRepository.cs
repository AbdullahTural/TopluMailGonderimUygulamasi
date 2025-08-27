using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopluMailGonderimUygulamasi.Database;
using TopluMailGonderimUygulamasi.Entities;
using TopluMailGonderimUygulamasi.Helper;
using TopluMailGonderimUygulamasi.Interface;

namespace TopluMailGonderimUygulamasi.Repository
{
    public class MusteriRepository : GlobalIslemler, IMusteriRepository, IDisposable
    {
        SqlCommand cmd;
        SqlDataReader reader;
        int returnValue;
        DataAccessLayer DAL;

        public MusteriRepository()
        {
            DAL = new DataAccessLayer();
        }
        public Musteri GetirID(int ID)
        {
            Musteri musteri = new Musteri();
            tryCatchKullan(() =>
            {
                cmd = new SqlCommand("MusteriGetirID");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;
                reader = DAL.VeriGetir(cmd);
                while (reader.Read())
                {
                    musteri.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    musteri.Ad = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    musteri.Soyad = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    musteri.EmailAdres = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    musteri.KuponKod = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                    musteri.KuponDurum = reader.IsDBNull(5) ? false : reader.GetBoolean(5);
                    musteri.KuponAktifTarih = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                }
                reader.Close();
                DAL.con.Close();
            });
            return musteri;
        }

        public int KayitEKLE(Musteri m)
        {
            tryCatchKullan(() => 
            {
                cmd = new SqlCommand("KayitEkle");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(@"Ad", SqlDbType.NVarChar).Value = m.Ad;
                cmd.Parameters.Add(@"Soyad", SqlDbType.NVarChar).Value = m.Soyad;
                cmd.Parameters.Add(@"EmailAdres", SqlDbType.NVarChar).Value = m.EmailAdres;
                returnValue = DAL.Calistir(cmd);
            });
            return returnValue;
        }

        public int MusteriKuponAta(Musteri m)
        {
            tryCatchKullan(() => 
            {
                cmd = new SqlCommand("KuponKodAta");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID" , SqlDbType.Int).Value = m.ID;
                cmd.Parameters.Add("@KuponKod", SqlDbType.NVarChar).Value = m.KuponKod;
                cmd.Parameters.Add("@KuponDurum", SqlDbType.Bit).Value = m.KuponDurum;

                returnValue = DAL.Calistir(cmd);
            });
            return returnValue;
        }

        public Musteri MusteriKuponAra(string KuponKod)
        {
            Musteri musteri = new Musteri();
            tryCatchKullan(() => 
            {
                cmd = new SqlCommand("MusteriKuponKodAra");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@KuponKod", SqlDbType.NVarChar).Value = KuponKod;
                reader = DAL.VeriGetir(cmd);
                while (reader.Read())
                {
                    musteri.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    musteri.Ad = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    musteri.Soyad = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    musteri.EmailAdres = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    musteri.KuponKod = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                    musteri.KuponDurum = reader.IsDBNull(5) ? false : reader.GetBoolean(5);
                    musteri.KuponAktifTarih = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6);
                }
                reader.Close();
                DAL.con.Close();
            });
            return musteri;
        }

        public string MusteriKuponUret()
        {
            string musterikupon = string.Empty;
            tryCatchKullan(() =>
            {
                do
                {
                    Random rnd = new Random();
                    musterikupon = rnd.Next(111111,999999).ToString();
                    cmd = new SqlCommand("KuponKodKontrol");
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@KuponKod", SqlDbType.NVarChar).Value = musterikupon;
                }while (DAL.CalistirINT(cmd) > 0 );
                
            });
            return musterikupon;
        }

        public List<Musteri> TumListe()
        {
            List<Musteri> musteriListe = new List<Musteri>();
            tryCatchKullan(() =>
            {
                cmd = new SqlCommand("MusteriListe");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                reader = DAL.VeriGetir(cmd);
                while (reader.Read())
                {
                    musteriListe.Add(new Musteri()
                    {
                        ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        Ad = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Soyad = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        EmailAdres = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        KuponKod = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        KuponDurum = reader.IsDBNull(5) ? false : reader.GetBoolean(5),
                        KuponAktifTarih = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6)

                    });
                }
                reader.Close();
                DAL.con.Close();
            });
            return musteriListe;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this); // ?
        }
    }
}
