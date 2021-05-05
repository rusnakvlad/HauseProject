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
                yield return new ImageEditInfoDTO() { ImageFile = item.ImageFile, Id = item.ID, AdId = item.AdID };
            }
        }

        public static IEnumerable<ImageCreateDTO> FromImageBytes(List<byte[]> images)
        {
            foreach (var item in images)
            {
                yield return new ImageCreateDTO() { ImageFile = item };
            }
        }
    }
}
