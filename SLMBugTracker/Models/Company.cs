﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SLMBugTracker.Models
{
    public class Company
    {
        //Primary Key
        public int Id { get; set; }

        [DisplayName("Company Name")]

        // foreign key for Company
        public string Name { get; set; }
        
        
        [DisplayName("Company Description")]

        public string Description { get; set; }


        //Navigation Property
        public virtual ICollection<BTUser> Members { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        // create relationship to Invites



 
        
    
    }
}
