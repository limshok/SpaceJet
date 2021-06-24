using System.Collections.Generic;

namespace Asteroids.Core.Updaters
{
    public class SystemUpdater : IUpdater
    {
        private readonly List<IUpdater> _updaters = new List<IUpdater>();

        public void Update(Environment environment)
        {
            foreach (var updater in _updaters)
            {
                updater.Update(environment);
            }
        }

        public void Add(IUpdater updater)
        {
            _updaters.Add(updater);
        }

        public void Clear()
        {
            _updaters.Clear();
        }
    }
}