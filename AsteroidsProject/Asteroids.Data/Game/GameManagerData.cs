using System;

namespace Asteroids.Models.Game
{
    public class GameManagerData: IData
    {
        public event Action OnStart;
        public event Action OnStop;

        public void Start()
        {
            OnStart?.Invoke();
        }

        public void Stop()
        {
            OnStop?.Invoke();
        }
    }
}