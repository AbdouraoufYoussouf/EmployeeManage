using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIEmployee.Models
{
    public class Departement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepId { get; set; }
       
        public string DepName { get; set; }
//        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }    
    }
}
