using System;
using System.ComponentModel.DataAnnotations;

namespace CrewCall.Models
{
    public class EventListItem
    {

        [Display(Name = "Invoice Number")]
        public int EventId { get; set; }


        [Display(Name = "Date")]
        public DateTime EventDate { get; set; }

        [Display(Name = "Title")]
        public string EventTitle { get; set; }


        [Display(Name = "Venue")]
        public int VenueId { get; set; }


        [Display(Name = "Client")]
        public int ClientId { get; set; }

        [Display(Name = "Contact")]
        public int ContactId { get; set; }


        [Display(Name = "Have you been paid?")]
        public bool IsPaid { get; set; }

        [Display(Name = "Did they take out taxes?")]
        public bool IsTaxed { get; set; }

        [Display(Name = "Paid via direct deposit?")]
        public bool IsDirectDeposit { get; set; }

        //public EventType TypeOfEvent { get; set; }


        // public string Position { get; set; }
        // public string Director { get; set; }
        // public string Producer { get; set; }
    }
}
