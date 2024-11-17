using Mid_Term_Project.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mid_Term_Project.DTO
{
    public class ParentDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }
        
        [Required]
        public int SId { get; set; }

        public virtual Student Student { get; set; }
    }
}