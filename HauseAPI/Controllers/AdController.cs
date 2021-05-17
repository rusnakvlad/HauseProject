﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnesLogicLayer.Interfaces;
using BuisnesLogicLayer.Services;
using BuisnesLogicLayer.DTO;
using DataAccesLayer.Enteties;

namespace HauseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdController : Controller
    {
        private readonly IAdServices adServices;

        public AdController(IAdServices adServices) => this.adServices = adServices;

        // get all ads
        [HttpGet("GetAll")]
        public async Task<IEnumerable<AdInfoDTO>> GetAllAds()
        {
            return await adServices.GetAllAds();
        }

        // get by option ads
        [HttpPost("GetByOptions")]
        public async Task<IEnumerable<AdInfoDTO>> GetAdsByOptions([FromBody] AdToCompare adToCompare)
        {
            return await adServices.GetAdsByOptions(adToCompare);
        }

        // get all ads by user id
        [HttpGet("/Ad/UserId/{userId}")]
        public async Task<IEnumerable<AdInfoDTO>> GetAllAdsByUserId(string userId)
        {
            return await adServices.GetAdsByUserId(userId);
        }

        // get ad by id
        [HttpGet("/Ad/GetById/{id}")]
        public async Task<AdInfoDTO> GetAddDTOByID(int id)
        {
            return await adServices.GetAdById(id);
        }

        // add new ad
        [HttpPost]
        public async Task AddNewAdd([FromBody] AdCreateDTO createAdDTO)
        {
            await adServices.AddNewAd(createAdDTO);
        }

        // delete ad by id
        [HttpDelete("/Ad/{id}")]
        public async Task DeleteAdById(int id)
        {
            await adServices.DeleteAdById(id);
        }

        // edit ad by id
        [HttpPut]
        public async Task EditAd([FromBody] AdEditDTO editAdDTO)
        {
            await adServices.UpdateAd(editAdDTO);
        }
        [HttpGet("/Ad/GetByIdToEdit/{id}")]
        public async Task<AdEditDTO> GetAdToEdit(int id)
        {
            return await adServices.GetAdToEdit(id);
        }
    }
}
