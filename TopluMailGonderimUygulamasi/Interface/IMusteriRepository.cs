using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopluMailGonderimUygulamasi.Entities;

namespace TopluMailGonderimUygulamasi.Interface
{
    public  interface IMusteriRepository
    {
        int KayitEKLE(Musteri m);
        int MusteriKuponAta(Musteri m);
        string MusteriKuponUret();

        Musteri MusteriKuponAra(string KuponKod);
        List<Musteri> TumListe();

        Musteri GetirID(int ID);

    }
}
