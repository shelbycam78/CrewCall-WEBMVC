﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrewCall.Data
{
    public class Contact
    {
        [Key]
        [Required]
        public int ContactId { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string Email { get; set; }

        public string Phone { get; set; }
        public string Company { get; set; }


        public virtual ICollection<Event> Events { get; set; } = new List<Event>();
        public virtual ICollection<Client> Clients { get; set; } = new List<Client>();


    }
}
