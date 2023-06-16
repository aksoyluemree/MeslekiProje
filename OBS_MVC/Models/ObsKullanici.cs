using System;
using System.Collections.Generic;

#nullable disable

namespace OBS_MVC.Models
{
    public partial class ObsKullanici
    {
        public ObsKullanici()
        {
            Ogrenciler = new HashSet<ObsOgrenci>();
            OgretimGorevlileri = new HashSet<ObsOgretimGorevlisi>();
        }

        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string KimlikNo { get; set; }
        public string Turu { get; set; }

        public virtual ICollection<ObsOgrenci> Ogrenciler { get; set; }
        public virtual ICollection<ObsOgretimGorevlisi> OgretimGorevlileri { get; set; }
    }
}
