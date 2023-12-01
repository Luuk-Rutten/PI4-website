using System.ComponentModel.DataAnnotations;

namespace PI4_website.Models
{
    public class Video
    {
        [Key]
        public int VideoID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Link { get; set; }

    

/*        public KoppelTabel KoppelTabel { get; set; }
*/        public ICollection<KoppelTabel> Koppelingen { get; set; }

        /* public virtual List<Video> Videos { get; set; }*/
    }
}

