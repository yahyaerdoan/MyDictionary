using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.EntityLayer.Dto
{
    public class WriterMessageDto
    {
        // for admin table
        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string AdminEmail { get; set; }

        // for writer table
        public int MessageId { get; set; }
        public string SenderMail { get; set; }
        public string ReceverMail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }        
        public DateTime Date { get; set; }

        // for writer table
        public string FirstName { get; set; }
        public string LastName { get; set; }     
        public string Email { get; set; }
    }
}
