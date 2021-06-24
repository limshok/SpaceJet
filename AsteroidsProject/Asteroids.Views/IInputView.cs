using System;

namespace Asteroids.Views
{
    public interface IInputView
    {
        public event Action<float, float> Move;
        public event Action Fire;
    }
}