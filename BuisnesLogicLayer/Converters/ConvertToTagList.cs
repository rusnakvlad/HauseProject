using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnesLogicLayer.DTO;
using DataAccesLayer.Enteties;

namespace BuisnesLogicLayer.Converters
{
    public class ConvertToTagList
    {
        public static List<Tag> FromTagDTOList(List<TagDTO> tagDTOs)
        {
            List<Tag> tepm = new();
            foreach (var item in tagDTOs)
            {
                tepm.Add(new Tag() { Tag_ = item._Tag });
            }
            return tepm;
        }
    }
}
