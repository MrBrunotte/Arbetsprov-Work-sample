using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Arbetsprov.Models
{
    public class EmployeeViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Namn")]
        public string Employee_name { get; set; }
        [Display(Name = "Lön")]
        public int Employee_salary { get; set; }
        [Display(Name = "Ålder")]
        public int Employee_age { get; set; }
        [Display(Name = "Profil bild")]
        public string Profile_image { get; set; }
    }
}
