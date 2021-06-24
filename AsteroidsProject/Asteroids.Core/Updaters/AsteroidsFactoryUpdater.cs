namespace Asteroids.Core.Updaters
{
    public class AsteroidsFactoryUpdater : IUpdater
    {
        public void Update(Environment environment)
        {
            environment.AsteroidData.Update();
        }
    }
}