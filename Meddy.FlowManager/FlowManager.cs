using Meddy.FlowManager.models.FlowModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meddy.FlowManager
{
    public class FlowManager
    {
        private Flow flow;
        private IBaseStep currentStep;
        public FlowManager(string path)
        {
            var flowGenerator = new FlowGenerator();
            flow = flowGenerator.GenerateFlow(path);
            currentStep = flow.Steps[0];
        }

        private IBaseStep FindNextStep(string answer)
        {
            if (currentStep is YesNoStep)
            {
                var step = currentStep as YesNoStep;
                if (answer == "yes")
                    return step.Yes[0];
                else if (answer == "no")
                    return step.No[0];

            }

            var path = currentStep.Id.Split('_');
            return FindNextStep(flow.Steps, path, 0);

        }

        private IBaseStep FindNextStep(object stepsObj, string[] path, int index)
        {
            IBaseStep? answer = null;

            if (index == path.Length - 1)
            {
                if (stepsObj is YesNoStep yesNoStep)
                {
                    if (path[index] == "yes")
                        return yesNoStep.Yes[0];
                    else if (path[index] == "no")
                        return (yesNoStep.No[0]);
                }
                return null;

            }
            else
            {
                if (stepsObj is List<IBaseStep> steps)
                {
                    if (int.TryParse(path[index], out int i))
                    {
                        if (i < steps.Count())
                        {
                            answer = FindNextStep(steps[i], path, index++);
                            if (answer != null)
                                return answer;
                            if (i < steps.Count() - 1)
                                return (steps[i + 1]);
                        }
                    }
                }
                else
                {
                    if (stepsObj is YesNoStep yesNoStep)
                    {
                        if (path[index] == "yes")
                        {
                            answer = FindNextStep(yesNoStep.Yes, path, index++);
                            if (answer != null)
                                return answer;
                            if (yesNoStep.Yes != null)
                                return yesNoStep.Yes[0];

                        }
                        else if (path[index] == "no")
                        {
                            answer = FindNextStep(yesNoStep.No, path, index++);
                            if (answer != null)
                                return answer;
                            if (yesNoStep.No != null)
                                return yesNoStep.No[0];

                        }
                    }
                }


            }

            return null;

        }


    }
}
