using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalGuide.Data.Models.Contracts
{
    using System;

    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }
    }
}
