using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrewCall.Models
{
    public class VenueDetail
    {

        public int VenueId { get; set; }


        [Display(Name = "Venue")]
        public string VenueName { get; set; }


        [Display(Name = "Location")]
        public string VenueLocation { get; set; }
    }
}
