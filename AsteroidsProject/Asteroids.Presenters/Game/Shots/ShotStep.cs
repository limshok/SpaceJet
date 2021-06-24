using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Utility;

namespace Asteroids.Controllers.Game.Shots
{
    public class ShotStep : IStep
    {
        public void Execute(List<IPresenter> controllers, Environment environment, IEnvironmentView environmentView)
        {
            var controller = new ShotPresenter(environment, environment.ShotData);
            controllers.Add(controller);
        }
    }
}