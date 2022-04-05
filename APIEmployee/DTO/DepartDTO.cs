namespace APIEmployee.DTO{
    public class DepartDTO{
        
        public int DepId { get; set; }
       
        public string DepName { get; set; }
    }
    public class DepartDetailsDTO{
        
        public int DepId { get; set; }
       
        public string DepName { get; set; }
        public IEnumerable<EmployeeDTO> Employees {get ; set;}
    }
}