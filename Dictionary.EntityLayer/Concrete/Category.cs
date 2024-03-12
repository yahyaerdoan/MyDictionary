using System.Collections.Generic;

namespace Dictionary.EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public ICollection<Head> Heads{ get; set; }
    }
}
