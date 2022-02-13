using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Individuellt_projekt_Databaser.Models
{
    public partial class Skola
    {
        public Skola()
        {
            Klass = new HashSet<Klass>();
        }

        public int Id { get; set; }
        public string SkolNamn { get; set; }

        public virtual ICollection<Klass> Klass { get; set; }
    }
}
