using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OverTimeReport
    {
        public int OverTimeReportId { get; set; }
        public DateTime DateReport { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ReportedHours { get; set; }
        public string Motive { get; set; } = string.Empty;
        public Role Role { get; set; }
        public State GetState { get; set; }
        //Para impedir modificar el estado del OverTimeReport cuando el gerente defina el estado
        public bool decisiónGerente = false;
        //Para impedir al líder modificar el estado del OverTimeReport, pero no impeírselo al gerente
        public bool decisiónAuxiliarTh = false;
       
        // Relación con Empleado
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        // Indica si las horas extras serán remuneradas en dinero o redimidas en días de descanso
        public bool IsRemunerated { get; set; } = true;


    }
}
