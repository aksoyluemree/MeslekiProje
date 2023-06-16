using System;
using System.Collections.Generic;

#nullable disable

namespace OBS_MVC.Models
{
    public partial class ObsDonemDers
    {
        public ObsDonemDers()
        {
            OgrenciDonemDers = new HashSet<ObsOgrenciDonemDers>();
            OgretimGorevlisiDers = new HashSet<ObsOgretimGorevlisiDers>();
            SinavTarihleri = new HashSet<ObsSinavTarih>();
        }

        public int DonemDersId { get; set; }
        public int DonemId { get; set; }
        public int DersId { get; set; }
        public int OgretimGorevlisiId { get; set; }

        public virtual ObsDers Ders { get; set; }
        public virtual ObsDonem Donem { get; set; }
        public virtual ObsOgretimGorevlisi OgretimGorevlisi { get; set; }
        public virtual ICollection<ObsOgrenciDonemDers> OgrenciDonemDers { get; set; }
        public virtual ICollection<ObsOgretimGorevlisiDers> OgretimGorevlisiDers { get; set; }
        public virtual ICollection<ObsSinavTarih> SinavTarihleri { get; set; }
    }
}
