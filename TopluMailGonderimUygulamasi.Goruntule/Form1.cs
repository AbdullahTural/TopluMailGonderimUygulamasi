using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TopluMailGonderimUygulamasi.Entities;
using TopluMailGonderimUygulamasi.Helper;
using TopluMailGonderimUygulamasi.Repository;

namespace TopluMailGonderimUygulamasi.Goruntule
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            KayitListe();
        }

        private void btn_ornek_data_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 200; i++)
            {
                Musteri musteri = new Musteri();
                musteri.Ad = FakeData.NameData.GetFirstName();
                musteri.Soyad = FakeData.NameData.GetSurname();
                    musteri.EmailAdres = musteri.Ad + "." + musteri.Soyad + FakeData.NetworkData.GetDomain();
                using (MusteriRepository musterirepo = new MusteriRepository())
                {
                    musterirepo.KayitEKLE(musteri);
                }
            }
            KayitListe();
        }

        void KayitListe()
        {
            List<Musteri> musteriListesi = new List<Musteri>();
            using (MusteriRepository musterirepo =  new MusteriRepository())
            {
                musteriListesi = musterirepo.TumListe();
            }
            grd_musteri.DataSource = musteriListesi;
        }

        private void btn_yenile_Click(object sender, EventArgs e)
        {
            KayitListe();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //var g = new GlobalIslemler();
            //g.tryCatchKullan(() =>
            //{
            //    throw new Exception("Bu bir test hatasıdır.");
            //});

            //MessageBox.Show("Log testi tamamlandı.");
        }

        private void btn_kuponTest_Click(object sender, EventArgs e)
        {
            using (MusteriRepository repo = new MusteriRepository())
            {
                List<Musteri> musteriler = repo.TumListe(); // Tüm müşterileri al
                foreach (var musteri in musteriler)
                {
                    string kupon = repo.MusteriKuponUret(); // Her müşteri için yeni kupon üret
                    musteri.KuponKod = kupon;
                    musteri.KuponDurum = false;
                    musteri.KuponAktifTarih = DateTime.Now;

                    repo.MusteriKuponAta(musteri); // Kuponu müşteriye ata
                }

                MessageBox.Show("Tüm müşterilere kupon atandı.");
            }
        }
    }
}
