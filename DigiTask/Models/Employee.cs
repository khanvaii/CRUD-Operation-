using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigiTask.Models
{
    public class Employee
    {
        
        public int Id { get; set; }

        [Required] 
        public string empName { get; set; }

        [Required]
        public string empAddress { get; set; }

        [Required]
        public string empDepart { get; set; }

        [Required]
        public int empSalary { get; set; }


    }
}