using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Data
{
    public class Crewer
    {
        [Key]
        [Required]
        public Guid CrewerId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        //[ForeignKey("Venue")]
        //public string VenueId { get; set; }

        //[ForeignKey("Event")]
        //public string EventId { get; set; }

    }
}
