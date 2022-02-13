using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Individuellt_projekt_Databaser.Models
{
    public partial class Befattning
    {
        public Befattning()
        {
            Personal = new HashSet<Personal>();
        }

        public int Id { get; set; }
        public string Befattning1 { get; set; }

        public virtual ICollection<Personal> Personal { get; set; }
    }
}
