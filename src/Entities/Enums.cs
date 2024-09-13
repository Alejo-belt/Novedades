using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public enum Role
    {
        gerente =1, lider, colaborador, auxiliarTh
    }
    //Estado de OverTimeReport
    public enum State
    {
        pendent =1,
        approved,
        rejected
    }
}
