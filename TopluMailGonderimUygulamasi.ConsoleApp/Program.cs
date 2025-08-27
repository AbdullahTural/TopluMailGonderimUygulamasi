using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopluMailGonderimUygulamasi.Entities;
using TopluMailGonderimUygulamasi.Helper;
using TopluMailGonderimUygulamasi.Repository;

namespace TopluMailGonderimUygulamasi.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string MailIcerik = "";
            using (MusteriRepository musterirepo = new MusteriRepository())
            {
                List<Musteri> musteriListele = musterirepo.TumListe();
                for (global::System.Int32 i = 0; i < musteriListele.Count; i++)
                {
                    musteriListele[i].KuponKod = musterirepo.MusteriKuponUret();
                    musteriListele[i].KuponDurum = false;
                    musterirepo.MusteriKuponAta(musteriListele[i]);

                    // Eposta gönderme işlemleri =>

                    MailIcerik += "<div>";
                    MailIcerik += "<p>Merhaba</p>";
                    MailIcerik += "<p>" + musteriListele[i].Ad + " " + musteriListele[i].Soyad + "</p>";
                    MailIcerik += "<p>" + DateTime.Now.ToShortDateString() + " tarihinde  Size özel bir kupon kodu oluşturuldu.</p>";
                    MailIcerik += "<p>Size özel kupon kodunuz: <strong>" + musteriListele[i].KuponKod + "</strong></p>";
                    MailIcerik += "<p> ilgili kuponkodunu aktif etmek için <a href= http://www.abdullahtural.com/Home/KuponOnay?KuponKod=" + musteriListele[i].KuponKod + "' >Tıklayınız</a></p>";

                    EpostaIslemleri.emailGonder(musteriListele[i].Ad + " " + musteriListele[i].Soyad, musteriListele[i].EmailAdres, "İndirim Kuponu", MailIcerik);
                }
            }
        }
    }
}
