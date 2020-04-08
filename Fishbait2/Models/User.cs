using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;

namespace Fishbait2.Models
{
    public class User
    {
  
        public int id { get; set; }

        public string username { get; set; }

       
        public string password { get; set; }

        
        public string mail { get; set; }

   
    }
}
