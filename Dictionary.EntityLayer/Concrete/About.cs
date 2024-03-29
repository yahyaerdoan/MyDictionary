﻿using System.ComponentModel.DataAnnotations;

namespace Dictionary.EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AboutId { get; set; }
        public string Detail { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Picture { get; set; }
    }
}
