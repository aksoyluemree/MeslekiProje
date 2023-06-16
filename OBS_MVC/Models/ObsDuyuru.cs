using System;
using System.Collections.Generic;

#nullable disable

namespace OBS_MVC.Models
{
    public partial class ObsDuyuru
    {
        public int DuyuruId { get; set; }
        public string Duyuru { get; set; }
        public int BolumId { get; set; }

        public virtual ObsBolum Bolum { get; set; }
    }
}
