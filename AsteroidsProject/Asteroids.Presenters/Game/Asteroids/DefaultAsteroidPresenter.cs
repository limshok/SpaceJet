using Asteroids.Core;
using Asteroids.Models.Game.Asteroids;
using Asteroids.Views.Game.Asteroids;

namespace Asteroids.Controllers.Game.Asteroids
{
    public class DefaultAsteroidPresenter : BaseSubAsteroidPresenter
    {
        public DefaultAsteroidPresenter(Environment environment, SubAsteroidData data, ISubAsteroidView view) : base(environment, data, view)
        {
        }
    }
}