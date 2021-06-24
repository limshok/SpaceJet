using Asteroids.Core;
using Asteroids.Core.Updaters;

namespace Asteroids.Controllers.Game.Shots
{
    public class ShotUpdater : IUpdater
    {
        public void Update(Environment environment)
        {
            environment.ShotData.Update();
        }
    }
}