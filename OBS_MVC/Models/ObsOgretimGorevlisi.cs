using System;
using System.Collections.Generic;

#nullable disable

namespace OBS_MVC.Models
{
    public partial class ObsOgretimGorevlisi
    {
        public ObsOgretimGorevlisi()
        {
            DonemDersleri = new HashSet<ObsDonemDers>();
            OgretimGorevlisiDersleri = new HashSet<ObsOgretimGorevlisiDers>();
        }

        public int OgretimGorevlisiId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KimlikNo { get; set; }
        public string Eposta { get; set; }
        public DateTime DogumTarih { get; set; }
        public DateTime GirisTarih { get; set; }
        //public DateTime? CikisTarih { get; set; }
        public int BolumId { get; set; }
        public int KullaniciId { get; set; }
        public byte[] Resim { get; set; }
        public virtual ObsBolum Bolum { get; set; }
        public virtual ObsKullanici Kullanici { get; set; }
        public virtual ICollection<ObsDonemDers> DonemDersleri { get; set; }
        public virtual ICollection<ObsOgretimGorevlisiDers> OgretimGorevlisiDersleri { get; set; }
    }
}
