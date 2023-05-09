using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meddy.FlowManager.models.FlowModels
{
    public class ToDoStep : IBaseStep
    {
        public string? Id { get; set; }

        public string? Message { get; set; }
        
    }
}
