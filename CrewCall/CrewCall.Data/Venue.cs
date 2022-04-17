using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrewCall.Data
{
    public class Venue
    {

        [Key]
        [Required]
        public int VenueId { get; set; }

        [Required]
        [Display(Name = "Venue")]
        public string VenueName { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string VenueLocation { get; set; }


        public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    }
}
