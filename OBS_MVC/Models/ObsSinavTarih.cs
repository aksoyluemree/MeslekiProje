using System;
using System.Collections.Generic;

#nullable disable

namespace OBS_MVC.Models
{
    public partial class ObsSinavTarih
    {
        public ObsSinavTarih()
        {
            OgrenciSinavlari = new HashSet<ObsOgrenciSinav>();
        }

        public int SinavId { get; set; }
        public int SinavTur { get; set; }
        public DateTime SinavTarih { get; set; }
        public int DonemDersId { get; set; }

        public virtual ObsDonemDers DonemDers { get; set; }
        public virtual ICollection<ObsOgrenciSinav> OgrenciSinavlari { get; set; }
    }
}
