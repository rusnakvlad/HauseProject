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
        public Task<IEnumerable<AdInfoDTO>> GetAllAds();

        public Task<AdInfoDTO> GetAdById(int id);

        public Task AddNewAd(AdCreateDTO createAdDTO);

        public Task DeleteAdById(int id);

        public Task UpdateAd(AdEdit editAdDTO);

        public Task<IEnumerable<AdInfoDTO>> GetAdsByUserId(string userId);

        /*------------------------------Individual methods------------------------------*/
       

    }
}
