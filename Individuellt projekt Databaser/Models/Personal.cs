using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Individuellt_projekt_Databaser.Models
{
    public partial class Personal
    {
        public Personal()
        {
            Kurs = new HashSet<Kurs>();
        }

        public int Id { get; set; }
        public string FNamn { get; set; }
        public string ENamn { get; set; }
        public int BefattningsId { get; set; }
        public int? SkolId { get; set; }
        public int? Månadslön { get; set; }
        public DateTime? Anställningsdatum { get; set; }

        public virtual Befattning Befattnings { get; set; }
        public virtual ICollection<Kurs> Kurs { get; set; }
    }
}
