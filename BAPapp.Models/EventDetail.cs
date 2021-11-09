using BAPapp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Models
{
    public class EventDetail
    {
        public int EventId { get; set; }

        [Display(Name = "Event Title")]
        public string EventTitle { get; set; }
        
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

    }
}
