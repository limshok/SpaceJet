using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Utility;

namespace Asteroids.Controllers.Game.GameDifficulty
{
    public class GameDifficultyStep : IStep
    {
        public void Execute(List<IPresenter> controllers, Environment environment, IEnvironmentView environmentView)
        {
            var controller = new GameDifficultyPresenter(environment, environment.GameDifficultyData);
            controllers.Add(controller);
        }
    }
}