using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using BuisnesLogicLayer.DTO;

namespace BuisnesLogicLayer.Validators
{
    public class UserRegisterDTOValidator : AbstractValidator<UserRegisterDTO>
    {
        public UserRegisterDTOValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            RuleFor(u => u.Password)
                .NotEmpty()
                .Matches(@"/^(.{0,7}|[^0-9]*|[^A-Z])$/gm");

            RuleFor(u => u.PasswordConfirmation)
                .NotEmpty()
                .Equal(u => u.Password);

            RuleFor(u => u.Name)
                .NotEmpty()
                .Matches(@"^\S+");

            RuleFor(u => u.Surname)
                .NotEmpty()
                .Matches(@"^\S+");

            RuleFor(u => u.Phone)
                .NotEmpty()
                .Matches(@"^\d{9}");

        }
    }
}
