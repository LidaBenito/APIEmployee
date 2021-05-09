using System;
using System.ComponentModel.DataAnnotations;

namespace Employee.Models
{
    public class Employees
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
