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
        private readonly IAdServices adServices;

        public AdController(IAdServices adServices) => this.adServices = adServices;

        // get all ads
        [HttpGet]
        public IEnumerable<AdInfoDTO> GetAllAds() => adServices.GetAllAds();

        // get ad by id
        [HttpGet("/Ad/{id}")]
        public AdInfoDTO GetAddDTOByID(int id) => adServices.GetAdById(id);
        

        // add new ad
        [HttpPost]
        public void AddNewAdd ([FromBody]AdCreateDTO createAdDTO) => adServices.AddNewAd(createAdDTO);
        

        // delete ad by id
        [HttpDelete("/Ad/{id}")]
        public void DeleteAdById(int id) => adServices.DeleteAdById(id);


        // edit ad by id
        [HttpPut]
        public void EditAd([FromBody] AdEdit editAdDTO) => adServices.UpdateAd(editAdDTO); 

    }
}
