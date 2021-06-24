using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Utility;

namespace Asteroids.Controllers.Screens.GameScreen
{
    public class GameScreenStep : IStep
    {
        public void Execute(List<IPresenter> controllers, Environment environment, IEnvironmentView environmentView)
        {
            var controller = new GameScreenPresenter(environment, environment.Screens.GameScreenData, environmentView.GameScreenView);
            controllers.Add(controller);
        }
    }
}