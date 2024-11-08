using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NguyenVanLinh_22115053122225_MVC.Models
{
    public class User
    {
        public int userId { get; set; } 

        public string userName { get; set; }

        public string email { get; set; }

        public string password { get; set; }
    }
}