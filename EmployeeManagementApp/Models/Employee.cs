using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeManagementApp.Models
{
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Gender { get; set; }

        [ForeignKey("DepartmentId")]
        public string DepartmentId { get; set; }
        public Department? Department { get; set; }

        [ForeignKey("DesignationId")]
        public string DesignationId { get; set; }
        public Designation? Designation { get; set; }


    }
}

