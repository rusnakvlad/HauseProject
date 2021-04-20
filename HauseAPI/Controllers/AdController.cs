using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnesLogicLayer.Interfaces;
using BuisnesLogicLayer.Services;
using BuisnesLogicLayer.DTO;
namespace HauseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdController : Controller
    {
        private readonly IAdServices adService;

        public AdController(IAdServices adServices) => adService = adServices;

        // get all ads
        [HttpGet]
        public IEnumerable<AdInfoDTO> GetAllAds() => adService.GetAllAds();

        // get ad by id
        [HttpGet("/Ad/{id}")]
        public AdInfoDTO GetAddDTOByID(int id) => adService.GetAdById(id);
        

        // add new ad
        [HttpPost]
        public void AddNewAdd ([FromBody]AdCreateDTO createAdDTO) => adService.AddNewAd(createAdDTO);
        

        // delete ad by id
        [HttpDelete("/Ad/{id}")]
        public void DeleteAdById(int id) => adService.DeleteAdById(id);


        // edit ad by id
        [HttpPut]
        public void EditAd([FromBody] AdEdit editAdDTO) => adService.UpdateAd(editAdDTO); 

    }
}
