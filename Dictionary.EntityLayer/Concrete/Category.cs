using System.Collections.Generic;
using System.Web.Mvc;

namespace Dictionary.EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public bool Status { get; set; }

        public ICollection<Head> Heads{ get; set; }
    }
}
