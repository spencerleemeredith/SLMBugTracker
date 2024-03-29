﻿using Microsoft.AspNetCore.Http;
using SLMBugTracker.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SLMBugTracker.Models
{
    public class TicketAttachment
    {
        public int Id { get; set; }

        //Creats a foreign key for the Ticket
        [DisplayName("Ticket")]
        public int TicketId { get; set; }

        //Create a foreign key for the Date
        [DisplayName("File Date")]
        public DateTimeOffset Created { get; set; }

 
        //Create a foreign key for the Team Member
        [DisplayName("Team Member")]
        public string UserId { get; set; }

        //Create a foreign key for the Description
        [DisplayName("File Description")]
        public string Description { get; set; }


        // 
        [NotMapped]
        [DataType(DataType.Upload)]
        [MaxFileSize(1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".doc", ".docx", ".xls", ".xlsx", ".pdf", ".ppt", ".pptx", ".html"  } )]
        // [NotMapped]
        
        public IFormFile FormFile { get; set; }
        [DisplayName("File Name")]
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        [DisplayName("File Extension")]
        public string FileContentType { get; set; }
        


        //Navigation properties
        public virtual Ticket Ticket { get; set; }

        public virtual BTUser User { get; set; }    


    }
}
