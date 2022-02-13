using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Individuellt_projekt_Databaser.Models
{
    public partial class Klass
    {
        public Klass()
        {
            Elev = new HashSet<Elev>();
        }

        public int Id { get; set; }
        public string Namn { get; set; }
        public int? AntalElever { get; set; }
        public int SkolaId { get; set; }

        public virtual Skola Skola { get; set; }
        public virtual ICollection<Elev> Elev { get; set; }
    }
}
