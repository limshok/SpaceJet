using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Utility;

namespace Asteroids.Controllers.Game
{
    public class GameManagerStep : IStep
    {
        public void Execute(List<IPresenter> controllers, Environment environment, IEnvironmentView environmentView)
        {
            var controller = new GameManagerPresenter(environment, environment.GameManagerData, environmentView);
            controllers.Add(controller);
        }
    }
}