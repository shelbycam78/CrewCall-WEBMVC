using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrewCall.Data
{
    public class Client
    {
        [Key]
        [Required]
        public int ClientId { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        [ForeignKey(nameof(ContactId))]
        public int ContactId{ get; set; }



        public virtual Contact Contact {get;set;}
        // public virtual ICollection<Event> Events { get; set; }


    }
}
