using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnesLogicLayer.Interfaces;
using BuisnesLogicLayer.Services;
using BuisnesLogicLayer.DTO;
namespace BuisnesLogicLayer.Interfaces
{
    public interface IForCompareServices
    {
        public IEnumerable<ForCompareDTO> GetAllComparesByUserId(int userId);

        public void RemoveCopareByUserIdAndAdId(int userId, int AdId);
    }
}
