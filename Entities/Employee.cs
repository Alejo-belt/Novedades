using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public DateTime InitiationDate { get; set; }

        public bool ModifyOverTimeReport { get; set; }

        [Required]
        public Role Rol { get; set; }

        public int? LeaderId { get; set; }
        public Employee? Leader { get; set; }  // Autoreferencia

        public int AreaId { get; set; }
        public Area Area { get; set; } = null!;

        // Relación con Reportes de Horas Extras
        public ICollection<OverTimeReport> OverTimeReports { get; set; } = new List<OverTimeReport>();

        public ICollection<Employee> Subordinates { get; set; } = new List<Employee>(); // Empleados que reportan a este empleado

        // Propiedad calculada para obtener la suma de horas extras remuneradas en el mes actual
        [NotMapped]
        public decimal TotalRemuneratedHoursThisMonth
        {
            get
            {
                var currentMonth = DateTime.Now.Month;
                var currentYear = DateTime.Now.Year;
                return OverTimeReports
                    .Where(r => r.DateReport.Month == currentMonth && r.DateReport.Year == currentYear && r.IsRemunerated)
                    .Sum(r => r.ReportedHours);
            }
        }
    }
}
    

