using CrewCall.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrewCall.Models
{
    public class EventCreate
    {

        [Display(Name = "Invoice Number")]
        public int EventId { get; set; }

        [Display(Name = "Date")]
        public DateTime EventDate { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string EventTitle { get; set; }

        [Required]
        [ForeignKey(nameof(Venue))]
        [Display(Name = "Venue")]
        public int VenueId { get; set; }

        [Required]
        [ForeignKey(nameof(Client))]
        [Display(Name = "Client")]
        public int ClientId { get; set; }

        [Required]
        [ForeignKey(nameof(Contact))]
        [Display(Name = "Contact")]
        public int ContactId { get; set; }
      
        [Required]
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
