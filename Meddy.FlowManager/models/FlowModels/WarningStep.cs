using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meddy.FlowManager.models.FlowModels
{
    public class WarningStep : IBaseStep
    {
        public string? Id { get; set; }

        public string? Message { get; set; }
    }
}
