using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DataAccesLayer.Enteties
{
    public class UsersRefreshToken
    {
        [Key]
        public string Token { get; set; }
        public string UserId { get; set; }

        // Navigation
        public User user { get; set; }
    }
}
