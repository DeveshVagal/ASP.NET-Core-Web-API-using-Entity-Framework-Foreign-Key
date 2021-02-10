using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignKeyWebAPI.Models
{
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        // Foreign key   
        [Display(Name = "Department")]
        public virtual Guid DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Departments { get; set; }
    }
}
