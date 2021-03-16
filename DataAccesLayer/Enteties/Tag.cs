using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataAccesLayer.Enteties
{
    public class Tag
    {
        public List<Ad> ads { get; set; }
        [Required]
        [MaxLength(50)]
        public string Tag_ { get; set; }
        public Tag(string tag) => this.Tag_ = tag;
        public Tag() { }
    }
}
