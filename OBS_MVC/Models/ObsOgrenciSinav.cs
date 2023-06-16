using System;
using System.Collections.Generic;

#nullable disable

namespace OBS_MVC.Models
{
    public partial class ObsOgrenciSinav
    {
        public int OgrenciSinavId { get; set; }
        public int OgrenciId { get; set; }
        public int SinavId { get; set; }
        public int? Notu { get; set; }

        public virtual ObsOgrenci Ogrenci { get; set; }
        public virtual ObsSinavTarih Sinav { get; set; }
    }
}
