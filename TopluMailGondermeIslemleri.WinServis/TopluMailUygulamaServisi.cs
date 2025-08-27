using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using TopluMailGonderimUygulamasi.Entities;
using TopluMailGonderimUygulamasi.Helper;
using TopluMailGonderimUygulamasi.Repository;

namespace TopluMailGondermeIslemleri.WinServis
{
    public partial class TopluMailUygulamaServisi : ServiceBase
    {
        System.Timers.Timer t;

        public TopluMailUygulamaServisi()
        {
            InitializeComponent();
            t = new System.Timers.Timer(120000); // 2 dakikada bir çalışır
            t.Elapsed += T_Elapsed;
        }

        private void T_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            using (MusteriRepository musterirepo = new MusteriRepository())
            {
                List<Musteri> musteriListele = musterirepo.TumListe();

                for (int i = 0; i < musteriListele.Count; i++)
                {
                    musteriListele[i].KuponKod = musterirepo.MusteriKuponUret();
                    musteriListele[i].KuponDurum = false;
                    musterirepo.MusteriKuponAta(musteriListele[i]);

                    // Her müşteri için ayrı mail içeriği
                    string MailIcerik = "<div>";
                    MailIcerik += "<p>Merhaba</p>";
                    MailIcerik += "<p>" + musteriListele[i].Ad + " " + musteriListele[i].Soyad + "</p>";
                    MailIcerik += "<p>" + DateTime.Now.ToShortDateString() + " tarihinde size özel bir kupon kodu oluşturuldu.</p>";
                    MailIcerik += "<p>Size özel kupon kodunuz: <strong>" + musteriListele[i].KuponKod + "</strong></p>";
                    MailIcerik += "<p>İlgili kupon kodunu aktif etmek için <a href='http://www.abdullahtural.com/Home/KuponOnay?KuponKod=" + musteriListele[i].KuponKod + "'>Tıklayınız</a></p>";
                    MailIcerik += "</div>";

                    // Mail gönderimi
                    EpostaIslemleri.emailGonder(
                        musteriListele[i].Ad + " " + musteriListele[i].Soyad,
                        musteriListele[i].EmailAdres,
                        "İndirim Kuponu",
                        MailIcerik
                    );
                }
            }
        }

        protected override void OnStart(string[] args)
        {
            t.Start();
        }

        protected override void OnStop()
        {
            t.Stop();
        }

        protected override void OnContinue()
        {
            t.Start();
        }

        protected override void OnPause()
        {
            t.Stop();
        }

        protected override void OnShutdown()
        {
            t.Stop();
        }
    }
}
