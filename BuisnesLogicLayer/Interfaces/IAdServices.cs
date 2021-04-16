using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnesLogicLayer.DTO;

namespace BuisnesLogicLayer.Interfaces
{
    public interface IAdServices
    {
        /*--------------------Common Methods from Generic repository--------------------*/
        public IEnumerable<AdInfoDTO> GetAllAds();

        public AdInfoDTO GetAdById(int id);

        public void AddNewAd(AdCreateDTO createAdDTO);

        public void DeleteAdById(int id);

        public void UpdateAd(AdEdit editAdDTO);

        /*------------------------------Individual methods------------------------------*/
        public void SetFavorite(int userId, int adId);

        public void SetForCompare(int userId, int adId);

    }
}
