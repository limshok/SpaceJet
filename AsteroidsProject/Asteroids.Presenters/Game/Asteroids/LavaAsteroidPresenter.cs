using Asteroids.Core;
using Asteroids.Models.Game.Asteroids;
using Asteroids.Views.Game.Asteroids;

namespace Asteroids.Controllers.Game.Asteroids
{
    public class LavaAsteroidPresenter : BaseSubAsteroidPresenter
    {
        public LavaAsteroidPresenter(Environment environment, SubAsteroidData data, ISubAsteroidView view) : base(environment, data, view)
        {
        }
    }
}