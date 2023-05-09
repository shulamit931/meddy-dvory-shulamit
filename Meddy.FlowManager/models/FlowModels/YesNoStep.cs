using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meddy.FlowManager.models.FlowModels
{
    public class YesNoStep : IBaseStep
    {
        public string? Id { get; set; }

        public string? Message { get; set; }

        public List<IBaseStep>? Yes { get; set; }

        public List<IBaseStep>? No { get; set; }
    }
}
