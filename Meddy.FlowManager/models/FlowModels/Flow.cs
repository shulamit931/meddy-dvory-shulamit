using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meddy.FlowManager.models.FlowModels
{
    public class Flow
    {
        public string? Name { get; set; }
        public List<IBaseStep>? Steps { get; set; }=new List<IBaseStep>();
    }
}
