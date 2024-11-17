using Mid_Term_Project.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mid_Term_Project.DTO
{
    public class StudentDTO
    { 
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Grade { get; set; }
        [Required]
        public string Address { get; set; }

        public Nullable<byte> Valid { get; set; }

        public Nullable<int> SId { get; set; }
        public Nullable<int> PId { get; set; }
        public Nullable<int> AId { get; set; }
        public virtual Parent Parent { get; set; }

        public virtual Schedule Schedule { get; set; }


        public virtual ICollection<Attendence> Attendences { get; set; }

        public StudentDTO()
        {
            Attendences = new HashSet<Attendence>();
        }


    }
}