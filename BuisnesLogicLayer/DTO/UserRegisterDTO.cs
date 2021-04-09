using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnesLogicLayer.DTO
{
    public class UserRegisterDTO
    {

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
