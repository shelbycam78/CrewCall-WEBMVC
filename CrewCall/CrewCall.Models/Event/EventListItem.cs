using CrewCall.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CrewCall.Data.Event;

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
