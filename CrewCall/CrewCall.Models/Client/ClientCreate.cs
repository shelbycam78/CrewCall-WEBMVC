using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrewCall.Models
{
    public class ClientCreate
    {
        [Key]
        [Required]
        public int ClientId { get; set;}
        
        [Required]
        public string Company { get; set; }
       
        

    }
}
