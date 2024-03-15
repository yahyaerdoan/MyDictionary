using System;
using System.Collections.Generic;

namespace Dictionary.EntityLayer.Concrete
{
    public class Writer
    {
        public int WriterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }

        public ICollection<Head> Heads { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
