using System;

namespace Asteroids.Core.Time
{
    public class Timer : ITimer
    {
        public event Action OnNotify;

        private float _timer;
        private float Time { get; set; }
        private readonly bool _isLoop;
        private bool _isComplete;

        public Timer(float timer, bool isLoop)
        {
            _timer = timer;
            _isLoop = isLoop;
        }

        public void Update(float deltaTime)
        {
            Time += deltaTime;
            if (Time > _timer && !_isComplete)
            {
                OnNotify?.Invoke();
                if (_isLoop)
                {
                    Time -= _timer;
                }
                else
                {
                    _isComplete = true;
                }
            }
        }

        public void ChangeTime(float time)
        {
            _timer = time;
        }

        public void Reset()
        {
            Time = 0;
        }
    }
}