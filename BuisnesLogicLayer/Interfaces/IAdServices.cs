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
        public void AddNewAd(CreateAdDTO createAdDTO);
        public AdInfoDTO GetAdById(int id);
    }
}
