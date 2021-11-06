using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BAPapp.WebMVC.Models
{
    public class EventCreate
    {
        [Required]
        public Guid EventId { get; set; }
        public DateTime EventDate { get; set; }

        [Required]
        public string EventTitle { get; set; }

        [Required]
        [Display(Name = "Venue")]
        public Guid VenueId { get; set; }

        [Required]
        // [ForeignKey("CrewerId")]
        [Display(Name = "Crewer")]
        public Guid CrewerId { get; set; }
        public string Position { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }

        [Required]
        [Display(Name = "Have you been paid?")]
        public bool IsPaid { get; set; }

        [Display(Name = "Did they take out taxes?")]
        public bool IsTaxed { get; set; }

        [Display(Name = "Paid via direct deposit?")]
        public bool IsDirectDeposit { get; set; }
    }
}