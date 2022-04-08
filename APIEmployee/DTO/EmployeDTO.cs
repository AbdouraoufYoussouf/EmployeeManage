using System.ComponentModel.DataAnnotations;

namespace APIEmployee.DTO{
    public class EmployeeDTO{
        
       public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBrith { get; set; }
        public string? PhotoPath { get; set; }
      
    }
    public class EmployeeUpdateDTO{
        
       public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBrith { get; set; }
        public string? PhotoPath { get; set; }
        [Required(ErrorMessage ="the departement is required")]
        public int DepId {get;set;}
    }

    public class EmployeeDetailsDTO{
       public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBrith { get; set; }
        public string? PhotoPath { get; set; }
        public int DepId {get;set;}
        public string Departement {get;set;}
    }
}