using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccesLayer.Enteties
{
    [Display]
    public class User
    {
        public IEnumerable<Ad> ads { get; set; }
        public IEnumerable<Comment> comments { get; set; }
        public IEnumerable<Favorite> favorites { get; set; }
        public IEnumerable<ForCompare> forCompares { get; set; }
        //=============================================================//
        public int ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public bool AdminRights { get; set; }

        public string Password { get; set; }


        public User(int id, string name, string surname, string phone, string email, bool adminRights,string password)
        {
            ID = id;
            Name = name;
            Surname = surname;
            Phone = phone;
            Email = email;
            AdminRights = adminRights;
            Password = password;
        }

        public User() { }
    }
}
