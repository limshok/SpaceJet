using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Utility;

namespace Asteroids.Controllers.Main.Player
{
    public class PlayerStep : IStep
    {
        public void Execute(List<IPresenter> controllers, Environment environment, IEnvironmentView environmentView)
        {
            var controller = new PlayerPresenter(environment, environment.PlayerData);
            controllers.Add(controller);
        }
    }
}