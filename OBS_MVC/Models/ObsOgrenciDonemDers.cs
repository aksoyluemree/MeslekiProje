using System;
using System.Collections.Generic;

#nullable disable

namespace OBS_MVC.Models
{
    public partial class ObsOgrenciDonemDers
    {
        public int KayıtId { get; set; }
        public int DonemDersId { get; set; }
        public int OgrenciId { get; set; }
        public int Vize1 { get; set; }
        public int Vize2 { get; set; }
        public int FinalNot { get; set; }
        public int Ortalama { get; set; }
        public int BasariDurumTip { get; set; }

        public virtual ObsDonemDers DonemDers { get; set; }
        public virtual ObsOgrenci Ogrenci { get; set; }
    }
}
