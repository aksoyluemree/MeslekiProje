using System;
using System.Collections.Generic;

#nullable disable

namespace OBS_MVC.Models
{
    public partial class ObsBolum
    {
        public ObsBolum()
        {
            Dersler = new HashSet<ObsDers>();
            Duyurular = new HashSet<ObsDuyuru>();
            Ogrenciler = new HashSet<ObsOgrenci>();
            OgretimGorevlileri = new HashSet<ObsOgretimGorevlisi>();
        }

        public int BolumId { get; set; }
        public string Ad { get; set; }
        public string Adres { get; set; }
        public string Kod { get; set; }
        public int FakulteId { get; set; }

        public virtual ObsFakulte Fakulte { get; set; }
        public virtual ICollection<ObsDers> Dersler { get; set; }
        public virtual ICollection<ObsDuyuru> Duyurular { get; set; }
        public virtual ICollection<ObsOgrenci> Ogrenciler { get; set; }
        public virtual ICollection<ObsOgretimGorevlisi> OgretimGorevlileri { get; set; }
    }
}
