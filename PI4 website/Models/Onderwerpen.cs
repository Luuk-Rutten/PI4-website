using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace PI4_website.Models
{
    public class Onderwerpen
    {
        [Key]
        public int OnderwerpID { get; set; }

        public string? Name { get; set; }

        public string ShowName => Name;
        public ICollection<KoppelTabel> Koppelingen { get; set; }


        /*        public ICollection<Onderwerpen> OnderwerpenCol {  get; set; }
                public KoppelTabel KoppelTabel { get; set; }*/



    }
}
