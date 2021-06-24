using System.Collections.Generic;
using Asteroids.Utility;

namespace Asteroids.Core
{
    public class StepExecutor : IStep
    {
        private readonly List<IStep> _steps = new List<IStep>();

        public void Execute(List<IPresenter> controllers, Environment environment, IEnvironmentView environmentView)
        {
            foreach (var step in _steps)
            {
                step.Execute(controllers, environment, environmentView);
            }
        }

        public void Add(IStep step)
        {
            _steps.Add(step);
        }

        public void Clear()
        {
            _steps.Clear();
        }
    }
}