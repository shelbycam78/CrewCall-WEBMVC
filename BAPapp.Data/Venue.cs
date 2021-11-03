using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Data
{
    public class Venue
    {
        [Key]
        [Required]
        public string VenueId { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Location { get; set; }
        
        //[ForeignKey("Crewer")]
        public Guid CrewerId { get; set; }
        public string PointOfContact { get; set; }
    }
}
