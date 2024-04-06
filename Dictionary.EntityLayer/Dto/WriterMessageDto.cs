﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.EntityLayer.Dto
{
    public class WriterMessageDto
    {
        public int MessageId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }

        public string SenderMail { get; set; }
        public string ReceverMail { get; set; }
        public DateTime Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }     
        public string Email { get; set; }
    }
}
