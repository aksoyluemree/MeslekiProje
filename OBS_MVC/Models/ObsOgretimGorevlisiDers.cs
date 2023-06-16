using System;
using System.Collections.Generic;

#nullable disable

namespace OBS_MVC.Models
{
    public partial class ObsOgretimGorevlisiDers
    {
        public int OgretmenDersId { get; set; }
        public int OgretimGorevlisiId { get; set; }
        public int DonemDersId { get; set; }

        public virtual ObsDonemDers DonemDers { get; set; }
        public virtual ObsOgretimGorevlisi OgretimGorevlisi { get; set; }
    }
}
