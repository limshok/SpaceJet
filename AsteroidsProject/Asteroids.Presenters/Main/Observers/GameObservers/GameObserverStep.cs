using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Utility;

namespace Asteroids.Controllers.Main.Observers.GameObservers
{
    public class GameObserverStep : IStep
    {
        public void Execute(List<IPresenter> controllers, Environment environment, IEnvironmentView environmentView)
        {
            var controller = new GameObserverPresenter(environment);
            controllers.Add(controller);
        }
    }
}