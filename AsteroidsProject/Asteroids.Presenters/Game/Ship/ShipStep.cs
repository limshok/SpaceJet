using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Utility;

namespace Asteroids.Controllers.Game.Ship
{
    public class ShipStep : IStep
    {
        public void Execute(List<IPresenter> controllers, Environment environment, IEnvironmentView environmentView)
        {
            var controller = new ShipPresenter(environment, environment.ShipData, environmentView.ShipView);
            controllers.Add(controller);
        }
    }
}