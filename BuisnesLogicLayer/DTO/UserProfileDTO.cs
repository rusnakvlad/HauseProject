﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnesLogicLayer.DTO
{
    public class UserProfileDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int AdsAmount { get; set; }

        public int ComentsAmount { get; set; }
    }
}
