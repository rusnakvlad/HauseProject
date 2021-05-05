using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnesLogicLayer.DTO
{
    public class TagDTO
    {
        public string _Tag { get; set; }

        public TagDTO(string tag) => _Tag = tag;
        public TagDTO() { }
    }
}
