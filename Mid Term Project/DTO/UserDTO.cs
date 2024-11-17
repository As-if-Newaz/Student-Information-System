using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mid_Term_Project.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        public string Uname { get; set; }
        [Required]
        public string Password { get; set; }
    }
}