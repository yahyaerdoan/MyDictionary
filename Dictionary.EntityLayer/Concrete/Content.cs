using System;

namespace Dictionary.EntityLayer.Concrete
{
    public class Content
    {
        public int ContentId { get; set; }
        public string Purview { get; set; }
        public DateTime Date { get; set; }

        public int HeadId { get; set; }
        public virtual Head Head { get; set; }

        public int? WriterId { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
