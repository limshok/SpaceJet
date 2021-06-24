using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Utility;

namespace Asteroids.Controllers.Screens.StartScreen
{
    public class StartScreenStep : IStep
    {
        public void Execute(List<IPresenter> controllers, Environment environment, IEnvironmentView environmentView)
        {
            var controller = new StartScreenPresenter(environment, environment.Screens.StartScreenData, environmentView.StartScreenView);
            controllers.Add(controller);
        }
    }
}