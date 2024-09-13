using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class OverTimeReportCreateDto
    {
        public DateTime DateReport { get; set; }
        public decimal ReportedHours { get; set; }
        public string Motive { get; set; } = string.Empty;
        public Role Role { get; set; }
        public State GetState { get; set; }
     
        public int EmployeeId { get; set; }
        public bool IsRemunerated { get; set; }
    }
}
