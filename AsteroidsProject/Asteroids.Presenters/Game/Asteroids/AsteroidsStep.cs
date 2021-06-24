using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Utility;

namespace Asteroids.Controllers.Game.Asteroids
{
    public class AsteroidsStep : IStep
    {
        public void Execute(List<IPresenter> controllers, Environment environment, IEnvironmentView environmentView)
        {
            var controller = new AsteroidPresenter(environment, environment.AsteroidData, environmentView.AsteroidView);
            controllers.Add(controller);
        }
    }
}