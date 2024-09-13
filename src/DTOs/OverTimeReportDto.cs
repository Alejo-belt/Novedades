using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class OverTimeReportDto
    {
        //Para los métodos post y put se tomará el id por la url. 
        public int OverTimeReportId { get; set; }
        public DateTime DateReport { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ReportedHours { get; set; }
        public string Motive { get; set; } = string.Empty;
        public State GetState { get; set; }
        public Role Role { get; set; }
        public int EmployeeId { get; set; }
      
        public bool IsRemunerated { get; set; }
    }

}