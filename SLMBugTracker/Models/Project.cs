﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SLMBugTracker.Models
{
    public class Project
    {
        //Primary Key
        public int Id { get; set; }

        [DisplayName("Company")]

        // foreign key for Company
        public int? CompanyId { get; set; }
        
        [Required]
        [StringLength(50)]
        [DisplayName("Project Name")]
        public string Name { get; set; }


        [DisplayName("Description")]
        public string Description { get; set; }


        //Start Date
        [DisplayName("Start Date")]
        [DataType(DataType.Date)]

        public DateTimeOffset StartDate { get; set; }

        //End Date
        [DisplayName("End Date")]
        [DataType(DataType.Date)]
        public DateTimeOffset EndDate { get; set; }

        //Priority
        [DisplayName("Priority")]
        public int ProjectPriorityId { get; set; }

        //set the ImageFormFile property to a new instance of the IFormFile class.


        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile ImageFormFile { get; set; }
        
        [DisplayName("File Name")]
        public string ImageFileName { get; set; }
 
        public byte[] ImageFileData { get; set; }
        
        [DisplayName("File Extension")]
        public string ImageContentType { get; set; }
        //public string ImageUrl { get; set; }

        [DisplayName("Archived")]
        public bool Archived { get; set; }


        //Navigation Properties
        public virtual Company Company { get; set; }

        // Project Priority
        public virtual ProjectPriority ProjectPriority { get; set; }

        public virtual ICollection<BTUser> Members { get; set; } = new 
        HashSet<BTUser>();
        public virtual ICollection<Ticket> Tickets { get; set; } = new 
        HashSet<Ticket>();
        



       
    
    }
}
