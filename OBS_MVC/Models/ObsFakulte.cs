using System;
using System.Collections.Generic;

#nullable disable

namespace OBS_MVC.Models
{
    public partial class ObsFakulte
    {
        public ObsFakulte()
        {
            Bolumler = new HashSet<ObsBolum>();
        }

        public int FakulteId { get; set; }
        public string Ad { get; set; }
        public string Adres { get; set; }

        public virtual ICollection<ObsBolum> Bolumler { get; set; }
    }
}
