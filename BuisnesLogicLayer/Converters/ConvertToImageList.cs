using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnesLogicLayer.DTO;
using DataAccesLayer.Enteties;

namespace BuisnesLogicLayer.Converters
{
    public class ConvertToImageList
    {
        public static List<Image> FromImageCreateDTOList(List<ImageCreateDTO> imageDTOs)
        {
            List<Image> tepm = new();
            foreach (var item in imageDTOs)
            {
                tepm.Add(new Image() { ImageUrl = item.ImageUrl });
            }
            return tepm;
        }
    }
}
