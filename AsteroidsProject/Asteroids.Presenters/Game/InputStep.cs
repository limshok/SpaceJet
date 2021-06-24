using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Utility;

namespace Asteroids.Controllers.Game
{
    public class InputStep : IStep
    {
        public void Execute(List<IPresenter> controllers, Environment environment, IEnvironmentView environmentView)
        {
            var controller = new InputPresenter(environment, environmentView.InputView);
            controllers.Add(controller);
        }
    }
}