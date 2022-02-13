using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Individuellt_projekt_Databaser.Models
{
    public partial class Elev
    {
        public int Id { get; set; }
        public string FNamn { get; set; }
        public string ENamn { get; set; }
        public int PersonNummer { get; set; }
        public int KlassId { get; set; }

        public virtual Klass Klass { get; set; }
    }
}
