using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PI4_website.Models
{
    public class KoppelTabel
    {
        [Key]
        public int KoppelID { get; set; }



        /*        public ICollection<Onderwerpen> OnderwerpenCol { get; set; }
                public ICollection<Video> VideoCol { get; set; }*/

        [ForeignKey("Onderwerpen")]
        public int OnderwerpID { get; set; }


        [ForeignKey("Video")]
        public int VideoID { get; set; }

        public Video Video { get; set; }
        public Onderwerpen Onderwerpen { get; set; }

    }
}