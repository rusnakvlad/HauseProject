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
        public static IEnumerable<ImageEditInfoDTO> FromImageList(IEnumerable<Image> images)
        {
            foreach (var item in images)
            {
                yield return new ImageEditInfoDTO() { ImageURL = item.ImageUrl, Id = item.ID, AdId = item.AdID };
            }
        }
    }
}
