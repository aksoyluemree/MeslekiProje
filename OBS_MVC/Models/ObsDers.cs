using System;
using System.Collections.Generic;

#nullable disable

namespace OBS_MVC.Models
{
    public partial class ObsDers
    {
        public ObsDers()
        {
            DonemDers = new HashSet<ObsDonemDers>();
        }

        public int DersId { get; set; }
        public string Ad { get; set; }
        public string Kod { get; set; }
        public int BolumId { get; set; }

        public virtual ObsBolum Bolum { get; set; }
        public virtual ICollection<ObsDonemDers> DonemDers { get; set; }
    }
}
