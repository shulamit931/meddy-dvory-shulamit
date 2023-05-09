using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meddy.FlowManager.models.BaseModels
{
    public class BaseStep
    {
        public string? name { get; set; }
        public string? type { get; set; }
        public string? message { get; set; } 
        public List<BaseStep>? no { get; set; }=new List<BaseStep>();
        public List<BaseStep>? yes { get; set; }=new List<BaseStep>();
   
    }
}
