using Meddy.FlowManager.models.BaseModels;
using Meddy.FlowManager.models.FlowModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Meddy.FlowManager
{
    public class FlowGenerator
    {

        public Flow GenerateFlow(string flowPath)
        {
            BaseFlow baseFlow;
            using (StreamReader r = new StreamReader(flowPath))
            {
                string json = r.ReadToEnd();
                baseFlow = JsonSerializer.Deserialize<BaseFlow>(json);
            }
            Flow flow = new Flow();
            flow.Name = baseFlow.name;
            flow.Steps = StepsMapper(baseFlow.steps, "");
            return flow;
        }

        private List<IBaseStep>? StepsMapper(List<BaseStep>? baseSteps, string parentId)
        {
            List<IBaseStep> stepsList = new List<IBaseStep>();
            int index = 0;
            foreach (var step in baseSteps)
            {
                switch (step.type)
                {
                    case "yesNoStep":
                        stepsList.Add(MapYesNoStep(step, parentId, index));
                        break;
                    case "toDoStep":
                        stepsList.Add(MapToDoStep(step, parentId, index));
                        break;
                    case "warningStep":
                        stepsList.Add(MapWarningStep(step, parentId, index));
                        break;
                    default:
                        break;
                }
                index++;
            }
            return stepsList;
        }

        private IBaseStep MapWarningStep(BaseStep baseStep, string parentId, int index)
        {
            var step = new WarningStep();
            step.Id = IdGenerator(parentId, index);
            step.Message = baseStep.message;
            return step;
        }

        private IBaseStep MapToDoStep(BaseStep baseStep, string parentId, int index)
        {
            var step = new ToDoStep();
            step.Id = IdGenerator(parentId, index);
            step.Message = baseStep.message;
            return step;
        }

        private IBaseStep MapYesNoStep(BaseStep baseStep, string parentId, int index)
        {
            var step = new YesNoStep();
            step.Id = IdGenerator(parentId, index);
            step.Message = baseStep.message;
            step.Yes = StepsMapper(baseStep.yes, step.Id + "_yes");
            step.No = StepsMapper(baseStep.no, step.Id + "_no");
            return step;
        }

        private string IdGenerator(string parentId, int index)
        {
            if (parentId == "")
                return index.ToString();
            return parentId + "_" + index.ToString();
        }
    }
}
