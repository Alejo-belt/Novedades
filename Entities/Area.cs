using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Area
    {
        [Key] 
        public int AreaId { get; set; }

        [Required] 
        [MaxLength(100)] 
        public string Name { get; set; } = string.Empty;

        [Required] 
        public DateTime CreationDate { get; set; }

        // Relación con Empleados
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }

}
