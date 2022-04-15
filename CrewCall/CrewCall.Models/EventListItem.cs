using CrewCall.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrewCall.Models
{
    public class EventListItem
    {
        [Key]
        [Required]
        [Display(Name = "Invoice Number")]
        public int EventId { get; set; }


        [Display(Name = "Date")]
        public DateTime EventDate { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string EventTitle { get; set; }

        [Required]
        [ForeignKey(nameof(VenueId))]
        [Display(Name = "Venue")]
        public int VenueId { get; set; }

        [Required]
        [ForeignKey(nameof(ClientId))]
        [Display(Name = "Client")]
        public int ClientId { get; set; }
     
        [Required]
        [Display(Name = "Have you been paid?")]
        public bool IsPaid { get; set; }

        [Display(Name = "Did they take out taxes?")]
        public bool IsTaxed { get; set; }

        [Display(Name = "Paid via direct deposit?")]
        public bool IsDirectDeposit { get; set; }

        public EventType EventType { get; set; }


        // public string Position { get; set; }
        // public string Director { get; set; }
        // public string Producer { get; set; }

        public virtual Venue Venue { get; set; }
        public virtual Client Client { get; set; }
    }
}
