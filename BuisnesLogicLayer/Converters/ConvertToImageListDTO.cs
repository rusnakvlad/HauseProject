using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnesLogicLayer.DTO;
using DataAccesLayer.Enteties;

namespace BuisnesLogicLayer.Converters
{
    public class ConvertToImageListDTO
    {
        public static IEnumerable<ImageDTO> FromImageList(IEnumerable<Image> images)
        {
            foreach (var item in images)
            {
                yield return new ImageDTO() { ImageURL = item.ImageUrl };
            }
        }
    }
}
