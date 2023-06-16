using System;
using System.Collections.Generic;

#nullable disable

namespace OBS_MVC.Models
{
    public partial class ObsDonem
    {
        public ObsDonem()
        {
            DonemDersleri = new HashSet<ObsDonemDers>();
        }

        public int DonemId { get; set; }
        public int Yil { get; set; }
        public int DonemTip { get; set; }

        public virtual ICollection<ObsDonemDers> DonemDersleri { get; set; }
    }
}
