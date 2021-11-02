using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theBAPapp.Data
{
    public class Event
    {
        [Key]
        [Required]
        [Display(Name = "Event Id")]
        public Guid EventId { get; set; }
        public DateTime Date { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Venue")]
        public string VenueId { get; set; }

        [Required]
        //[ForeignKey(CrewerId)]
        [Display(Name = "Crewer")]
        public string CrewerId { get; set; }
        public string Position { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }

        [Required]
        [Display(Name = "Have you been paid?")]
        public bool IsPaid { get; set; }

        [Display (Name = "Did they take out taxes?")]
        public bool IsTaxed { get; set; }

        [Display(Name = "Paid via direct deposit?")]
        public bool IsDirectDeposit { get; set; }

        //public Category EventType { get; set; }


    }
}
