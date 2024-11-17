using Mid_Term_Project.Val;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mid_Term_Project.DTO
{
    public class RegisterDTO
    {
        [Required]
        [StringLength(10, MinimumLength = 4)]
        public string Uname { get; set; }
        [Required]
        [PassVal]
        [StringLength(15, MinimumLength = 7)]
        public string Password { get; set; }
    }
}