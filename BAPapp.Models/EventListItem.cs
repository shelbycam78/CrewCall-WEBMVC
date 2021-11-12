using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Models
{
    public class EventListItem
    {
        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        public string EventTitle { get; set; }
        
    }
}
