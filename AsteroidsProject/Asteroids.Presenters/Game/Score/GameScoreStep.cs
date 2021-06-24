using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Utility;

namespace Asteroids.Controllers.Game.Score
{
    public class GameScoreStep : IStep
    {
        public void Execute(List<IPresenter> controllers, Environment environment, IEnvironmentView environmentView)
        {
            var controller = new GameScorePresenter(environment, environment.GameScoreData);
            controllers.Add(controller);
        }
    }
}