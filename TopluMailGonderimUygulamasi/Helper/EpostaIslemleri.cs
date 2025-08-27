using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TopluMailGonderimUygulamasi.Helper
{
    public class EpostaIslemleri
    {
        public static void emailGonder(string isimsoyisim, string emailadres, string konu, string icerik)
        //{
        //    MailMessage mail = new MailMessage();
        //    mail.From = new MailAddress("cengizatillaudemy@cengizatilla.com", "ABCD Magaza");
        //    mail.To.Add(new MailAddress(emailadres, isimsoyisim));
        //    mail.Subject = konu;
        //    mail.Body = icerik;
        //    mail.IsBodyHtml = true;

        //    SmtpClient client = new SmtpClient("mail.cengizatilla.com", 587);
        //    client.Credentials = new System.Net.NetworkCredential("cengizatillaudemy@cengizatilla.com", "Q184NAbg");
        //    client.EnableSsl = false;

        //    client.Send(mail);
        //}
        {
            Encoding encode = Encoding.GetEncoding("windows-1254");

            MailMessage email = new MailMessage();
            MailAddress from = new MailAddress("karneynim@gmail.com", "Kur Takip Sistemi", encode);
            MailAddress to = new MailAddress(emailadres, isimsoyisim, encode);

            email.To.Add(to);
            email.From = from;

            email.Subject = konu;
            email.Body = icerik;
            email.IsBodyHtml = true;

            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string kullaniciAdi = "karneynim@gmail.com";       // Gönderici adresi
            string uygulamaSifresi = "duaparzjujqhqlhq";    // Google'dan aldığın 16 karakterlik uygulama şifresi (boşluksuz yaz!)

            using (SmtpClient smtp = new SmtpClient(smtpServer, smtpPort))
            {
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(kullaniciAdi, uygulamaSifresi); // Normal şifre değil, uygulama şifresi!

                try
                {
                    smtp.Send(email);
                    Console.WriteLine("✅ E-posta başarıyla gönderildi.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ E-posta gönderme hatası: " + ex.Message);
                }
            }
        }
    }
}
