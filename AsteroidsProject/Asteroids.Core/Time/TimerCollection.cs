using System.Collections.Generic;

namespace Asteroids.Core.Time
{
    public class TimerCollection : ITimer
    {
        private readonly List<ITimer> _times = new List<ITimer>();

        public void Add(ITimer timer)
        {
            _times.Add(timer);
        }

        public void Remove(ITimer timer)
        {
            _times.Remove(timer);
        }

        public void Update(float deltaTime)
        {
            foreach (var time in _times)
            {
                time.Update(deltaTime);
            }
        }
    }
}