using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementApp.Models
{
    public class Designation
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? DesignationSalary { get; set; }
       
    }
}
