using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrewCall.Data
{
    //public enum EventType { Sports, Concert, Graduation, Corporate, Other }


    public class Event
    {

        [Key]
        [Required]
        [Display(Name = "Invoice Number")]
        public int EventId { get; set; }

        
        [ForeignKey(nameof(Venue))]
        [Display(Name = "Venue")]
        public int VenueId { get; set; }
        public virtual Venue Venue { get; set; }


        [ForeignKey(nameof(Client))]
        [Display(Name = "Client")]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }


        [ForeignKey (nameof(Contact))]
        [Display(Name = "Contact")]
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }


        [Required]
        [Display(Name = "Date")]
        public DateTime EventDate { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string EventTitle { get; set; }

        //public EventType TypeOfEvent { get; }

        [Required]
        [Display(Name = "Have you been paid?")]
        public bool IsPaid { get; set; }

        [Display(Name = "Did they take out taxes?")]
        public bool IsTaxed { get; set; }

        [Display(Name = "Paid via direct deposit?")]
        public bool IsDirectDeposit { get; set; }

        
        // public string Position { get; set; }
        // public string Director { get; set; }
        // public string Producer { get; set; }
    }
}

