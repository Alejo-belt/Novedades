using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class EmployeeCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime InitiationDate { get; set; }
        public bool ModifyOverTimeReport { get; set; }
        public Role Rol { get; set; }
        public int? LeaderId { get; set; }
        public int AreaId { get; set; }
    }
}
